namespace GamerSim
{
    partial class Admin
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
            this.label_lobby = new System.Windows.Forms.Label();
            this.label_allPlayers = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_wins = new System.Windows.Forms.Label();
            this.button_createUser = new System.Windows.Forms.Button();
            this.button_updateUser = new System.Windows.Forms.Button();
            this.button_deleteUser = new System.Windows.Forms.Button();
            this.button_joinGame = new System.Windows.Forms.Button();
            this.button_endGame = new System.Windows.Forms.Button();
            this.label_player = new System.Windows.Forms.Label();
            this.label_map = new System.Windows.Forms.Label();
            this.label_activeGames = new System.Windows.Forms.Label();
            this.label_loggedIn = new System.Windows.Forms.Label();
            this.Button_logOut = new System.Windows.Forms.Button();
            this.label_user = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton_map1 = new System.Windows.Forms.RadioButton();
            this.radioButton_map2 = new System.Windows.Forms.RadioButton();
            this.button_createGame = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Admin_Panel = new System.Windows.Forms.Panel();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.UserDelete_Panel = new System.Windows.Forms.Panel();
            this.UserDelete = new System.Windows.Forms.Button();
            this.GameListBox = new System.Windows.Forms.ListBox();
            this.Admin_Panel.SuspendLayout();
            this.UserDelete_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_lobby
            // 
            this.label_lobby.AutoSize = true;
            this.label_lobby.Font = new System.Drawing.Font("Broadway", 30F);
            this.label_lobby.Location = new System.Drawing.Point(127, 62);
            this.label_lobby.Name = "label_lobby";
            this.label_lobby.Size = new System.Drawing.Size(461, 136);
            this.label_lobby.TabIndex = 0;
            this.label_lobby.Text = "Lobby";
            // 
            // label_allPlayers
            // 
            this.label_allPlayers.AutoSize = true;
            this.label_allPlayers.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_allPlayers.Font = new System.Drawing.Font("Broadway", 12F);
            this.label_allPlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_allPlayers.Location = new System.Drawing.Point(28, 292);
            this.label_allPlayers.Name = "label_allPlayers";
            this.label_allPlayers.Size = new System.Drawing.Size(319, 55);
            this.label_allPlayers.TabIndex = 2;
            this.label_allPlayers.Text = "All Players:";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_username.Location = new System.Drawing.Point(30, 391);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(214, 46);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username:";
            // 
            // label_wins
            // 
            this.label_wins.AutoSize = true;
            this.label_wins.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_wins.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_wins.Location = new System.Drawing.Point(407, 384);
            this.label_wins.Name = "label_wins";
            this.label_wins.Size = new System.Drawing.Size(120, 46);
            this.label_wins.TabIndex = 4;
            this.label_wins.Text = "Wins:";
            // 
            // button_createUser
            // 
            this.button_createUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_createUser.Location = new System.Drawing.Point(23, 34);
            this.button_createUser.Name = "button_createUser";
            this.button_createUser.Size = new System.Drawing.Size(244, 72);
            this.button_createUser.TabIndex = 5;
            this.button_createUser.Text = "Create User";
            this.button_createUser.UseVisualStyleBackColor = false;
            this.button_createUser.Click += new System.EventHandler(this.Button_createUser_Click);
            // 
            // button_updateUser
            // 
            this.button_updateUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_updateUser.Location = new System.Drawing.Point(23, 132);
            this.button_updateUser.Name = "button_updateUser";
            this.button_updateUser.Size = new System.Drawing.Size(244, 72);
            this.button_updateUser.TabIndex = 6;
            this.button_updateUser.Text = "Update User";
            this.button_updateUser.UseVisualStyleBackColor = false;
            this.button_updateUser.Click += new System.EventHandler(this.Button_updateUser_Click);
            // 
            // button_deleteUser
            // 
            this.button_deleteUser.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_deleteUser.Location = new System.Drawing.Point(23, 220);
            this.button_deleteUser.Name = "button_deleteUser";
            this.button_deleteUser.Size = new System.Drawing.Size(244, 72);
            this.button_deleteUser.TabIndex = 7;
            this.button_deleteUser.Text = "Delete User";
            this.button_deleteUser.UseVisualStyleBackColor = false;
            this.button_deleteUser.Click += new System.EventHandler(this.Button_deleteUser_Click);
            // 
            // button_joinGame
            // 
            this.button_joinGame.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_joinGame.Location = new System.Drawing.Point(1338, 872);
            this.button_joinGame.Name = "button_joinGame";
            this.button_joinGame.Size = new System.Drawing.Size(220, 72);
            this.button_joinGame.TabIndex = 9;
            this.button_joinGame.Text = "Join Game";
            this.button_joinGame.UseVisualStyleBackColor = false;
            this.button_joinGame.Click += new System.EventHandler(this.Button_joinGame_Click);
            // 
            // button_endGame
            // 
            this.button_endGame.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button_endGame.FlatAppearance.BorderSize = 0;
            this.button_endGame.Location = new System.Drawing.Point(608, 39);
            this.button_endGame.Name = "button_endGame";
            this.button_endGame.Size = new System.Drawing.Size(220, 72);
            this.button_endGame.TabIndex = 8;
            this.button_endGame.Text = "End Game";
            this.button_endGame.UseVisualStyleBackColor = false;
            this.button_endGame.Click += new System.EventHandler(this.Button_endGame_Click);
            // 
            // label_player
            // 
            this.label_player.AutoSize = true;
            this.label_player.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_player.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_player.Location = new System.Drawing.Point(2026, 395);
            this.label_player.Name = "label_player";
            this.label_player.Size = new System.Drawing.Size(164, 46);
            this.label_player.TabIndex = 12;
            this.label_player.Text = "Players:";
            // 
            // label_map
            // 
            this.label_map.AutoSize = true;
            this.label_map.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_map.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_map.Location = new System.Drawing.Point(1670, 395);
            this.label_map.Name = "label_map";
            this.label_map.Size = new System.Drawing.Size(108, 46);
            this.label_map.TabIndex = 11;
            this.label_map.Text = "Map:";
            // 
            // label_activeGames
            // 
            this.label_activeGames.AutoSize = true;
            this.label_activeGames.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_activeGames.Font = new System.Drawing.Font("Broadway", 12F);
            this.label_activeGames.Location = new System.Drawing.Point(1668, 291);
            this.label_activeGames.Name = "label_activeGames";
            this.label_activeGames.Size = new System.Drawing.Size(393, 55);
            this.label_activeGames.TabIndex = 10;
            this.label_activeGames.Text = "Active Games:";
            // 
            // label_loggedIn
            // 
            this.label_loggedIn.AutoSize = true;
            this.label_loggedIn.Font = new System.Drawing.Font("Broadway", 12F);
            this.label_loggedIn.Location = new System.Drawing.Point(1919, 131);
            this.label_loggedIn.Name = "label_loggedIn";
            this.label_loggedIn.Size = new System.Drawing.Size(291, 55);
            this.label_loggedIn.TabIndex = 13;
            this.label_loggedIn.Text = "Username";
            // 
            // Button_logOut
            // 
            this.Button_logOut.Location = new System.Drawing.Point(2032, 31);
            this.Button_logOut.Name = "Button_logOut";
            this.Button_logOut.Size = new System.Drawing.Size(186, 72);
            this.Button_logOut.TabIndex = 14;
            this.Button_logOut.Text = "Log Out";
            this.Button_logOut.UseVisualStyleBackColor = true;
            this.Button_logOut.Click += new System.EventHandler(this.Button_logOut_Click);
            // 
            // label_user
            // 
            this.label_user.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_user.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label_user.Location = new System.Drawing.Point(1, 276);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(645, 802);
            this.label_user.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Location = new System.Drawing.Point(1620, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(645, 802);
            this.label8.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label9.Location = new System.Drawing.Point(676, 872);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(486, 206);
            this.label9.TabIndex = 17;
            // 
            // radioButton_map1
            // 
            this.radioButton_map1.AutoSize = true;
            this.radioButton_map1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButton_map1.Location = new System.Drawing.Point(712, 912);
            this.radioButton_map1.Name = "radioButton_map1";
            this.radioButton_map1.Size = new System.Drawing.Size(174, 50);
            this.radioButton_map1.TabIndex = 18;
            this.radioButton_map1.TabStop = true;
            this.radioButton_map1.Text = "Map 1";
            this.radioButton_map1.UseVisualStyleBackColor = true;
            // 
            // radioButton_map2
            // 
            this.radioButton_map2.AutoSize = true;
            this.radioButton_map2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton_map2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButton_map2.Location = new System.Drawing.Point(942, 912);
            this.radioButton_map2.Name = "radioButton_map2";
            this.radioButton_map2.Size = new System.Drawing.Size(174, 50);
            this.radioButton_map2.TabIndex = 19;
            this.radioButton_map2.TabStop = true;
            this.radioButton_map2.Text = "Map 2";
            this.radioButton_map2.UseVisualStyleBackColor = false;
            // 
            // button_createGame
            // 
            this.button_createGame.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_createGame.Location = new System.Drawing.Point(712, 987);
            this.button_createGame.Name = "button_createGame";
            this.button_createGame.Size = new System.Drawing.Size(404, 72);
            this.button_createGame.TabIndex = 20;
            this.button_createGame.Text = "Create Game";
            this.button_createGame.UseVisualStyleBackColor = false;
            this.button_createGame.Click += new System.EventHandler(this.Button_createGame_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.Font = new System.Drawing.Font("Broadway", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(495, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 55);
            this.label7.TabIndex = 27;
            this.label7.Text = "( 2 )";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label10.Font = new System.Drawing.Font("Broadway", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(2125, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 55);
            this.label10.TabIndex = 28;
            this.label10.Text = "( 1 )";
            // 
            // Admin_Panel
            // 
            this.Admin_Panel.Controls.Add(this.button_deleteUser);
            this.Admin_Panel.Controls.Add(this.button_updateUser);
            this.Admin_Panel.Controls.Add(this.button_createUser);
            this.Admin_Panel.Controls.Add(this.button_endGame);
            this.Admin_Panel.Location = new System.Drawing.Point(712, 237);
            this.Admin_Panel.Name = "Admin_Panel";
            this.Admin_Panel.Size = new System.Drawing.Size(846, 603);
            this.Admin_Panel.TabIndex = 29;
            // 
            // PlayerListBox
            // 
            this.PlayerListBox.FormattingEnabled = true;
            this.PlayerListBox.ItemHeight = 37;
            this.PlayerListBox.Location = new System.Drawing.Point(38, 449);
            this.PlayerListBox.Name = "PlayerListBox";
            this.PlayerListBox.Size = new System.Drawing.Size(568, 596);
            this.PlayerListBox.TabIndex = 30;
            // 
            // UserDelete_Panel
            // 
            this.UserDelete_Panel.Controls.Add(this.UserDelete);
            this.UserDelete_Panel.Location = new System.Drawing.Point(1570, 31);
            this.UserDelete_Panel.Name = "UserDelete_Panel";
            this.UserDelete_Panel.Size = new System.Drawing.Size(412, 89);
            this.UserDelete_Panel.TabIndex = 31;
            // 
            // UserDelete
            // 
            this.UserDelete.Location = new System.Drawing.Point(45, 5);
            this.UserDelete.Name = "UserDelete";
            this.UserDelete.Size = new System.Drawing.Size(320, 67);
            this.UserDelete.TabIndex = 0;
            this.UserDelete.Text = "Delete Account";
            this.UserDelete.UseVisualStyleBackColor = true;
            this.UserDelete.Click += new System.EventHandler(this.UserDelete_Click);
            // 
            // GameListBox
            // 
            this.GameListBox.FormattingEnabled = true;
            this.GameListBox.ItemHeight = 37;
            this.GameListBox.Location = new System.Drawing.Point(1647, 452);
            this.GameListBox.Name = "GameListBox";
            this.GameListBox.Size = new System.Drawing.Size(592, 596);
            this.GameListBox.TabIndex = 32;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2266, 1080);
            this.Controls.Add(this.GameListBox);
            this.Controls.Add(this.UserDelete_Panel);
            this.Controls.Add(this.PlayerListBox);
            this.Controls.Add(this.button_joinGame);
            this.Controls.Add(this.Admin_Panel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_createGame);
            this.Controls.Add(this.radioButton_map2);
            this.Controls.Add(this.radioButton_map1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Button_logOut);
            this.Controls.Add(this.label_loggedIn);
            this.Controls.Add(this.label_player);
            this.Controls.Add(this.label_map);
            this.Controls.Add(this.label_activeGames);
            this.Controls.Add(this.label_wins);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.label_allPlayers);
            this.Controls.Add(this.label_lobby);
            this.Controls.Add(this.label_user);
            this.Controls.Add(this.label8);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.Admin_Panel.ResumeLayout(false);
            this.UserDelete_Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_lobby;
        private System.Windows.Forms.Label label_allPlayers;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_wins;
        private System.Windows.Forms.Button button_createUser;
        private System.Windows.Forms.Button button_updateUser;
        private System.Windows.Forms.Button button_deleteUser;
        private System.Windows.Forms.Button button_joinGame;
        private System.Windows.Forms.Button button_endGame;
        private System.Windows.Forms.Label label_player;
        private System.Windows.Forms.Label label_map;
        private System.Windows.Forms.Label label_activeGames;
        private System.Windows.Forms.Label label_loggedIn;
        private System.Windows.Forms.Button Button_logOut;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton_map1;
        private System.Windows.Forms.RadioButton radioButton_map2;
        private System.Windows.Forms.Button button_createGame;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Panel Admin_Panel;
        private System.Windows.Forms.ListBox PlayerListBox;
        private System.Windows.Forms.Panel UserDelete_Panel;
        private System.Windows.Forms.Button UserDelete;
        private System.Windows.Forms.ListBox GameListBox;
    }
}