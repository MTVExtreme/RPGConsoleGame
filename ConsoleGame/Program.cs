using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        #region Public Variables
        public static PlayerClass player1;
        public static PlayerClass player2;
        public static PlayerClass player3;

        public static string Version = "0.3.4";
        #endregion
        static void Main(string[] args)
        {
            #region Startup Items
            Random rnd = new Random();
            bool TwoPlayers;
            bool ThreePlayers;

            int gameType = WelcomeScreen();
            CreatePlayer(out TwoPlayers, out ThreePlayers, out player1, ref player2, ref player3, gameType, rnd);

            #endregion

            Console.ReadLine();
            player1.ReadAttacks();
            player1.ReadSpecialAttacks();
            Console.ReadLine();

            if (TwoPlayers == true)
            {
                player2.ReadAttacks();
                player2.ReadSpecialAttacks();
            }
            Console.ReadLine();

            //RabidWolf Wolf = new RabidWolf();
            //Wolf.Insult();
            //Wolf.WolfAttack(player1);
            //Console.ReadLine();


        }

        private static void CreatePlayer(out bool TwoPlayers, out bool ThreePlayers, out PlayerClass player1, ref PlayerClass player2, ref PlayerClass player3, int gameType, Random rnd)
        {
            switch (gameType)
            {
                case 0:
                    TwoPlayers = true;
                    ThreePlayers = true;
                    player1 = Startup(false, rnd);//Player
                    player2 = Startup(true, rnd);//AI
                    player3 = Startup(true, rnd);//AI
                    break;
                case 1:
                    TwoPlayers = true;
                    ThreePlayers = true;
                    player1 = Startup(false, rnd);//Player
                    player2 = Startup(false, rnd);//Player
                    player3 = Startup(true, rnd);//AI
                    break;
                case 2:
                    TwoPlayers = true;
                    ThreePlayers = true;
                    player1 = Startup(false, rnd);//Player
                    player2 = Startup(false, rnd);//Player
                    player3 = Startup(false, rnd);//Player
                    break;
                case 3:
                    TwoPlayers = false;
                    ThreePlayers = false;
                    player1 = Startup(false, rnd);//Player
                    break;
                case 4:
                    TwoPlayers = true;
                    ThreePlayers = false;
                    player1 = Startup(false, rnd);//Player
                    player2 = Startup(false, rnd);//Player         
                    break;

                default:
                    TwoPlayers = false;
                    ThreePlayers = false;
                    player1 = Startup(true, rnd);
                    break;

            }
        }

        private static PlayerClass Startup(bool isAi, Random rnd)
        {

            #region Local Variables + AI Name + Faction Lists
            PlayerClass player1;
            int playerType;
            string name;
            string faction;

            

            List<string> aiNameList = new List<string>()
            {
                "Edmund",
                "Symund",
                "Cenbehrt",
                "Coenbald",
                "Narder",
                "Bertom",
                "Bertio",
                "Garu",
                "Warda",
                "Hilas"

            };

            List<string> aiFactionList = new List<string>()
            {
                "Damned Fall",
                "Wicked Doom",
                "Gladiators of the Moon",
                "Rebellion of the Promised",
                "Glory of the Unknown",
                "Nightmares of the Pure",
                "Coldguard",
                "Battle Rats",
                "Corrupted Alliance",
                "Deluded Incarnation",
                "Valiant Honour",
                "Spite of Desire",
                "Hate of the Sacred",
                "Promise of Shadows",
                "Rebels of the Jackal",
                "Shadowstriders",
                "Bonefury",
                "Splitshroud"

            };
            #endregion

            Console.Clear();

            #region User Input and AI Randoms
            if (isAi == true)
            {
                
                int index = rnd.Next(aiNameList.Count);
                int Findex = rnd.Next(aiFactionList.Count);

                faction = aiFactionList.ElementAt(Findex);
                name = aiNameList.ElementAt(index);


                playerType = rnd.Next(4);

            }
            else
            {
                Console.WriteLine("\nWhat will the name of your Adventurer be?");
                name = Console.ReadLine();
                Console.WriteLine("What clan of faction are is your adventurer a part of?");
                faction = Console.ReadLine();
                Console.WriteLine("What class is your adventurer?\n" +
                    "0: Ninja\n" +
                    "1: Mage\n" +
                    "2: Paladin\n" +
                    "3: Ranger");
                playerType = int.Parse(Console.ReadLine());
            }

            #endregion

            #region Player Class Assignment
            if (playerType == 0)
            {
                player1 = new Ninja(name, faction);
            }
            else if (playerType == 1)
            {
                player1 = new Mage(name, faction);
            }
            else if (playerType == 2)
            {
                player1 = new Paladin(name, faction);
            }
            else if (playerType == 3)
            {
                player1 = new Ranger(name, faction);
            }
            else
            {
                player1 = new Human(name, faction);
            }
            #endregion
            //PlayerClass player = new PlayerClass(name, faction);
            //player.Choosetype(playerType);

            //Console.Clear();

            Console.WriteLine(player1.ToString());
            return player1;

        }

        private static int WelcomeScreen()
        {
            bool playerCheck;
            Console.WriteLine("Welcome to DURF (Deadly Underground Reference Fighting)");
            Console.WriteLine("Version: {0} | Author: Tyler Vermillion ©2017-{1}",Version, DateTime.Now.Year);
            string durfFlash = @"
                                                                                    
DDDDDDDDDDDDD        UUUUUUUU     UUUUUUUURRRRRRRRRRRRRRRRR   FFFFFFFFFFFFFFFFFFFFFF
D::::::::::::DDD     U::::::U     U::::::UR::::::::::::::::R  F::::::::::::::::::::F
D:::::::::::::::DD   U::::::U     U::::::UR::::::RRRRRR:::::R F::::::::::::::::::::F
DDD:::::DDDDD:::::D  UU:::::U     U:::::UURR:::::R     R:::::RFF::::::FFFFFFFFF::::F
  D:::::D    D:::::D  U:::::U     U:::::U   R::::R     R:::::R  F:::::F       FFFFFF
  D:::::D     D:::::D U:::::D     D:::::U   R::::R     R:::::R  F:::::F             
  D:::::D     D:::::D U:::::D     D:::::U   R::::RRRRRR:::::R   F::::::FFFFFFFFFF   
  D:::::D     D:::::D U:::::D     D:::::U   R:::::::::::::RR    F:::::::::::::::F   
  D:::::D     D:::::D U:::::D     D:::::U   R::::RRRRRR:::::R   F:::::::::::::::F   
  D:::::D     D:::::D U:::::D     D:::::U   R::::R     R:::::R  F::::::FFFFFFFFFF   
  D:::::D     D:::::D U:::::D     D:::::U   R::::R     R:::::R  F:::::F             
  D:::::D    D:::::D  U::::::U   U::::::U   R::::R     R:::::R  F:::::F             
DDD:::::DDDDD:::::D   U:::::::UUU:::::::U RR:::::R     R:::::RFF:::::::FF           
D:::::::::::::::DD     UU:::::::::::::UU  R::::::R     R:::::RF::::::::FF           
D::::::::::::DDD         UU:::::::::UU    R::::::R     R:::::RF::::::::FF           
DDDDDDDDDDDDD              UUUUUUUUU      RRRRRRRR     RRRRRRRFFFFFFFFFFF           ";

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(durfFlash);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n|--Menu--| |--Type the number of the game type you want then hit enter--|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("0: 3-Person Party (1 Player)");
            Console.WriteLine("1: 3-Person Party (2 Players)"); 
            Console.WriteLine("2: 3-Person Party (3 Players)"); 
            Console.WriteLine("3: 1-Person Party (1 Player)");
            Console.WriteLine("4: 2-Person Party (2 Players)");
            Console.Write(">>>");
            int input = Int32.Parse(Console.ReadLine());

            return input;

        }
    }
}
