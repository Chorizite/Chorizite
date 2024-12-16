using Core.AC.API;
using Core.AC.Lib.Screens;
using Core.AC.UIModels;

namespace Core.AC.Lib {
    internal class PluginState {
        public GameScreen CurrentScreen { get; set; } = GameScreen.None;
        public CharSelectScreenModel CharSelectModel { get; set; }
        public TooltipModel TooltipModel { get; set; }
        public Game Game { get; set; }
    }
}