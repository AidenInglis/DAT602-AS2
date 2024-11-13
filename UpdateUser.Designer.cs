namespace GamerSim
{
    partial class UpdateUser
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.TextBox_UserName = new System.Windows.Forms.TextBox();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.TextBox_Email = new System.Windows.Forms.TextBox();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.Label_UserName = new System.Windows.Forms.Label();
            this.Label_Email = new System.Windows.Forms.Label();
            this.Label_Password = new System.Windows.Forms.Label();
            this.Label_UpdateUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(615, 374);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(161, 66);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TextBox_UserName
            // 
            this.TextBox_UserName.Location = new System.Drawing.Point(96, 116);
            this.TextBox_UserName.Name = "TextBox_UserName";
            this.TextBox_UserName.Size = new System.Drawing.Size(609, 44);
            this.TextBox_UserName.TabIndex = 1;
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.Location = new System.Drawing.Point(96, 203);
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.Size = new System.Drawing.Size(609, 44);
            this.TextBox_Password.TabIndex = 2;
            // 
            // TextBox_Email
            // 
            this.TextBox_Email.Location = new System.Drawing.Point(96, 295);
            this.TextBox_Email.Name = "TextBox_Email";
            this.TextBox_Email.Size = new System.Drawing.Size(609, 44);
            this.TextBox_Email.TabIndex = 3;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(12, 374);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(161, 66);
            this.Cancel_Button.TabIndex = 4;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Label_UserName
            // 
            this.Label_UserName.AutoSize = true;
            this.Label_UserName.Location = new System.Drawing.Point(109, 76);
            this.Label_UserName.Name = "Label_UserName";
            this.Label_UserName.Size = new System.Drawing.Size(179, 37);
            this.Label_UserName.TabIndex = 5;
            this.Label_UserName.Text = "UserName:";
            // 
            // Label_Email
            // 
            this.Label_Email.AutoSize = true;
            this.Label_Email.Location = new System.Drawing.Point(109, 255);
            this.Label_Email.Name = "Label_Email";
            this.Label_Email.Size = new System.Drawing.Size(106, 37);
            this.Label_Email.TabIndex = 6;
            this.Label_Email.Text = "Email:";
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.Location = new System.Drawing.Point(109, 163);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(167, 37);
            this.Label_Password.TabIndex = 7;
            this.Label_Password.Text = "Password:";
            // 
            // Label_UpdateUser
            // 
            this.Label_UpdateUser.AutoSize = true;
            this.Label_UpdateUser.Location = new System.Drawing.Point(285, 9);
            this.Label_UpdateUser.Name = "Label_UpdateUser";
            this.Label_UpdateUser.Size = new System.Drawing.Size(205, 37);
            this.Label_UpdateUser.TabIndex = 8;
            this.Label_UpdateUser.Text = "Update User:";
            // 
            // UpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Label_UpdateUser);
            this.Controls.Add(this.Label_Password);
            this.Controls.Add(this.Label_Email);
            this.Controls.Add(this.Label_UserName);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.TextBox_Email);
            this.Controls.Add(this.TextBox_Password);
            this.Controls.Add(this.TextBox_UserName);
            this.Controls.Add(this.SaveButton);
            this.Name = "UpdateUser";
            this.Text = "UpdateUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox TextBox_UserName;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.TextBox TextBox_Email;
        private System.Windows.Forms.Button Cancel_Button;
        private System.Windows.Forms.Label Label_UserName;
        private System.Windows.Forms.Label Label_Email;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.Label Label_UpdateUser;
    }
}