using System.Windows.Forms;

namespace GamerSim
{
    partial class Game
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
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_wins = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_allPlayers = new System.Windows.Forms.Label();
            this.Label_LeftBackground = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Label_RightBackground = new System.Windows.Forms.Label();
            this.MoveButton = new System.Windows.Forms.Button();
            this.AttackButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.NextTurnButton = new System.Windows.Forms.Button();
            this.Game_Board_Panel = new System.Windows.Forms.Panel();
            this.Game_Board_DataGridView = new System.Windows.Forms.DataGridView();
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.Game_Board_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Game_Board_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label7.Font = new System.Drawing.Font("Broadway", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(515, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 55);
            this.label7.TabIndex = 34;
            this.label7.Text = "( 2 )";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(349, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 46);
            this.label3.TabIndex = 33;
            this.label3.Text = "Health";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(60, 433);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 46);
            this.label2.TabIndex = 32;
            this.label2.Text = "Armor";
            // 
            // label_wins
            // 
            this.label_wins.AutoSize = true;
            this.label_wins.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_wins.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_wins.Location = new System.Drawing.Point(343, 335);
            this.label_wins.Name = "label_wins";
            this.label_wins.Size = new System.Drawing.Size(134, 46);
            this.label_wins.TabIndex = 30;
            this.label_wins.Text = "Effect:";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label_username.Location = new System.Drawing.Point(50, 335);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(137, 46);
            this.label_username.TabIndex = 29;
            this.label_username.Text = "Name:";
            // 
            // label_allPlayers
            // 
            this.label_allPlayers.AutoSize = true;
            this.label_allPlayers.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label_allPlayers.Font = new System.Drawing.Font("Broadway", 12F);
            this.label_allPlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_allPlayers.Location = new System.Drawing.Point(48, 236);
            this.label_allPlayers.Name = "label_allPlayers";
            this.label_allPlayers.Size = new System.Drawing.Size(190, 55);
            this.label_allPlayers.TabIndex = 28;
            this.label_allPlayers.Text = "Items:";
            // 
            // Label_LeftBackground
            // 
            this.Label_LeftBackground.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Label_LeftBackground.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label_LeftBackground.Location = new System.Drawing.Point(21, 220);
            this.Label_LeftBackground.Name = "Label_LeftBackground";
            this.Label_LeftBackground.Size = new System.Drawing.Size(762, 802);
            this.Label_LeftBackground.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(35, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(706, 83);
            this.label1.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(581, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 46);
            this.label4.TabIndex = 36;
            this.label4.Text = "Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(606, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 46);
            this.label5.TabIndex = 37;
            this.label5.Text = "+2";
            // 
            // Label_RightBackground
            // 
            this.Label_RightBackground.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Label_RightBackground.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Label_RightBackground.Location = new System.Drawing.Point(827, 220);
            this.Label_RightBackground.Name = "Label_RightBackground";
            this.Label_RightBackground.Size = new System.Drawing.Size(1342, 802);
            this.Label_RightBackground.TabIndex = 42;
            // 
            // MoveButton
            // 
            this.MoveButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MoveButton.Location = new System.Drawing.Point(886, 273);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(244, 72);
            this.MoveButton.TabIndex = 43;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = false;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // AttackButton
            // 
            this.AttackButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.AttackButton.Location = new System.Drawing.Point(886, 481);
            this.AttackButton.Name = "AttackButton";
            this.AttackButton.Size = new System.Drawing.Size(244, 72);
            this.AttackButton.TabIndex = 45;
            this.AttackButton.Text = "Attack";
            this.AttackButton.UseVisualStyleBackColor = false;
            this.AttackButton.Click += new System.EventHandler(this.AttackButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.QuitButton.Location = new System.Drawing.Point(1907, 92);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(244, 72);
            this.QuitButton.TabIndex = 47;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("Broadway", 20F);
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(45, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(531, 91);
            this.label12.TabIndex = 48;
            this.label12.Text = "( 3 ) Players";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("Broadway", 20F);
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(670, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(485, 91);
            this.label13.TabIndex = 49;
            this.label13.Text = "Your Turn";
            // 
            // NextTurnButton
            // 
            this.NextTurnButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.NextTurnButton.Location = new System.Drawing.Point(23, 1051);
            this.NextTurnButton.Name = "NextTurnButton";
            this.NextTurnButton.Size = new System.Drawing.Size(244, 72);
            this.NextTurnButton.TabIndex = 50;
            this.NextTurnButton.Text = "Next Turn";
            this.NextTurnButton.UseVisualStyleBackColor = false;
            // 
            // Game_Board_Panel
            // 
            this.Game_Board_Panel.Controls.Add(this.Game_Board_DataGridView);
            this.Game_Board_Panel.Location = new System.Drawing.Point(1232, 237);
            this.Game_Board_Panel.Name = "Game_Board_Panel";
            this.Game_Board_Panel.Size = new System.Drawing.Size(865, 763);
            this.Game_Board_Panel.TabIndex = 51;
            // 
            // Game_Board_DataGridView
            // 
            this.Game_Board_DataGridView.AllowUserToResizeColumns = false;
            this.Game_Board_DataGridView.AllowUserToResizeRows = false;
            this.Game_Board_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Game_Board_DataGridView.ColumnHeadersVisible = false;
            this.Game_Board_DataGridView.Location = new System.Drawing.Point(19, 17);
            this.Game_Board_DataGridView.MultiSelect = false;
            this.Game_Board_DataGridView.Name = "Game_Board_DataGridView";
            this.Game_Board_DataGridView.ReadOnly = true;
            this.Game_Board_DataGridView.RowHeadersVisible = false;
            this.Game_Board_DataGridView.RowHeadersWidth = 123;
            this.Game_Board_DataGridView.RowTemplate.Height = 46;
            this.Game_Board_DataGridView.Size = new System.Drawing.Size(829, 729);
            this.Game_Board_DataGridView.TabIndex = 0;
            this.Game_Board_DataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GameBoard_CellClick);
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.ItemHeight = 37;
            this.ItemsListBox.Location = new System.Drawing.Point(28, 529);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(755, 448);
            this.ItemsListBox.TabIndex = 52;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2189, 1144);
            this.Controls.Add(this.ItemsListBox);
            this.Controls.Add(this.Game_Board_Panel);
            this.Controls.Add(this.NextTurnButton);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.AttackButton);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.Label_RightBackground);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_wins);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.label_allPlayers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label_LeftBackground);
            this.MaximumSize = new System.Drawing.Size(2422, 1247);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.Game_Board_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Game_Board_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_wins;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_allPlayers;
        private System.Windows.Forms.Label Label_LeftBackground;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Label_RightBackground;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button AttackButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button NextTurnButton;
        private System.Windows.Forms.Panel Game_Board_Panel;
        private System.Windows.Forms.DataGridView Game_Board_DataGridView;
        private ListBox ItemsListBox;
    }
}