namespace GamerSim
{
    partial class Register
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
            this.AddUser = new System.Windows.Forms.Button();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.textbox_email = new System.Windows.Forms.TextBox();
            this.textbox_username = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.textbox_password = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.RegisterLabel = new System.Windows.Forms.Label();
            this.LoginLinkLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddUser
            // 
            this.AddUser.Location = new System.Drawing.Point(295, 715);
            this.AddUser.Name = "AddUser";
            this.AddUser.Size = new System.Drawing.Size(192, 87);
            this.AddUser.TabIndex = 0;
            this.AddUser.Text = "Register";
            this.AddUser.UseVisualStyleBackColor = true;
            this.AddUser.Click += new System.EventHandler(this.AddUser_Click);
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(339, 201);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(97, 37);
            this.EmailLabel.TabIndex = 1;
            this.EmailLabel.Text = "Email";
            // 
            // textbox_email
            // 
            this.textbox_email.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textbox_email.Location = new System.Drawing.Point(110, 240);
            this.textbox_email.Multiline = true;
            this.textbox_email.Name = "textbox_email";
            this.textbox_email.Size = new System.Drawing.Size(581, 60);
            this.textbox_email.TabIndex = 4;
            // 
            // textbox_username
            // 
            this.textbox_username.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textbox_username.Location = new System.Drawing.Point(110, 396);
            this.textbox_username.Multiline = true;
            this.textbox_username.Name = "textbox_username";
            this.textbox_username.Size = new System.Drawing.Size(581, 60);
            this.textbox_username.TabIndex = 6;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(311, 356);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(164, 37);
            this.UsernameLabel.TabIndex = 5;
            this.UsernameLabel.Text = "Username";
            // 
            // textbox_password
            // 
            this.textbox_password.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textbox_password.Location = new System.Drawing.Point(110, 557);
            this.textbox_password.Multiline = true;
            this.textbox_password.Name = "textbox_password";
            this.textbox_password.PasswordChar = '*';
            this.textbox_password.Size = new System.Drawing.Size(581, 60);
            this.textbox_password.TabIndex = 8;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(311, 517);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(158, 37);
            this.PasswordLabel.TabIndex = 7;
            this.PasswordLabel.Text = "Password";
            // 
            // RegisterLabel
            // 
            this.RegisterLabel.AutoSize = true;
            this.RegisterLabel.Font = new System.Drawing.Font("Broadway", 20F);
            this.RegisterLabel.Location = new System.Drawing.Point(43, 34);
            this.RegisterLabel.Name = "RegisterLabel";
            this.RegisterLabel.Size = new System.Drawing.Size(385, 91);
            this.RegisterLabel.TabIndex = 9;
            this.RegisterLabel.Text = "Register";
            // 
            // LoginLinkLabel
            // 
            this.LoginLinkLabel.AutoSize = true;
            this.LoginLinkLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoginLinkLabel.Location = new System.Drawing.Point(258, 662);
            this.LoginLinkLabel.Name = "LoginLinkLabel";
            this.LoginLinkLabel.Size = new System.Drawing.Size(278, 37);
            this.LoginLinkLabel.TabIndex = 10;
            this.LoginLinkLabel.Text = "Have an Account?";
            this.LoginLinkLabel.Click += new System.EventHandler(this.LoginLinkLabel_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 871);
            this.Controls.Add(this.LoginLinkLabel);
            this.Controls.Add(this.RegisterLabel);
            this.Controls.Add(this.textbox_password);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.textbox_username);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.textbox_email);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.AddUser);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddUser;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.TextBox textbox_email;
        private System.Windows.Forms.TextBox textbox_username;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox textbox_password;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label RegisterLabel;
        private System.Windows.Forms.Label LoginLinkLabel;
    }
}

