using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GamerSim
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            try
            {
                LoadPlayersList();//load player list
                LoadGameList();//Load game list

                if (DataAccessUsers.isAdmin)
                {
                    Admin_Panel.Visible = true;//sets admin panel visible if the user is an admin
                    UserDelete_Panel.Visible = false;//not visible for admins as they dont need it.
                }
                else
                {
                    Admin_Panel.Visible = false;//the opposite to the above.
                    UserDelete_Panel.Visible = true;//same too
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin data: " + ex.Message);
            }
        }

        public void LoadPlayersList()//for loading the listbox of players
        {
            try
            {
                //get all players from database
                DataAccessUsers dataAccess = new DataAccessUsers();
                List<Player> allPlayers = dataAccess.GetAllPlayers();//from DAO set list of players = all players

                //clear items from listbox
                PlayerListBox.Items.Clear();
                

                //add player name and win to the listbox (per player)
                foreach (var player in allPlayers)
                {
                    string playerInfo = $"Name: {player.Name}, Points: {player.Wins}";//name and wins in string.
                    PlayerListBox.Items.Add(playerInfo);//add player info to the listbox
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error loading players: " + ex.Message);
            }
        }
        private void Button_createGame_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessGame dataAccess = new DataAccessGame();
                if (radioButton_map1.Checked)
                {//checks for each radio button checked
                    var mapID = 1;//assigns mapid
                    string response = dataAccess.CreateNewGameInDatabase(mapID, Player.CurrentPlayerName);
                    MessageBox.Show(response);

                    string[] splitItem = response.Split(',');//split string from the ','
                    string selectedGameMessage = splitItem[0].Trim();
                    string selectedGameID = splitItem[1].Trim();
                    int gameID = Convert.ToInt32(selectedGameID);
                    if (selectedGameMessage == "game made")
                    {
                        Game game = new Game(gameID);
                        game.Show();//go to game page
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error Making Game");
                    }

                }
                else if (radioButton_map2.Checked)//same as above just different radio button
                {
                    var mapID = 2;
                    string response = dataAccess.CreateNewGameInDatabase(mapID, Player.CurrentPlayerName);
                    MessageBox.Show(response);

                    string[] splitItem = response.Split(',');
                    string selectedGameMessage = splitItem[0].Trim();
                    string selectedGameID = splitItem[1].Trim();
                    int gameID = Convert.ToInt32(selectedGameID);
                    if (selectedGameMessage == "game made")
                    {
                        Game game = new Game(gameID);
                        game.Show();//go to game page
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Error Making Game");
                    }
                }
                else
                {
                    MessageBox.Show("Select a Map to Continue");//if no radio button checked.
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error loading games: " + ex.Message);
            }
        }

        private void Button_logOut_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessUsers dataAccess = new DataAccessUsers();//instance of admin DAO
                dataAccess.Logout(Player.CurrentPlayerName);//call method to logout player to update status

                Login login = new Login();
                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error logging out: " + ex.Message);
            }
        }

        private void Button_createUser_Click(object sender, EventArgs e)
        {
            try
            {
                Register register = new Register();
                register.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error creating users: " + ex.Message);
            }
        }

        private void Button_deleteUser_Click(object sender, EventArgs e)//handling for delete button
        {
            try
            {
                if (PlayerListBox.SelectedItem != null)//if exists
                {
                    string selectedItem = PlayerListBox.SelectedItem.ToString();//make selected item to string
                    string[] splitItem = selectedItem.Split(',');//split string from the ','

                    string selectedPlayer = splitItem[0].Split(':')[1].Trim();//get "user" part from 'Name: user'

                    //confirm deletion with message
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete player {selectedPlayer}?", "Delete Player", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)//if yes
                    {
                        DataAccessAdmins dataAccess = new DataAccessAdmins();//instance of admin DAO
                        string response = dataAccess.DeletePlayer(selectedPlayer);//call method to delete plaer
                        MessageBox.Show(response);//response from DAO

                        LoadPlayersList();//load player list
                    }
                }
                else
                {
                    MessageBox.Show("Please select a player to delete.");//no player selected
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
        }

        private void Button_updateUser_Click(object sender, EventArgs e)//handling for update
        {
            try
            {
                if (PlayerListBox.SelectedItem != null)//if playerbox not null
                {
                    //get player username from selected item.
                    string selectedPlayer = PlayerListBox.SelectedItem.ToString().Split(',')[0].Trim();//split and trim wins:0 from result
                    string playerName = selectedPlayer.Split(':')[1].Trim();//trim it to just the username.


                    DataAccessAdmins dataAccess = new DataAccessAdmins();//instance of admin DAO
                    Player player = dataAccess.GetPlayerByName(playerName);//get player username

                    if (player != null)//if player exists
                    {
                        //give details to the UpdateUser form
                        UpdateUser updateUserForm = new UpdateUser(player);//new instance of UpdateUser with the player + details
                        updateUserForm.ShowDialog();//show updated user
                        LoadPlayersList();//update playerlist
                    }
                    else
                    {
                        MessageBox.Show($"Player {playerName} not found in the database.");//user not found
                    }
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void UserDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var playernow = Player.CurrentPlayerName;//declare a variable for a name of logged in player
                if (playernow != null)//if exists
                {
                    DialogResult result = MessageBox.Show($"Are you sure you want to delete player {playernow}?", "Delete Player", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)//if yes
                    {
                        DataAccessAdmins dataAccess = new DataAccessAdmins();//instance of admin DAO
                        string response = dataAccess.DeletePlayer(playernow);//call method to delete plaer
                        MessageBox.Show(response);//response from DAO

                        LoadPlayersList();//load player list

                        Login login = new Login();
                        this.Close();
                        login.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show($"Player ..{playernow}.. not found in database - ERROR.");//error message
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error on delete user click: " + ex.Message);
            }
        }
        public void LoadGameList()//for loading the listbox of players
        {
            try
            {
                //get all players from database
                DataAccessGame dataAccess = new DataAccessGame();
                List<Game> allGames = dataAccess.GetAllGames();//from DAO set list of players = all players

                //clear items from listbox
                GameListBox.Items.Clear();


                //add gameID, MapID and Status to the listbox (per game)
                if (allGames != null)
                    foreach (var game in allGames)
                    {
                        string gameInfo = $"GameID: {game.GameID}, MapID: {game.MapID}, Status: {game.Status}";//name and wins in string.
                    
                        GameListBox.Items.Add(gameInfo);//add player info to the listbox
                    }
                else
                {
                    MessageBox.Show("No Games");
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error loading games: " + ex.Message);
            }
        }

        private void Button_endGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (GameListBox.SelectedItem != null)
                {
                    string selectedGame = GameListBox.SelectedItem.ToString().Split(',')[0].Trim();//split and trim 1, 2 from result
                    string GameID = selectedGame.Split(':')[1].Trim();//trim it to just the GameID.
                    int gamenow = Convert.ToInt32(GameID);

                    DialogResult result = MessageBox.Show($"Are you sure you want to delete game {gamenow}?", "Delete Game", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)//if yes
                    {
                        DataAccessGame dataAccess = new DataAccessGame();//instance of admin DAO
                        string response = dataAccess.DeleteGame(gamenow);//call method to delete plaer
                        MessageBox.Show(response);//response from DAO

                        LoadGameList();//load player list
                    }
                }
                else
                {
                    MessageBox.Show($"Game not found in database - ERROR.");//error message
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error ending game: " + ex.Message);
            }
        }

        private void Button_joinGame_Click(object sender, EventArgs e)
        {
            try
            {
                if (GameListBox.SelectedItem != null)
                {
                    string selectedGame = GameListBox.SelectedItem.ToString().Split(',')[0].Trim();//split and trim 1, 2 from result
                    string GameID = selectedGame.Split(':')[1].Trim();//trim it to just the GameID.
                    int gamenow = Convert.ToInt32(GameID);


                    DialogResult result = MessageBox.Show($"Are you sure you want to join game with id: {gamenow}?", "Join Game", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)//if yes
                    {
                        DataAccessGame dataAccess = new DataAccessGame();//instance of admin DAO
                        string response = dataAccess.JoinGame(gamenow, Player.CurrentPlayerName);//call method to delete plaer
                        MessageBox.Show(response);//response from DAO

                        if (response == "Joined Game Successfully")
                        {
                            //functionality set player location here on join --before technically

                            string xy = dataAccess.GetPlayerLocation(gamenow, Player.CurrentPlayerName);
                            int newX = Convert.ToInt32(xy.Split(',')[1].Trim());
                            int newY = Convert.ToInt32(xy.Split(',')[0].Trim());

                            Player.CurrentPlayer.X = newX;
                            Player.CurrentPlayer.Y = newY;

                            int gameID = gamenow;
                            Game game = new Game(gameID);
                            this.Close();
                            game.ShowDialog();
                        }

                    }
                }
                else
                {
                    MessageBox.Show($"No games found in database - ERROR.");//error message
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error joining game: " + ex.Message);
            }
        }
    }
}
