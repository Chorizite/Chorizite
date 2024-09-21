using System.Text.Json;

namespace Launcher
{
    public partial class Launcher : Form
    {
        private Settings _settings = null;
        private readonly LaunchManager _launchManager;

        public Launcher()
        {
            InitializeComponent();
            if (File.Exists("settings.json")) {
                _settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText("settings.json"));
            }
            
            if (_settings is null) {
                _settings = new Settings();
                _settings.Host = "play.coldeve.ac:9000";
            }

            ServerTextBox.Text = _settings.Host ?? "play.coldeve.ac:9000";
            UsernameTextBox.Text = _settings.Username ?? "";
            PasswordTextBox.Text = _settings.Password ?? "";

            _launchManager = new LaunchManager();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            _settings.Host = ServerTextBox.Text;
            _settings.Username = UsernameTextBox.Text;
            _settings.Password = PasswordTextBox.Text;
            File.WriteAllText("settings.json", JsonSerializer.Serialize(_settings));
            _launchManager.Launch(ServerTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text);
        }
    }
}
