using Chorizite.Core.Dats;
using Chorizite.Core.Lib;
using Chorizite.Core.Render.DrawCommands;
using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using DatReaderWriter.DBObjs;
using DatReaderWriter.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BufferUsage = Chorizite.Core.Render.Enums.BufferUsage;
using PrimitiveType = Chorizite.Core.Render.Enums.PrimitiveType;

namespace Chorizite.Core.Render {
    /// <summary>
    /// A base implementation of a draw list
    /// </summary>
    public class DrawList : IDrawList {
        private VertexPositionColorTexture[] vertices = new VertexPositionColorTexture[10000];
        private uint[] indices = new uint[10000];

        /// <summary>
        /// Shared vertex buffer
        /// </summary>
        protected IVertexBuffer _vertexBuffer;

        /// <summary>
        /// Shared vertex array
        /// </summary>
        protected IVertexArray _vertexArray;

        /// <summary>
        /// Shared index buffer
        /// </summary>
        protected IIndexBuffer _indexBuffer;

        /// <summary>
        /// Cache for font textures
        /// </summary>
        protected Dictionary<uint, ITexture> _fontTextureCache = [];

        /// <summary>
        /// Cache for font db objs
        /// </summary>
        protected Dictionary<uint, Font> _fontCache = [];

        /// <summary>
        /// The renderer
        /// </summary>
        protected readonly IRenderer _renderer;

        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger _log;
        private readonly IDatReaderInterface _dat;

        /// <summary>
        /// The clip rects stack
        /// </summary>
        protected List<Rectangle> _clipRects = [];

        /// <summary>
        /// The draw calls list
        /// </summary>
        protected readonly List<IDrawCommand> _drawCalls = [];

        /// <summary>
        /// Constructs a new draw list interface
        /// </summary>
        /// <param name="renderer"></param>
        public DrawList(IRenderer renderer, IDatReaderInterface dat, ILogger log) {
            _renderer = renderer;
            _log = log;
            _dat = dat;

            _vertexBuffer = _renderer.GraphicsDevice.CreateVertexBuffer(1024 * 1024 * 5, BufferUsage.Dynamic); // 5 MB
            _indexBuffer = _renderer.GraphicsDevice.CreateIndexBuffer(1024 * 1024 * 2, BufferUsage.Dynamic); // 2 MB
            _vertexArray = _renderer.GraphicsDevice.CreateArrayBuffer(_vertexBuffer, VertexPositionColorTexture.Format);
        }

        // Helper to apply clip state
        private void ApplyClip(Rectangle? clip) {
            if (clip.HasValue) {
                _renderer.GraphicsDevice.Scissor = clip.Value;
                _renderer.GraphicsDevice.SetRenderState(RenderState.ScissorTest, true);
            }
            else {
                _renderer.GraphicsDevice.SetRenderState(RenderState.ScissorTest, false);
            }
        }

        // Helper to flush a batch
        private void FlushBatch(int numVertices, int numIndices) {
            if (numVertices == 0 || numIndices == 0) return;

            _vertexBuffer.SetSubData(vertices, 0, 0, numVertices);
            _indexBuffer.SetSubData(indices, 0, 0, numIndices);

            _vertexArray.Bind();
            _vertexBuffer.Bind();
            _indexBuffer.Bind();

            _renderer.GraphicsDevice.DrawElements(PrimitiveType.TriangleList, numIndices, 0);
        }

        /// <inheritdoc/>
        public virtual void Flush() {
            using (var scope = _renderer.CreateScopedState()) {
                _renderer.UIShader.SetUniform("useTexture", 0);
                scope.SetRenderState(RenderState.AlphaBlend, true);
                RenderDrawCommands(_drawCalls);
            }

            _drawCalls.Clear();
            _clipRects.Clear();
        }

