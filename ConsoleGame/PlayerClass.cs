using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGame
{

    abstract class PlayerClass : Character
    {
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

        public PlayerClass(string name, string faction, bool npc, CharacterType type = CharacterType.Human)
        {
            this.Name = name;
            this.Faction = faction;
            this.Level = 1;
            this.Attacks = attacks;
            this.NPC = npc;

            
        }

        public virtual void ReadAttacks()
        {
            int num = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Attacks:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var attack in Attacks)
            {
                Console.WriteLine("{0}: {1}", num, attack.Key);
                num++;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("99: Back to First Menu");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public virtual void ReadSpecialAttacks()
        {
            int num = 0;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Special Attacks:");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            foreach (var attack in SpecialAttacks)
            {              
                Console.WriteLine("{0}: {1}", num, attack.Key);
                num++;
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

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("##############################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{3} Attacks {0} with {1} for {2} damage", player.Name, attackName, attackVal, this.Name);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("##############################################");
            Console.ForegroundColor = ConsoleColor.White;

            player.HealthPoints -= attackVal;
        }

        public void SpecialAttack(Enemy player, int attack, Dictionary<string, int> fire , Object enemyName)
        {


            var singleAttack = fire.ElementAt(attack);
            int attackVal = singleAttack.Value;
            string attackName = singleAttack.Key;


           
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("##############################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{3} Conducts the special attack {1} on {0} dealing {2} damage", player.Name, attackName, attackVal, this.Name);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("##############################################");
            Console.ForegroundColor = ConsoleColor.White;

            player.HealthPoints -= attackVal;
        }

        public void Heal()

        {
            AdvancedRNG rnd = new AdvancedRNG();
            double hp = rnd.GetNext(5, 70);
            if((hp + HealthPoints) >= (MaxHealthPoints * 1.2))
            {
                hp = ((MaxHealthPoints * 1.2) - HealthPoints);
                this.HealthPoints = this.MaxHealthPoints * 1.2;
            }
            else this.HealthPoints += hp;

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("##############################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0} healed {1} HP.", this.Name, hp);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("##############################################");
            Console.ReadLine();
        }
    }

}
