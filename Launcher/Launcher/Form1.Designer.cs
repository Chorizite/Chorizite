namespace Launcher
{
    partial class Launcher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ServerTextBox = new TextBox();
            ServerLabel = new Label();
            UsernameLabel = new Label();
            UsernameTextBox = new TextBox();
            PasswordLabel = new Label();
            PasswordTextBox = new TextBox();
            LaunchButton = new Button();
            SuspendLayout();
            // 
            // ServerTextBox
            // 
            ServerTextBox.Location = new Point(75, 23);
            ServerTextBox.Name = "ServerTextBox";
            ServerTextBox.Size = new Size(208, 23);
            ServerTextBox.TabIndex = 0;
            ServerTextBox.Text = "play.coldeve.ac:9000";
            // 
            // ServerLabel
            // 
            ServerLabel.AutoSize = true;
            ServerLabel.Location = new Point(8, 26);
            ServerLabel.Name = "ServerLabel";
            ServerLabel.Size = new Size(42, 15);
            ServerLabel.TabIndex = 1;
            ServerLabel.Text = "Server:";
            ServerLabel.Click += label1_Click;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(8, 64);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(63, 15);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username:";
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(75, 61);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(208, 23);
            UsernameTextBox.TabIndex = 3;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(8, 98);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(60, 15);
            PasswordLabel.TabIndex = 4;
            PasswordLabel.Text = "Password:";
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(75, 98);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.PasswordChar = '*';
            PasswordTextBox.Size = new Size(208, 23);
            PasswordTextBox.TabIndex = 5;
            // 
            // LaunchButton
            // 
            LaunchButton.Location = new Point(8, 132);
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Size = new Size(275, 23);
            LaunchButton.TabIndex = 6;
            LaunchButton.Text = "Launch";
            LaunchButton.UseVisualStyleBackColor = true;
            LaunchButton.Click += LaunchButton_Click;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 166);
            Controls.Add(LaunchButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(PasswordLabel);
            Controls.Add(UsernameTextBox);
            Controls.Add(UsernameLabel);
            Controls.Add(ServerLabel);
            Controls.Add(ServerTextBox);
            Name = "Launcher";
            Text = "Launcher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ServerTextBox;
        private Label ServerLabel;
        private Label UsernameLabel;
        private TextBox UsernameTextBox;
        private Label PasswordLabel;
        private TextBox PasswordTextBox;
        private Button LaunchButton;
    }
}
