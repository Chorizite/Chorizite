using Core.Launcher.UIModels;

namespace Core.Launcher.Lib {
    internal class LauncherSettings {
        public SimpleLoginScreenModel SimpleLoginScreenModel { get; set; }

        public LauncherSettings() {

        }

        public LauncherSettings(SimpleLoginScreenModel simpleLoginScreenModel) {
            SimpleLoginScreenModel = simpleLoginScreenModel;
        }
    }
}