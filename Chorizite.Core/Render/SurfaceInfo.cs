namespace Chorizite.Core.Render {
    /// <summary>
    /// Information about a surface used for terrain rendering
    /// </summary>
    public class SurfaceInfo {
        public uint PaletteCode { get; set; }
        public uint LandCellCount { get; set; }
        public TextureMergeInfo Surface { get; set; }
        public uint SurfaceNumber { get; set; }

        public SurfaceInfo() {
            LandCellCount = 0;
        }
    }
}