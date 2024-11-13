namespace GamerSim
{
    public class Item
    {
        public int ItemID { get; set; }            // Unique identifier for the item
        public string Name { get; set; }            // Name of the item
        public string EffectType { get; set; }      // Type of effect (e.g., "Health", "Strength")
        public int EffectAmount { get; set; }       // Amount of the effect (e.g., +10 health)

        // Constructor with parameters
        public Item(int itemId, string name, string effectType, int effectAmount)
        {
            ItemID = itemId;
            Name = name;
            EffectType = effectType;
            EffectAmount = effectAmount;
        }
    }
}
