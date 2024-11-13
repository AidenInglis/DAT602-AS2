using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamerSim
{
    public partial class UpdateUser : Form
    {
        private readonly Player player;//hold player deets
        public UpdateUser(Player playerDetails)//will pre fill the inputs will the player details.
        {
            InitializeComponent();
            player = playerDetails;

            //pre-fill the textboxes with player details
            TextBox_UserName.Text = player.Name;
            TextBox_Password.Text = player.Password;
            TextBox_Email.Text = player.Email;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();//close
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //fetch updated values from the form
            string oldName = player.Name; //store the old name for reference when updating
            string newName = TextBox_UserName.Text; //updated name
            string password = TextBox_Password.Text; //updated password
            string email = TextBox_Email.Text; //updated email

            //call method to update player in the database
            DataAccessAdmins dataAccess = new DataAccessAdmins();//make instance of admin DAO
            string response = dataAccess.UpdatePlayer(oldName, newName, password, email); // Pass all required arguments
            MessageBox.Show(response);//show response from DAO
            
            this.Close();//close
        }
    }

}

