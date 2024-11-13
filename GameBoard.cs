namespace GamerSim
{
    public class GameBoard
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public Tile[,] Tiles { get; private set; }  //array for holdin tiles
        public Player CurrentPlayer { get; private set; }

        public GameBoard(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Tiles = new Tile[rows, cols];
            InitializeTiles();//initialise the tiles
        }

        private void InitializeTiles()
        {
            // Initialize the game board with tiles
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    Tiles[r, c] = new Tile(r, c); //tile.tile ref
                }
            }
        }
    }
}
