using DatReaderWriter.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Contains information about merged textures for terrain rendering
    /// </summary>
    public class TextureMergeInfo {
        public TerrainTex TerrainBase { get; set; }
        public List<TerrainTex> TerrainOverlays { get; private set; }
        public List<TerrainAlphaMap> TerrainAlphaOverlays { get; private set; }
        public List<int> TerrainAlphaIndices { get; private set; }
        public List<Rotation> TerrainRotations { get; private set; }

        public TerrainTex RoadOverlay { get; set; }
        public List<RoadAlphaMap> RoadAlphaOverlays { get; private set; }
        public List<int> RoadAlphaIndices { get; private set; }
        public List<Rotation> RoadRotations { get; private set; }

        public List<uint> TerrainCodes { get; set; }

        public TextureMergeInfo() {
            TerrainOverlays = Enumerable.Repeat((TerrainTex)null, 3).ToList();
            TerrainAlphaOverlays = Enumerable.Repeat((TerrainAlphaMap)null, 3).ToList();
            TerrainRotations = Enumerable.Repeat(Rotation.Rot0, 3).ToList();
            TerrainAlphaIndices = Enumerable.Repeat(-1, 3).ToList();

            RoadAlphaOverlays = Enumerable.Repeat((RoadAlphaMap)null, 2).ToList();
            RoadRotations = Enumerable.Repeat(Rotation.Rot0, 2).ToList();
            RoadAlphaIndices = Enumerable.Repeat(-1, 2).ToList();
        }

        /// <summary>
        /// Cleans up null entries and adjusts list sizes after texture building
        /// </summary>
        public void PostProcessing() {
            // Clean up terrain data
            TerrainOverlays = TerrainOverlays.Where(t => t != null).ToList();
            TerrainAlphaOverlays = TerrainAlphaOverlays.Where(t => t != null).ToList();
            var terrainCount = TerrainOverlays.Count;
            TerrainRotations.RemoveRange(terrainCount, Math.Max(0, 3 - terrainCount));
            TerrainAlphaIndices = TerrainAlphaIndices.Where(t => t != -1).ToList();

            // Clean up road data
            RoadAlphaOverlays = RoadAlphaOverlays.Where(r => r != null).ToList();
            var roadCount = RoadAlphaOverlays.Count;
            RoadRotations.RemoveRange(roadCount, Math.Max(0, 2 - roadCount));
            RoadAlphaIndices = RoadAlphaIndices.Where(r => r != -1).ToList();
        }

        /// <summary>
        /// Outputs debug information about the texture merge
        /// </summary>
        public void PrintDebugInfo() {
            Console.WriteLine($"TerrainBase: {TerrainBase?.TexGID:X8}");
            Console.WriteLine($"TerrainOverlays: {string.Join(",", TerrainOverlays.Where(t => t != null).Select(t => t.TexGID.ToString("X8")))}");
            Console.WriteLine($"TerrainAlphaOverlays: {string.Join(",", TerrainAlphaOverlays.Where(t => t != null).Select(t => t.TexGID.ToString("X8")))}");
            Console.WriteLine($"TerrainAlphaIndices: {string.Join(",", TerrainAlphaIndices)}");
            Console.WriteLine($"TerrainRotations: {string.Join(",", TerrainRotations.Select(r => (int)r))}");
            Console.WriteLine($"TerrainCodes: {string.Join(",", TerrainCodes?.Select(c => (SideCorner)c) ?? new SideCorner[0])}");
        }

        #region Enums

        public enum RotationCorner {
            NW = 0, SW = 1, SE = 2, NE = 3
        }

        public enum SideCorner {
            None = 0, SW = 1, SE = 2, South = 3, NE = 4, East = 6,
            NW = 8, West = 9, North = 12
        }

        public enum AlphaIndex {
            None = -1, Southwest = 0, Southeast = 1, Northeast = 2,
            Northwest = 3, Side = 5
        }

        public enum Direction {
            Inside = 0x0, North = 0x1, South = 0x2, East = 0x3, West = 0x4,
            NorthWest = 0x5, SouthWest = 0x6, NorthEast = 0x7, SouthEast = 0x8,
            Unknown = 0x9
        }

        public enum WaterType {
            NotWater = 0x0, PartiallyWater = 0x1, EntirelyWater = 0x2
        }

        public enum Rotation {
            Rot0 = 0x0, Rot90 = 0x1, Rot180 = 0x2, Rot270 = 0x3
        }

        public enum PaletteType {
            SWTerrain = 0x0, SETerrain = 0x1, NETerrain = 0x2,
            NWTerrain = 0x3, Road = 0x4
        }

        #endregion
    }
}