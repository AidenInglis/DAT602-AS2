using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GamerSim
{
    class DataAccessGame: DataAccessObject
    {

        public string MovePlayer(int newRow, int newCol,  int gameID,string CurrentPlayerName)
        {
            try
            {
                newRow++;
                newCol++;

                // Prep sql list for newRow
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var newRowParam = new MySqlParameter("@pnewRow", MySqlDbType.Int32)
                {
                    Value = newRow//param name
                };
                parameters.Add(newRowParam);
                var newColParam = new MySqlParameter("@pnewCol", MySqlDbType.Int32)
                {
                    Value = newCol//param name
                };
                parameters.Add(newColParam);
                var gameIDParam = new MySqlParameter("@pgameID", MySqlDbType.Int32)
                {
                    Value = gameID//param name
                };
                parameters.Add(gameIDParam);
                var PlayerParam = new MySqlParameter("@pCurrentPlayerName", MySqlDbType.VarChar, 50)
                {
                    Value = CurrentPlayerName//param name
                };
                parameters.Add(PlayerParam);

                //call inert statement for creation of game
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "CALL MovePlayer(@pnewRow, @pnewCol, @pgameID, @pCurrentPlayerName);", parameters.ToArray());

                //return response from insert statement
                return dataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error Moving Player: " + ex.Message);
                return null;
            }
        }

        public List<Tile> GetBoardTiles(int gameID)
        {
            try
            {
                List<Tile> tiles = new List<Tile>();
                string query = "SELECT * FROM tblTile WHERE GameID = @gameID"; //adjusted query to include GameID

                List<MySqlParameter> parameters = new List<MySqlParameter>
                {
                    new MySqlParameter("@gameID", MySqlDbType.Int32) { Value = gameID }
                };

                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, query, parameters.ToArray());

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    Tile tile = new Tile(Convert.ToInt32(row["row"]), Convert.ToInt32(row["col"]))
                    {
                        TileType = Convert.ToInt32(row["TileType"])
                    };
                    tiles.Add(tile);
                }

                return tiles;
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error loading board tiles: " + ex.Message);
                return null;
            }
        }


        public string CreateNewGameInDatabase(int mapID, string CurrentPlayerName)
        {
            try
            {
                // Prep sql list for mapID
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var mapIDParam = new MySqlParameter("@pmapID", MySqlDbType.VarChar, 50)
                {
                    Value = mapID//param name
                };
                parameters.Add(mapIDParam);
                var PlayerParam = new MySqlParameter("@pCurrentPlayerName", MySqlDbType.VarChar, 50)
                {
                    Value = CurrentPlayerName//param name
                };
                parameters.Add(PlayerParam);

                //call inert statement for creation of game
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call CreateNewGameInDatabase(@pmapID, @pCurrentPlayerName);", parameters.ToArray());

                //return response from insert statement
                return dataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error creating game in the database: " + ex.Message);
                return null;
            }
        }
        public List<Game> GetAllGames()
        {
            try {
                List<Game> lcGames = new List<Game>();//list of players

                var aDataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call GetAllGames()");//call sql method
                lcGames = (from aResult in DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                           select new Game(Convert.ToInt32(aResult["GameID"])) // Pass GameID to the constructor if required
                           {
                               MapID = Convert.ToInt32(aResult["MapID"]),
                               Status = aResult["Status"].ToString()
                           }).ToList();
                return lcGames;//return list
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error getting all games: " + ex.Message);
                return null;
            }
        }
        public List<Item> GetAllItems(int gameID, string currentPlayerName)
        {
            try {
                // Prepare the SQL parameters
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var gameParam = new MySqlParameter("@pGameID", MySqlDbType.Int32)
                {
                    Value = gameID
                };
                parameters.Add(gameParam);

                var playerParam = new MySqlParameter("@pCurrentPlayerName", MySqlDbType.VarChar, 50)
                {
                    Value = currentPlayerName
                };
                parameters.Add(playerParam);

                // Execute the stored procedure and retrieve results
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "CALL GetAllItems(@pCurrentPlayerName, @pGameID)", parameters.ToArray());

                List<Item> items = (from row in dataSet.Tables[0].AsEnumerable()
                                    select new Item(
                                        Convert.ToInt32(row["ItemID"]), // itemId
                                        row["Name"].ToString(),         // name
                                        row["EffectType"].ToString(),   // effectType
                                        Convert.ToInt32(row["EffectAmount"]) // effectAmount
                                    )).ToList();

                return items; // Return the list of items
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error getting all items: " + ex.Message);
                return null;
            }
        }

        public string GetPlayerLocation(int gameID, string CurrentPlayerName)
        {
            try {
                // Prepare the SQL parameters
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var gameParam = new MySqlParameter("@pGameID", MySqlDbType.Int32)
                {
                    Value = gameID
                };
                parameters.Add(gameParam);

                var playerParam = new MySqlParameter("@pCurrentPlayerName", MySqlDbType.VarChar, 50)
                {
                    Value = CurrentPlayerName
                };
                parameters.Add(playerParam);

                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "CALL GetPlayerLocation(@pGameID, @pCurrentPlayerName)", parameters.ToArray());

                return dataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error getting player location: " + ex.Message);
                return null;
            }
        }
        public string DeleteGame(int gamenow)//method for deleting the game by ID
        {
            try {
                // Prepare the SQL parameters
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var gameParam = new MySqlParameter("@pGameID", MySqlDbType.VarChar, 50)
                {
                    Value = gamenow//param name
                };
                parameters.Add(gameParam);

                //call delete procedure with GameID
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "CALL DeleteGame(@pGameID)", parameters.ToArray());

                //return response from delete
                return dataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error deleting game: " + ex.Message);
                return null;
            }
        }

        public string JoinGame(int gamenow, string CurrentPlayerName)
        {
            try {
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var gameParam = new MySqlParameter("@pGameID", MySqlDbType.VarChar, 50)
                {
                    Value = gamenow//param name
                };
                parameters.Add(gameParam);
                var playerParam = new MySqlParameter("@pCurrentPlayerName", MySqlDbType.VarChar, 50)
                {
                    Value = CurrentPlayerName//param name
                };
                parameters.Add(playerParam);

                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "CALL JoinGame(@pGameID, @pCurrentPlayerName)", parameters.ToArray());

                //return response from delete
                return dataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error joining game: " + ex.Message);
                return null;
            }
        }

        public string MonsterMove(int gameID)
        {
            try {
                // Prep sql list for gameID
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                var gameIDParam = new MySqlParameter("@pgameID", MySqlDbType.Int32, 50)
                {
                    Value = gameID//param name
                };
                parameters.Add(gameIDParam);
 
                //call inert statement for movement of monster
                var dataSet = MySqlHelper.ExecuteDataset(MySqlConnection, "call MonsterMove(@pgameID);", parameters.ToArray());

                //return response from insert statement
                return dataSet.Tables[0].Rows[0]["Message"].ToString();
            }
            catch (Exception ex)
            {
                //error handling
                MessageBox.Show("Error loading games: " + ex.Message);
                return null;
            }
        }

    }
}