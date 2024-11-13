using MySql.Data.MySqlClient;
using System;

namespace GamerSim
{
    class DataAccessObject
    {
        private static string ConnectionString//my connection string  with username and password for access.
        {
            get { return "Server=localhost;Port=3306;Database=gamedb;Uid=root;password=1234;"; }

        }

        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection MySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(ConnectionString);

                    MySqlHelper.ExecuteDataset(MySqlConnection, "SET autocommit = 0;");
                }

                return _mySqlConnection;

            }
        }

        public string DBConnection()//for testing connection to sql database.
        {
            try
            {
                MySqlConnection.Open();
                return "Database connection to the server is successful!!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                MySqlConnection.Close();
            }
        }
    }
}
