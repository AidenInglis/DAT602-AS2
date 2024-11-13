using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamerSim
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

            DataAccessGame dataAccessGame = new DataAccessGame();
            string result = dataAccessGame.DBConnection();
            MessageBox.Show(result);
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_password.Text) || string.IsNullOrEmpty(textbox_username.Text) || string.IsNullOrEmpty(textbox_email.Text))
            {
                MessageBox.Show("Please fill out both Username, Password and Email fields.");
                return;
            }

            DataAccessUsers gameDB = new DataAccessUsers();
            string result = gameDB.AddUserName(textbox_username.Text, textbox_password.Text, textbox_email.Text);

            if (result == "ADDED USER NAME")
            {
                Login login = new Login();
                this.Close();
                login.Show();
                MessageBox.Show("Registration successful! Redirecting to the login...");
            }
            else if (result == "USERNAME EXISTS")
            {
                MessageBox.Show("The username already exists. Please choose another one.");
            }
            else if (result == "EMAIL ALREADY USED")
            {
                MessageBox.Show("The email already exists. Please use another one.");
            }
            else if (result == "EMAIL ALREADY USED")
            {
                MessageBox.Show("The email already exists. Please use another one.");
            }else if (result == "ALL FIELDS REQUIRE AT LEAST FIVE CHARACTERS")
            {
                MessageBox.Show("Not enough characters in each field, five are required in each");
            }
            else
            {
                MessageBox.Show("An unexpected error occurred: " + result);
            }
        }

        private void LoginLinkLabel_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
