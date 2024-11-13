using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GamerSim
{
    public partial class Game : Form
    {
        public string Status { get; set; }
        public int MapID { get; set; }
        public int GameID { get; set; }
        public int CurrentGame {  get; set; }
        public Game(int gameId)//this has been changed, delete if error somewhere - the variable not the whole class
        {
            InitializeComponent();
            GameID = gameId;//this has been changed, delete if error somewhere

        }

        private void Game_Load(object sender, EventArgs e)
        {
            try
            {
                DataAccessObject dataAccess = new DataAccessObject();
                string result = dataAccess.DBConnection(); //get connection result
                MessageBox.Show(result); //show the result
                LoadGameBoard(GameID); //load the board
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during Game Load: {ex.Message}");
            }
        }
        private void QuitButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccessUsers dataAccess = new DataAccessUsers();//admin DAO
                dataAccess.QuitGame(Player.CurrentPlayerName);//call DAO function


                Admin admin = new Admin();//instance of admin form
                admin.Show();//show admin
                this.Hide();//hide this
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error quitting the game: {ex.Message}");
            }
        }

        private void LoadGameBoard(int gameID)//load the board for the game.
        {
            try
            {
                //MessageBox.Show($"Loading Game Board for GameID: {gameID}");
                DataAccessGame dataAccess = new DataAccessGame();//instance of game DAO
                List<Tile> tiles = dataAccess.GetBoardTiles(gameID);//get tiles list from DAO

                //set value for dimensions
                int maxRows = 10;
                int maxCols = 10;

                //clear existing rows and columns
                Game_Board_DataGridView.Rows.Clear();
                Game_Board_DataGridView.Columns.Clear();


                //set up grid max dimensions
                Game_Board_DataGridView.ColumnCount = maxCols;
                Game_Board_DataGridView.RowCount = maxRows;

                //adjusting column and row sizes to suit my app
                foreach (DataGridViewColumn col in Game_Board_DataGridView.Columns)
                {
                    col.Width = 25; //set width of each column
                }

                foreach (DataGridViewRow row in Game_Board_DataGridView.Rows)
                {
                    row.Height = 25; //set height of each row
                }
                //fill the grid with tiles
                foreach (Tile tile in tiles)
                {
                    DataGridViewCell cell = Game_Board_DataGridView.Rows[tile.Row - 1].Cells[tile.Col - 1];

                    //check if the cell is valid
                    if (cell == null)
                    {
                        MessageBox.Show($"Cell is null for Row {tile.Row - 1}, Col {tile.Col - 1}");
                        continue; // Skip this tile if the cell is invalid
                    }
                    //for each tiletype change the color
                    switch (tile.TileType)
                    {
                        case 1:
                            cell.Style.BackColor = Color.Green;//green for player
                            cell.Tag = "UnSelectable";
                            break;
                        case 5:
                            cell.Style.BackColor = Color.Red;//red for monster
                            cell.Tag = "UnSelectable";
                            break;
                        case 3:
                            cell.Style.BackColor = Color.Yellow;//yellow for treasure.
                            cell.Tag = "UnSelectable";
                            break;
                        default:
                            cell.Style.BackColor = Color.Gray;//grey for null
                            cell.Tag = "UnSelectable";
                            break;
                    }

                    //adding the tiletype int to each cell
                    cell.Value = tile.TileType.ToString();

                    if (cell.Value.ToString() != tile.TileType.ToString())
                    {
                        MessageBox.Show($"Failed to set cell value for Row {tile.Row - 1}, Col {tile.Col - 1}. Expected: {tile.TileType}");
                    }
                    LoadItemList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading game board: {ex.Message}");
            }
        }

        private void MovePlayer(int newRow, int newCol, int gameID, string CurrentPlayerName)//for movement
        {
            try
            {
                //if player or grid null
                if (Player.CurrentPlayer == null || Game_Board_DataGridView == null)
                {
                    MessageBox.Show("Player or Game Board is not setup.");
                    return;
                } else
                {
                    DataAccessGame dataAccess = new DataAccessGame();
                    string response = dataAccess.MovePlayer(newRow, newCol, gameID, CurrentPlayerName);
                    MessageBox.Show(response);

                    if (response == "Player Moved Successfully")
                    {
                        LoadGameBoard(gameID);
                        MonsterMove(gameID);
                    }
                    if (response == "Found Treasure")
                    {
                        LoadGameBoard(gameID);
                    }
                    Player.CurrentPlayer.X = newRow;
                    Player.CurrentPlayer.Y = newCol;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error moving player: {ex.Message}");
            }
        }

        private void MoveButton_Click(object sender, EventArgs e)//move button functionality
        {
            try
            {
                int playerCol = Player.CurrentPlayer.Y;//sets playerRow to the player cords
                int playerRow = Player.CurrentPlayer.X;//sets playerCol to the player cords

                //highlight valid movement tiles
                HighlightValidMoveTiles(playerRow, playerCol);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling move button click: {ex.Message}");
            }
        }

        private void HighlightValidMoveTiles(int row, int col)
        {
            try
            {
                // Reset tile colors before highlighting valid moves
                ResetTileColors();

                // Check 1-tile radius around the player's current position
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        int newRow = row + i;
                        int newCol = col + j;

                        // Ensure newRow and newCol are within grid bounds
                        if (newRow >= 0 && newRow < Game_Board_DataGridView.RowCount &&
                            newCol >= 0 && newCol < Game_Board_DataGridView.ColumnCount)
                        {
                            // Highlight valid movement tiles (excluding player and obstacle tiles)
                            DataGridViewCell cell = Game_Board_DataGridView.Rows[newRow].Cells[newCol];

                            // Exclude the player tile itself (center of the 1-tile radius)

                            cell.Style.BackColor = Color.LightBlue; // Make selectable tiles light blue
                            cell.Tag = "Selectable"; // Mark as selectable

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error highlighting valid move tiles: {ex.Message}");
            }
        }


        private void GameBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selectedRow = e.RowIndex;
                int selectedCol = e.ColumnIndex;
                string CurrentPlayerName = Player.CurrentPlayerName;
                int gameID = GameID;

                MovePlayer(selectedRow, selectedCol, gameID, CurrentPlayerName); // Send the corrected coordinates to MovePlayer
                LoadGameBoard(gameID);
                //if (Game_Board_DataGridView[selectedRow, selectedCol].Style.BackColor == Color.LightBlue) // Ensure "Selectable" is properly checked
                //{
                // Move the player to the selected tile
                //    MovePlayer(selectedRow, selectedCol, gameID, CurrentPlayerName); // Send the corrected coordinates to MovePlayer
                //}
                //else
                //{
                //    MessageBox.Show("Select a Valid Tile");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on cell click: {ex.Message}");
            }
        }
        private void ResetTileColors()//handles the tile colours
        {
            try
            {
                foreach (DataGridViewRow row in Game_Board_DataGridView.Rows)//for each row
                {
                    foreach (DataGridViewCell cell in row.Cells)//for each cel in the row
                    {
                        //cell not null before continuing
                        if (cell.Value != null && int.TryParse(cell.Value.ToString(), out int tileType))
                        {
                            //uses tileType to change the color of each tile.
                            if (tileType == 0)
                            {
                                cell.Style.BackColor = Color.White; //Null tiles
                                cell.Tag = "UnSelectable";
                                cell.ReadOnly = true;
                            }
                            else if (tileType == 1)
                            {
                                cell.Style.BackColor = Color.Green; //Player tile
                                cell.Tag = "UnSelectable";
                                cell.ReadOnly = true;
                            }
                            else if (tileType == 5)
                            {
                                cell.Style.BackColor = Color.Red; //Monster tile
                                cell.Tag = "UnSelectable";
                                cell.ReadOnly = true;
                            }
                            else if (tileType == 3)
                            {
                                cell.Style.BackColor = Color.Yellow; //Treasure tile
                                cell.Tag = "UnSelectable";
                                cell.ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting tile colors: {ex.Message}");
            }
        }
        public void LoadItemList()//for loading the listbox of players
        {
            try
            {
                //get all players from database
                DataAccessGame dataAccess = new DataAccessGame();
                List<Item> allItems = dataAccess.GetAllItems(GameID, Player.CurrentPlayerName);//from DAO set list of players = all players

                //clear items from listbox
                ItemsListBox.Items.Clear();


                //add gameID, MapID and Status to the listbox (per game)
                if (allItems != null)
                    foreach (var Item in allItems)
                    {
                        string ItemsInfo = $"{Item.Name},  {Item.EffectType},   {Item.EffectAmount}";//add strings to each row.

                        ItemsListBox.Items.Add(ItemsInfo);//add item info to the listbox
                    }
                else
                {
                    MessageBox.Show("No Items");
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error loading Items: " + ex.Message);
            }
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            //FOR FUTURE IMPLEMENTATION
        }
        public void MonsterMove(int gameID)
        {
            try
            {
                //if grid null
                if (Game_Board_DataGridView == null)
                {
                    MessageBox.Show("Game Board is not setup.");
                    return;
                }
                else
                {
                    DataAccessGame dataAccess = new DataAccessGame();
                    string response = dataAccess.MonsterMove(gameID);
                    MessageBox.Show(response);

                    LoadGameBoard(gameID);

                    if (response == "Game Over - Player Died")
                    {

                        DataAccessGame dataAccessGame = new DataAccessGame();
                        dataAccessGame.DeleteGame(gameID);

                        Admin admin = new Admin();
                        admin.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error Moving Monster: " + ex.Message);
            }
        }
    }
}
