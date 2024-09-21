namespace Launcher
{
    public partial class Launcher : Form
    {
        private readonly LaunchManager _launchManager;

        public Launcher()
        {
            InitializeComponent();
            _launchManager = new LaunchManager();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            _launchManager.Launch(ServerTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text);
        }
    }
}
