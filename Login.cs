using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamerSim
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void NoAccountTextLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox_Password.Text) || string.IsNullOrEmpty(TextBox_Username.Text))
            {
                MessageBox.Show("Please fill out both Username and Password fields.");
                return;
            }

            DataAccessUsers gameDB = new DataAccessUsers();
            string loginMessage = gameDB.Login(TextBox_Username.Text, TextBox_Password.Text);



            if (loginMessage.Contains("Logged In As "))
            {
                Player.CurrentPlayerName = TextBox_Username.Text;
                Player.CurrentPlayer = new Player
                {
                    X = 1,  // Starting column
                    Y = 1,  // Starting row
                    Health = 100,
                    // Other player properties...
                };
                MessageBox.Show(loginMessage);
       
                Admin admin = new Admin();
                admin.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(loginMessage);
            }
        }
    }
}
