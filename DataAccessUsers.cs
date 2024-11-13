using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GamerSim
{
    class DataAccessUsers : DataAccessObject
    {
        public static bool isAdmin = false;//stastic for isadmin variable
        public string AddUserName(string pName, string pPassword, string pEmail)//for adding new user
        {
            try {
                List<MySqlParameter> parameters = new List<MySqlParameter>();//create list for procedure.
                var userP = new MySqlParameter("@pName", MySqlDbType.VarChar, 50)//creating parameters for procedure.
                {
                    Value = pName
                };
                parameters.Add(userP);
                var passP = new MySqlParameter("@pPassword", MySqlDbType.VarChar, 50)
                {
                    Value = pPassword
                };
                parameters.Add(passP);
                var EmailP = new MySqlParameter("@pEmail", MySqlDbType.VarChar, 100)
                {
                    Value = pEmail
                };
                parameters.Add(EmailP);

                //call the method in sql
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call AddUserName(@pName, @pPassword, @pEmail)", parameters.ToArray());

                //result set message return.
                return (dataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error adding username: " + ex.Message);
                return $"Error: {ex.Message}";
            }
        }
        public string Logout(string CurrentPlayerName)
        {
            try {
                List<MySqlParameter> LogoutParameter = new List<MySqlParameter>();//create list for procedure.
                var PlayerName = new MySqlParameter("@pCurrentPlayerName", MySqlDbType.VarChar, 50)//creating parameters for procedure.
                {
                    Value = CurrentPlayerName
                };
                LogoutParameter.Add(PlayerName);

                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call Logout(@pCurrentPlayerName)", LogoutParameter.ToArray());
                //result set message return.
                return (dataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error logging out: " + ex.Message);
                return $"Error: {ex.Message}";
            }
        }

        public string QuitGame(string CurrentPlayerName)
        {
            try {
                List<MySqlParameter> QuitGameParameter = new List<MySqlParameter>();//create list for procedure.
                var PlayerName = new MySqlParameter("@pCurrentPlayerName", MySqlDbType.VarChar, 50)//creating parameters for procedure.
                {
                    Value = CurrentPlayerName
                };
                QuitGameParameter.Add(PlayerName);

                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call QuitGame(@pCurrentPlayerName)", QuitGameParameter.ToArray());
                //result set message return.
                return (dataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error Quiting game: " + ex.Message);
                return $"Error: {ex.Message}";
            }
        }

        public List<Player> GetAllPlayers()
        {
            try {
                List<Player> lcPlayers = new List<Player>();//list of players

                var aDataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call GetAllPlayers()");//call sql method
                lcPlayers = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])//linq to set result to players
                             select
                                new Player//get player name and wins
                                {
                                    Name = aResult["Name"].ToString(),
                                    Wins = Convert.ToInt32(aResult["Wins"])
                                }).ToList();
                return lcPlayers;//return list
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error Getting all players: " + ex.Message);
                return null;
            }
        }

        public string Login(string pName, string pPassword)
        {
            try {
                List<MySqlParameter> parameters = new List<MySqlParameter>();//list of parameters for login
                var userP = new MySqlParameter("@pName", MySqlDbType.VarChar, 50)//set param for login (username + password)
                {
                    Value = pName
                };
                parameters.Add(userP);
                var passP = new MySqlParameter("@pPassword", MySqlDbType.VarChar, 50)
                {
                    Value = pPassword
                };
                parameters.Add(passP);
                //method to call login sql with credentials
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call Login(@pName, @pPassword)", parameters.ToArray());

                if (dataSet.Tables[0].Rows.Count > 0)//if result
                {
                    //check admin
                    isAdmin = Convert.ToInt32(dataSet.Tables[0].Rows[0]["isAdmin"]) == 1;

                    //return message
                    return dataSet.Tables[0].Rows[0]["Message"].ToString();
                }
                else
                {
                    //no rows, invalid login
                    return "Login failed: Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error logging in: " + ex.Message);
                return $"Error: {ex.Message}";
            }
        }

    }
}