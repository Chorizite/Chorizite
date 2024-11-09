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

        internal static SimpleLoginScreenModel LoadFrom(string dataDirectory, ILogger? log) {
            SimpleLoginScreenModel? model = null;
            
            var modelJsonPath = Path.Combine(dataDirectory, "simplelogin.json");
            if (File.Exists(modelJsonPath)) {
                try {
                    model = JsonSerializer.Deserialize(File.ReadAllText(modelJsonPath), SourceGenerationContext.Default.SimpleLoginScreenModel); 
                }
                catch (Exception ex) {
                    log?.LogError($"Error deserializing {modelJsonPath}: {ex.Message}");
                }
            }
            
            return model ?? new SimpleLoginScreenModel();
        }

        public SimpleLoginScreenModel() : base() {

        }

        public override void Init(string name) {
            base.Init(name);

            BindAction("launch", (evt, variants) => {
                CoreLauncherPlugin.Instance.LauncherBackend.LaunchClient(ClientPath.Value, Server.Value, Username.Value, Password.Value);
            });
        }

        public void Save(string dataDirectory, ILogger? log) {
            string jsonString = JsonSerializer.Serialize(this!, SourceGenerationContext.Default.SimpleLoginScreenModel);
            if (!Directory.Exists(dataDirectory)) {
                Directory.CreateDirectory(dataDirectory);
            }
            File.WriteAllText(Path.Combine(dataDirectory, "simplelogin.json"), jsonString);
        }

        public override void Dispose() {
            base.Dispose();
        }
    }
}
