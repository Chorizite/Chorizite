using Core.AC.Lib.Screens;
using Core.AC.UIModels;

namespace Core.AC.Lib {
    internal class ACState {
        public GameScreen CurrentScreen { get; set; } = GameScreen.None;

        public CharSelectScreenModel CharSelectModel { get; set; }
        public DatPatchScreenModel DatPatchModel { get; set; }
    }
}