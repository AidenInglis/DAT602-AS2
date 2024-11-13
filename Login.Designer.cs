namespace GamerSim
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoginTitleLabel = new System.Windows.Forms.Label();
            this.TextBox_Username = new System.Windows.Forms.TextBox();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.NoAccountTextLabel = new System.Windows.Forms.LinkLabel();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginTitleLabel
            // 
            this.LoginTitleLabel.AutoSize = true;
            this.LoginTitleLabel.Font = new System.Drawing.Font("Broadway", 20F);
            this.LoginTitleLabel.Location = new System.Drawing.Point(73, 109);
            this.LoginTitleLabel.Name = "LoginTitleLabel";
            this.LoginTitleLabel.Size = new System.Drawing.Size(275, 91);
            this.LoginTitleLabel.TabIndex = 10;
            this.LoginTitleLabel.Text = "Login";
            // 
            // TextBox_Username
            // 
            this.TextBox_Username.Location = new System.Drawing.Point(74, 274);
            this.TextBox_Username.Name = "TextBox_Username";
            this.TextBox_Username.Size = new System.Drawing.Size(652, 44);
            this.TextBox_Username.TabIndex = 11;
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.Location = new System.Drawing.Point(74, 413);
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.Size = new System.Drawing.Size(652, 44);
            this.TextBox_Password.TabIndex = 12;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(82, 219);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(173, 37);
            this.UsernameLabel.TabIndex = 13;
            this.UsernameLabel.Text = "Username:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(82, 373);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(167, 37);
            this.PasswordLabel.TabIndex = 14;
            this.PasswordLabel.Text = "Password:";
            // 
            // NoAccountTextLabel
            // 
            this.NoAccountTextLabel.AutoSize = true;
            this.NoAccountTextLabel.Location = new System.Drawing.Point(214, 493);
            this.NoAccountTextLabel.Name = "NoAccountTextLabel";
            this.NoAccountTextLabel.Size = new System.Drawing.Size(353, 37);
            this.NoAccountTextLabel.TabIndex = 15;
            this.NoAccountTextLabel.TabStop = true;
            this.NoAccountTextLabel.Text = "Don\'t have an account?";
            this.NoAccountTextLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.NoAccountTextLabel_LinkClicked);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(190, 598);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(383, 129);
            this.LoginButton.TabIndex = 16;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 871);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.NoAccountTextLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.TextBox_Password);
            this.Controls.Add(this.TextBox_Username);
            this.Controls.Add(this.LoginTitleLabel);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LoginTitleLabel;
        private System.Windows.Forms.TextBox TextBox_Username;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.LinkLabel NoAccountTextLabel;
        private System.Windows.Forms.Button LoginButton;
    }
}