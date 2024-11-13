namespace GamerSim
{
    public class Monster
    {
        public int GameID { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }  
        public int Health { get; set; }
        public int Strength { get; set; }
        public string Status { get; set; }

        public Monster(int gameID, int x, int y, int health, int strength, string status)
        {
            GameID = gameID;
            X = x;
            Y = y;
            Health = health;
            Strength = strength;
            Status = status;
        }

    }
}
