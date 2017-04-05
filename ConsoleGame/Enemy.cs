using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Enemy
    {
        public List<string> MiniBossNameList = new List<string>()
            {
                "Battlegut The Demon",
                "Charmfight The Stealthy",
                "Chillpus",
                "Crazemane The Miser",
                "Duskclay The Crafty",
                "Duskvine The Witch",
                "Fastfury The Slasher",
                "Freezebane",
                "Hungerspectre The Quick",
                "Leafthought The Miser",
                "Magicfight",
                "Mindcrush",
                "Moneyghast",
                "Rottrack The Terrifying",
                "Seekfreeze",
                "Soulcog The Psychic",
                "Springchain",
                "Trackscum The Worm-ridden",
                "Vilelover The Firey"
            };

        public string Name { get; set; }
        public string Faction { get; set; }
        public int Level { get; set; }
        public int HealthPoints { get; set; }
        public int Speed { get; set; }

        Random rnd = new Random();




        public void Insult()
        {
            ArrayList insult = new ArrayList {"buck-o", "whimp", "jerk-wad", "window licker", "noob", "neeeerd", "baka" };
            
            int r = rnd.Next(0, insult.Count);

            Console.WriteLine("You're on the wrong side of the forest {0}", insult[r]);
        }

        public void Attack(PlayerClass player, Dictionary<string, int> dict, Object enemyName)
        {
            

            var singleAttack = dict.ElementAt(rnd.Next(dict.Count));
            int attackVal = singleAttack.Value;
            string attackName = singleAttack.Key;

            Console.WriteLine("Enemy Attacks {0} with {1} for {2} damage",player.Name, attackName, attackVal);
        }
    }
}
