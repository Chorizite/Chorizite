using Core.UI.Lib.Serialization;
using Core.UI.Models;
using Chorizite.Core.Net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Launcher.UIModels {
    [JsonConverter(typeof(UIDataModelJsonConverter))]
    public class SimpleLoginScreenModel : UIDataModel {
        public DataVariable<string> Username { get; } = new("");
        public DataVariable<string> Password { get; } = new("");
        public DataVariable<string> ClientPath { get; } = new(@"C:\Turbine\Asheron's Call\acclient.exe");
        public DataVariable<string> Server { get; } = new("play.coldeve.ac:9000");

        public SimpleLoginScreenModel() : base() {

        }

        public override void Init(string name) {
            base.Init(name);

            BindAction("launch", (evt, variants) => {
                CoreLauncherPlugin.Instance?.LauncherBackend.LaunchClient(ClientPath.Value, Server.Value, Username.Value, Password.Value);
            });

            BindAction("test", (evt, variants) => {
                CoreLauncherPlugin.Log?.LogDebug("test");
            });

            BindAction("exit", (evt, variants) => {
                CoreLauncherPlugin.Instance?.LauncherBackend.Exit();
            });

            BindAction("minimize", (evt, variants) => {
                CoreLauncherPlugin.Instance?.LauncherBackend.Minimize();
            });
        }

        public override void Dispose() {
            base.Dispose();
        }
    }
}
