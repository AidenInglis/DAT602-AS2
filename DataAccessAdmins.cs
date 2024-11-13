using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GamerSim
{
    class DataAccessAdmins : DataAccessObject
    {
        public string DeletePlayer(string playerName)//method for deleting the player by name
        {
            try {
                // Prepare the SQL parameters
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var playerParam = new MySqlParameter("@pName", MySqlDbType.VarChar, 50)
                {
                    Value = playerName//param name
                };
                parameters.Add(playerParam);

                //call delete procedure with playername
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "CALL DeletePlayer(@pName)", parameters.ToArray());

                //return response from delete
                return dataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error deleting player: " + ex.Message);
                return $"Error: {ex.Message}";
            }
        }

        public string UpdatePlayer(string oldName, string newName, string password, string email)
        {
            try {
                //validate inputs for null values
                if (string.IsNullOrWhiteSpace(oldName) ||
                    string.IsNullOrWhiteSpace(newName) ||
                    string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(email))
                {
                    return "Error: All fields are required.";//error
                }

                List<MySqlParameter> parameters = new List<MySqlParameter>//list param for update sql method
                {
                    new MySqlParameter("@pName", MySqlDbType.VarChar, 50) { Value = oldName },
                    new MySqlParameter("@pNewName", MySqlDbType.VarChar, 50) { Value = newName },
                    new MySqlParameter("@pPassword", MySqlDbType.VarChar, 50) { Value = password },
                    new MySqlParameter("@pEmail", MySqlDbType.VarChar, 100) { Value = email }
                };
                
                //Call sql method update with param
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call UpdatePlayer(@pName, @pNewName, @pPassword, @pEmail)", parameters.ToArray());

                //check for result message
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    return dataSet.Tables[0].Rows[0]["Message"].ToString();
                }
                else
                {
                    return "Error: No message returned from the stored procedure.";//no row returned then error
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error updating player: " + ex.Message);
                return $"Error: {ex.Message}";
            }
        }

        public Player GetPlayerByName(string playerName)//playername method
        {
            Player player = null;

            try
            {
                List<MySqlParameter> parameters = new List<MySqlParameter>//list param for sql method
                {
                    new MySqlParameter("@pName", playerName)//param name
                };
                //call select name password and email where name is name
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "SELECT Name, Password, Email FROM Player WHERE Name=@pName", parameters.ToArray());

                if (dataSet.Tables[0].Rows.Count > 0)//check if player result
                {
                    var row = dataSet.Tables[0].Rows[0];//get row 0
                    player = new Player//set player details
                    {
                        Name = row["Name"].ToString(),
                        Password = row["Password"].ToString(),
                        Email = row["Email"].ToString()
                    };
                }
                else
                {
                    MessageBox.Show($"Player not found: {playerName}");//error message
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching player details: {ex.Message}");//error with error details.
            }

            return player;
        }
    }
}
