namespace Launcher.Lib {
    internal class LauncherSettings {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ClientPath { get; set; } = @"C:\Turbine\Asheron's Call\acclient.exe";
        public string Server { get; set; } = "play.coldeve.ac:9000";

        public LauncherSettings() {

        }
    }
}