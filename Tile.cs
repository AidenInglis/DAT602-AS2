namespace GamerSim
{
    public class Tile
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int TileType { get; set; } //0 = normal, 1 = player, 3 = treasure, 5 = monster
        public bool IsOccupied { get; set; }//for implementation later

        public Tile(int row, int col)//for a default tile setup for 
        {
            Row = row;
            Col = col;
            TileType = 0;
            IsOccupied = false;
        }

        public void SetPlayer(Player player)
        {
            TileType = 1;
            IsOccupied = true;
        }

        public void SetMonster()
        {
            TileType = 5;
            IsOccupied = true;
        }

        public void SetTreasure()
        {
            TileType = 3;
        }

        public bool IsEmpty()
        {
            return !IsOccupied;//is not occupied
        }
    }
}
