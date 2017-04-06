using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{

    abstract class PlayerClass
    {
        public string Name { get; set; }
        public string Faction { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int Speed { get; set; }
        public CharacterType Type { get; set; }
        public bool IsAI { get; set; }
        public int Attackz { get; set; }

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

        Dictionary<string, int> specialAttacks = new Dictionary<string, int>();

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("99: Back");
        }

        public virtual void ReadSpecialAttacks()
        {
            int num = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Special Attacks:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (var attack in SpecialAttacks)
            {
                num++;
                Console.WriteLine("{0}: {1}", num, attack.Key);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("99: Back");
        }

        public override string ToString()
        {
            return $"The {this.Type} {this.Name} of {this.Faction} => Health Points: {this.HealthPoints} || Speed: {this.Speed}";
        }

        public virtual string GetExtraStat()
        {
            if (this.Type == CharacterType.Mage)
            {
                return "Mana";
            }
            else
            {
                return "Stamina";
            }
        }

        public abstract int GetExtraStatValue();

        public void Attack(Enemy player, int attack  , Object enemyName)
        {


            var singleAttack = attacks.ElementAt(attack);
            int attackVal = singleAttack.Value;
            string attackName = singleAttack.Key;

            Console.WriteLine("{3} Attacks {0} with {1} for {2} damage", player.Name, attackName, attackVal, this.Name);

            player.HealthPoints -= attackVal;
        }

        public void SpecialAttack(Enemy player, int attack, Dictionary<string, int> fire , Object enemyName)
        {


            var singleAttack = fire.ElementAt(attack);
            int attackVal = singleAttack.Value;
            string attackName = singleAttack.Key;

            Console.WriteLine("{3} Attacks {0} with {1} for {2} damage", player.Name, attackName, attackVal, this.Name);

            player.HealthPoints -= attackVal;
        }

        public void Heal()
        {
            Random rnd = new Random();
            int hp = rnd.Next(5, 70);
            this.HealthPoints += hp;

            Console.WriteLine("{0} healed {1} HP.", this.Name, hp);
            Console.ReadLine();
        }
    }
}
