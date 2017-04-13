using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Enemy : Character
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



        AdvancedRNG rnd = new AdvancedRNG();




        public void Insult()
        {
            ArrayList insult = new ArrayList {"buck-o", "whimp", "jerk-wad", "window licker", "noob", "neeeerd", "baka" };
            
            int r = rnd.GetNext(0, insult.Count);

            Console.WriteLine("You're on the wrong side of the forest {0}", insult[r]);
        }

        public void Attack(PlayerClass player, Dictionary<string, int> dict, Object enemyName)
        {
            

            var singleAttack = dict.ElementAt(rnd.GetNext(dict.Count));
            int attackVal = singleAttack.Value;
            string attackName = singleAttack.Key;

            player.HealthPoints -= attackVal;

            Console.WriteLine("{3} Attacks {0} with {1} for {2} damage",player.Name, attackName, attackVal, Name);
        }

        public void SpecialAttack(PlayerClass player, Dictionary<string, int> dict, Object enemyName)
        {


            var singleAttack = dict.ElementAt(rnd.GetNext(dict.Count));
            int attackVal = singleAttack.Value;
            string attackName = singleAttack.Key;

            player.HealthPoints -= attackVal;

            Console.WriteLine("{3} Conducts on special attack {1} on {0} dealing {2} damage", player.Name, attackName, attackVal, Name);
        }

        public void Heal()
        {
            AdvancedRNG rnd = new AdvancedRNG();
            int hp = rnd.GetNext(5, 70);
            this.HealthPoints += hp;

            Console.WriteLine("{0} healed {1} HP.", this.Name, hp);
            Thread.Sleep(4000);
        }
    }
}
