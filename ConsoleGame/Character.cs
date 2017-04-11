namespace ConsoleGame
{
    abstract class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Faction { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int Speed { get; set; }
        public bool NPC { get; set; }

    }
}