        /// <summary>
        /// Render the draw commands
        /// </summary>
        /// <param name="commands"></param>
        protected virtual void RenderDrawCommands(List<IDrawCommand> commands) {
            for (int i = 0; i < commands.Count; i++) {
                var command = commands[i];
                switch (command.Type) {
                    case DrawCommandType.DrawRect:
                        DrawRectCommand((DrawRectCommand)command);
                        break;
                    case DrawCommandType.DrawRectFilled:
                        DrawRectFilledCommand((DrawRectFilledCommand)command);
                        break;
                    case DrawCommandType.DrawTexture:
                        DrawTextureCommand((DrawTextureCommand)command);
                        break;
                    case DrawCommandType.DrawRing:
                        DrawRingCommand((DrawRingCommand)command);
                        break;
                    case DrawCommandType.DrawText:
                        DrawTextCommand((DrawTextCommand)command);
                        break;
                    case DrawCommandType.Clip:
                        if (command is DrawClipCommand clipCmd) {
                            if (clipCmd.Clip.HasValue) {
                                ApplyClip(clipCmd.Clip);
                            }
                            else {
                                ApplyClip(null);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void DrawTextCommand(DrawTextCommand command) {
            int numVertices = 0;
            int numIndices = 0;

            _renderer.UIShader.SetUniform("useTexture", 1);
            if (command.Font.ShadowTexture is not null) {
                command.Font.GetShadowVertices(command, ref vertices, ref indices, ref numVertices, ref numIndices);
                command.Font.ShadowTexture.Bind();
                FlushBatch(numVertices, numIndices);

                numVertices = 0;
                numIndices = 0;
            }

            command.Font.GetVertices(command, ref vertices, ref indices, ref numVertices, ref numIndices);
            command.Font.Texture.Bind();
            FlushBatch(numVertices, numIndices);
            command.Font.Texture.Unbind();
            _renderer.UIShader.SetUniform("useTexture", 0);
        }

        private void DrawTextureCommand(DrawTextureCommand command) {
            var rect = command.Rectangle;
            var color = new ColorVec(1, 1, 1, 1);
            var uvRect = command.UVs;

            vertices[0] = new VertexPositionColorTexture(new Vector3(rect.Left, rect.Top, 0), color, new Vector2(uvRect.Left, uvRect.Top));
            vertices[1] = new VertexPositionColorTexture(new Vector3(rect.Right, rect.Top, 0), color, new Vector2(uvRect.Right, uvRect.Top));
            vertices[2] = new VertexPositionColorTexture(new Vector3(rect.Left, rect.Bottom, 0), color, new Vector2(uvRect.Left, uvRect.Bottom));
            vertices[3] = new VertexPositionColorTexture(new Vector3(rect.Right, rect.Bottom, 0), color, new Vector2(uvRect.Right, uvRect.Bottom));

            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;
            indices[3] = 2;
            indices[4] = 1;
            indices[5] = 3;

            command.Texture.Bind();
            _renderer.UIShader.SetUniform("useTexture", 1);
            FlushBatch(4, 6);
            _renderer.UIShader.SetUniform("useTexture", 0);
            command.Texture.Unbind();
        }

        private void DrawRectFilledCommand(DrawRectFilledCommand command) {
            var indicesCount = 0;
            var verticesCount = 0;

            AddQuadVerts(
                new Vector3(command.Rect.Left, command.Rect.Top, 0),
                new Vector3(command.Rect.Right, command.Rect.Top, 0),
                new Vector3(command.Rect.Left, command.Rect.Bottom, 0),
                new Vector3(command.Rect.Right, command.Rect.Bottom, 0),
                command.Color,
                ref verticesCount,
                ref indicesCount
            );

            FlushBatch(verticesCount, indicesCount);
        }

        // Helper function to add a quad (two triangles) for a border segment
        void AddQuadVerts(Vector3 topLeft, Vector3 topRight, Vector3 bottomLeft, Vector3 bottomRight, ColorVec color, ref int verticesCount, ref int indicesCount) {
            var startVertex = (uint)verticesCount;
            vertices[verticesCount++] = new VertexPositionColorTexture(topLeft, color, Vector2.Zero);
            vertices[verticesCount++] = new VertexPositionColorTexture(topRight, color, Vector2.Zero);
            vertices[verticesCount++] = new VertexPositionColorTexture(bottomLeft, color, Vector2.Zero);
            vertices[verticesCount++] = new VertexPositionColorTexture(bottomRight, color, Vector2.Zero);

            indices[indicesCount++] = startVertex + 0;
            indices[indicesCount++] = startVertex + 1;
            indices[indicesCount++] = startVertex + 2;
            indices[indicesCount++] = startVertex + 2;
            indices[indicesCount++] = startVertex + 1;
            indices[indicesCount++] = startVertex + 3;
        }
        private void DrawRingCommand(DrawRingCommand command) {
            var indicesCount = 0;
            var verticesCount = 0;

            // Ensure segments is at least 3 and clamp angles
            int segments = Math.Max(3, command.Segments);
            float startAngle = MathHelper.ToRadians(command.StartAngle);
            float endAngle = MathHelper.ToRadians(command.EndAngle);
            if (endAngle < startAngle)
                endAngle += MathHelper.TwoPi;

            // Calculate the angle step for each segment
            float angleRange = endAngle - startAngle;
            float angleStep = angleRange / segments;

            for (int i = 0; i < segments; i++) {
                float angle0 = startAngle + i * angleStep;
                float angle1 = startAngle + (i + 1) * angleStep;

                // Calculate the four corners of the quad (inner and outer points for both angles)
                Vector3 inner0 = new Vector3(
                    command.Center.X + command.InnerRadius * MathF.Cos(angle0),
                    command.Center.Y + command.InnerRadius * MathF.Sin(angle0),
                    0
                );
                Vector3 outer0 = new Vector3(
                    command.Center.X + command.OuterRadius * MathF.Cos(angle0),
                    command.Center.Y + command.OuterRadius * MathF.Sin(angle0),
                    0
                );
                Vector3 inner1 = new Vector3(
                    command.Center.X + command.InnerRadius * MathF.Cos(angle1),
                    command.Center.Y + command.InnerRadius * MathF.Sin(angle1),
                    0
                );
                Vector3 outer1 = new Vector3(
                    command.Center.X + command.OuterRadius * MathF.Cos(angle1),
                    command.Center.Y + command.OuterRadius * MathF.Sin(angle1),
                    0
                );

                // Add quad vertices in the order: inner0, outer0, inner1, outer1
                AddQuadVerts(
                    inner0, outer0, inner1, outer1,
                    command.Color,
                    ref verticesCount,
                    ref indicesCount
                );
            }

            FlushBatch(verticesCount, indicesCount);
        }

        private void DrawRectCommand(DrawRectCommand rectCmd) {
            var rect = rectCmd.Rect;
            var color = rectCmd.Color;
            var thickness = rectCmd.Thickness;

            var indicesCount = 0;
            var verticesCount = 0;

            // Top border: from (Left, Top) to (Right, Top) with thickness downward
            AddQuadVerts(
                new Vector3(rect.Left, rect.Top, 0),
                new Vector3(rect.Right, rect.Top, 0),
                new Vector3(rect.Left, rect.Top + thickness, 0),
                new Vector3(rect.Right, rect.Top + thickness, 0),
                color,
                ref verticesCount,
                ref indicesCount
            );

            // Bottom border: from (Left, Bottom) to (Right, Bottom) with thickness upward
            AddQuadVerts(
                new Vector3(rect.Left, rect.Bottom - thickness, 0),
                new Vector3(rect.Right, rect.Bottom - thickness, 0),
                new Vector3(rect.Left, rect.Bottom, 0),
                new Vector3(rect.Right, rect.Bottom, 0),
                color,
                ref verticesCount,
                ref indicesCount
            );

            // Left border: from (Left, Top) to (Left, Bottom) with thickness rightward
            AddQuadVerts(
                new Vector3(rect.Left, rect.Top, 0),
                new Vector3(rect.Left + thickness, rect.Top, 0),
                new Vector3(rect.Left, rect.Bottom, 0),
                new Vector3(rect.Left + thickness, rect.Bottom, 0),
                color,
                ref verticesCount,
                ref indicesCount
            );

            // Right border: from (Right, Top) to (Right, Bottom) with thickness leftward
            AddQuadVerts(
                new Vector3(rect.Right - thickness, rect.Top, 0),
                new Vector3(rect.Right, rect.Top, 0),
                new Vector3(rect.Right - thickness, rect.Bottom, 0),
                new Vector3(rect.Right, rect.Bottom, 0),
                color,
                ref verticesCount,
                ref indicesCount
            );

            FlushBatch(verticesCount, indicesCount);
        }

        /// <summary>
        /// Add a draw call to the list
        /// </summary>
        /// <param name="command"></param>
        protected void AddDrawCall(IDrawCommand command) {
            _drawCalls.Add(command);
        }

        /// <inheritdoc/>
        public virtual void DrawRect(Rectangle rect, int thickness, ColorVec color) {
            AddDrawCall(new DrawRectCommand(rect, color, thickness));
        }

        /// <inheritdoc/>
        public virtual void DrawRectFilled(Rectangle rect, ColorVec color) {
            AddDrawCall(new DrawRectFilledCommand(rect, color));
        }

        /// <inheritdoc/>
        public virtual void DrawTexture(ITexture texture, Rectangle destRect, RectangleF? uvs = null) {
            AddDrawCall(new DrawTextureCommand(texture, destRect, uvs.HasValue ? uvs.Value : new RectangleF(0, 0, 1, 1)));
        }

        /// <inheritdoc/>
        public virtual void DrawRing(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, ColorVec color) {
            AddDrawCall(new DrawRingCommand(center, innerRadius, outerRadius, startAngle, endAngle, segments, color));
        }

        /// <inheritdoc/>
        public virtual void DrawText(IFont font, string text, Rectangle dest, ColorVec color, TextOptions? options = null) {
            AddDrawCall(new DrawTextCommand(font, text, dest, color, options ?? new TextOptions()));
        }

        /// <inheritdoc/>
        public virtual void PushClipRect(Rectangle rect) {
            _clipRects.Add(rect);
            AddDrawCall(new DrawClipCommand(rect));
        }

        /// <inheritdoc/>
        public virtual void PopClipRect() {
            if (_clipRects.Count > 0) {
                _clipRects.RemoveAt(_clipRects.Count - 1);
                if (_clipRects.Count > 0) {
                    AddDrawCall(new DrawClipCommand(_clipRects[_clipRects.Count - 1]));
                }
            }
            AddDrawCall(new DrawClipCommand(null));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() {
            _vertexBuffer.Dispose();
            _indexBuffer.Dispose();
            _vertexArray.Dispose();
        }
    }
}
