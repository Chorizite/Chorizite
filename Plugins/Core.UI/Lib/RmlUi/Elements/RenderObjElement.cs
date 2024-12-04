using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Globalization;
using System.Linq;

namespace Core.UI.Lib.RmlUi.Elements {
    public class RenderObjElement : ElementCustom {
        private IChoriziteBackend _backend;
        private ILogger _log;
        private IDatReaderInterface _dat;
        private uint _dataId;

        public RenderObjElement(IChoriziteBackend backend, IDatReaderInterface dat, ILogger log, XMLAttributes attributes) : base("renderobj") {
            _backend = backend;
            _log = log;
            _dat = dat;

            var did = attributes.GetString("did");
            _log.LogDebug($"Creating RenderObjElement {did}");

            if (did.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase)) {
                did = did.Substring(2);
            }

            if (uint.TryParse(did, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out uint dataId)) {
                _dataId = dataId;
            }
            else {
                _log.LogError("Invalid renderobj did: {0}", did);
            }

            /*
            try {
                LoadSetupOrGfxObj(_dataId);
            }
            catch (Exception ex) {
                _log.LogError(ex, $"Error loading DataId: {_dataId:X8}: {ex.Message}");
            }
            */
        }

        /*
        private void LoadSetupOrGfxObj(uint dataId) {
            if ((dataId & 0x02000000) != 0x02000000) {
                LoadSetup(dataId);
            }
            else if ((dataId & 0x01000000) == 0x01000000) {
                LoadGfxObj(dataId);
            }
        }

        private void LoadSetup(uint dataId) {
            if (!_dat.TryGet<Setup>(dataId, out var setupModel)) {
                throw new Exception($"Failed to load Setup: {dataId:X8}");
            }

            for (var i = 0; i < setupModel!.Parts.Count; i++) {
                LoadGfxObj(setupModel.Parts[i], setupModel.PlacementFrames[0].Frames[i]);
            }
        }

        private void LoadGfxObj(uint dataId, Frame? frame = null) {
            if (!_dat.TryGet<GfxObj>(dataId, out var gfxObj)) {
                throw new Exception($"Failed to load GfxObj: {dataId:X8}");
            }
            foreach (var pkv in gfxObj!.Polygons) {
                var vertices = pkv.Value.VertexIds.Select(v => gfxObj.VertexArray.Vertices[(ushort)v].Origin).ToList();
            }
        }
        */

        internal void Update() {

        }

        public override void OnRender() {
            base.OnRender();
        }

        public override void Dispose() {
            base.Dispose();
        }
    }
}
