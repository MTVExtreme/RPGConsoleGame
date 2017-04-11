using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class RandomEnemy : Enemy
    {
        Dictionary<string, int> Attacks = new Dictionary<string, int>
            {
                {"Bite", 5 },
                {"Headbutt", 5 },
                {"Whip", 10 }
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },
                //{"Bite", 5 },
                //{"Headbutt", 5 },
                //{"Whip", 10 },

            };

        public List<string> MonsterName = new List<string>()
        {

"Smez" ,   "Otora",   "Irado",   "Leum",    "Ielmu",   "Uacho",   "Oeldo",
"Inale",   "Oskelo",  "Asayi",   "Ebele",   "Engq",    "Otori",   "Lorc",
"Peec",    "Rank",    "Loog",    "Lorld",   "Aorma",   "Ashl",    "Rodw",
"Enk", "Shein",   "Omck",    "Moer",    "Druir",   "Yerrd",   "Omk",
"Enc",    "Boonn",    "Tonh",    "Biy",    "Baus",    "Riss",    "Koil",
"Iarda",    "Uwari",    "Emt",    "Oldt",    "Dienn",    "Sluiy",    "Ychay",
"Ashm",    "Rhiend",    "Ia",    "Othery",    "Aumi",    "Polk",    "Oaughi",
"Ikimi",    "Rads",    "Uwori",    "Rodd",    "Oawi",    "Kelv",    "Otinu",
"Maek",    "Oghai",    "Aechi",    "Ylyea",    "Ustn",    "Uache",    "Dank",
"Danl",    "Croud",    "Yelmi",    "Oemu",    "Wous",    "Poif",
"Kam",    "Ewary",    "Bant",    "Yerl",    "Eisi",    "Asayo",    "Radm",
"Rakq",    "Edena",    "Enthph",    "Delb",    "Hatnn",    "Thernd",    "Samc",
"Endn",    "Jeyt",    "Yanga",    "Pers",    "Yrothe",    "Eathe",    "Ekimy",
"Lieth",    "Leud",    "Eldp",    "Slourd",    "Unte",    "Oatho",    "Rakd",
"Acho",    "Seet",    "Thrayk",    "Emc",    "Josh",    "Clan",    "Eenga",
"Odeno",    "Liy",    "Osulo",    "Ghac",    "Otury",    "Ingph",    "Biant",
"Denll",    "Ingm",    "Chayt",    "Iash",    "Ooughe",    "Raylt",    "Aentha"
        };

        public List<string> MonsterType = new List<string>()
        {
            "Giant",
            "Goblin",
            "Kobold",
            "Orc",
            "Troll",
            "Vampire",
            "Werewolf",
            "Rabid Wolf",
            "Snake",
            "Stabber",
            "Theif",
            "Tax Collector",
            "Warg",
            "Batman",
            "Nymph",
            "Whisp",
            "Satyr",
            "Death Bunny",
            "Killer Clown",
            "Gremlin",
            "Mini-Dragon",
            "Dragon",
            "Howler",
            "Bug",
            "Cube",
            "Slime",
            "Celestial",
            "Banshee",
            "Creamator",
            "Scavenger",
            "Dryad",
             "Striker",
            "Strangler",
            "Dsecrator",
            "Brute",
            "lummox"
        };

        public string Type { get; set; }


        public RandomEnemy(Random rnd)
        {
            //Random rnd = new Random();
            int hp = rnd.Next(20, 120);
            int speed = rnd.Next(2, 18);

            string name = MonsterName.ElementAt(rnd.Next(MonsterName.Count));
            string type = MonsterType.ElementAt(rnd.Next(MonsterType.Count));

            this.Speed = speed;
            this.HealthPoints = hp;
            this.MaxHealthPoints = hp;
            this.Type = type;
            this.Name = name;
            this.NPC = true;
        }

        public void RandomAttack(PlayerClass p)
        {
            Attack(p, Attacks, this.Name);

        }

    }
}
