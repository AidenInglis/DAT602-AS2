namespace GamerSim
{
    public class Player 
    {
        /// <summary>
        /// lists the player and their name, with their strength and health along with x and y cords for tile representation.
        /// </summary>
        public static string CurrentPlayerName { get; set; }
        public static Player CurrentPlayer { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Strength { get; set; }
        public int Health { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }
        public bool IsAdmin { get; set; }
        public int Wins { get; set; }

    }
}
    