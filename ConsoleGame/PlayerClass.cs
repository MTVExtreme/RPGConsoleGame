using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{

    class PlayerClass
    {
        public string Name { get; set; }
        public string Faction { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int Speed { get; set; }
        public CharacterType Type { get; set; }
        public bool IsAI { get; set; }

        public Dictionary<string, int> Attacks {get; set;}
        public Dictionary<string, int> SpecialAttacks { get; set; }


        Dictionary<string, int> attacks = new Dictionary<string, int>
            {
                {"Punch", 5 },
                {"Headbutt", 5 },
                {"Wack", 10 },
                {"Tackle", 5 },
                {"Kick", 10 }
            };

        public PlayerClass(string name, string faction, CharacterType type = CharacterType.Human)
        {
            this.Name = name;
            this.Faction = faction;
            this.Level = 1;
            this.Attacks = attacks;
        }

        public virtual void ReadAttacks()
        {
            int num = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Attacks:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var attack in Attacks)
            {
                num++;
                Console.WriteLine("{0}: {1}", num, attack.Key);
            }
        }

        public virtual void ReadSpecialAttacks()
        {
            int num = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Attacks:");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var attack in SpecialAttacks)
            {
                num++;
                Console.WriteLine("{0}: {1}", num, attack.Key);
            }
        }

        public override string ToString()
        {
            return $"The {this.Type} {this.Name} of {this.Faction} => Health Points: {this.HealthPoints} || Speed: {this.Speed}";
        }

        //public virtual string Attack1()
        //{
        //    return $"{this.Name} attacked (Enemy) using (attack) for {Attack1Damage}";
        //}

        //public virtual string Attack2()
        //{
        //    return $"{this.Name} attacked (Enemy) using (attack) for {Attack1Damage}";
        //}

        //public virtual string Attack3()
        //{
        //    return $"{this.Name} attacked (Enemy) using (attack) for {Attack1Damage}";
        //}
    }
}
