using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleGame
{
    class Program
    {
        /*
            Welcome to the Code of DURF created by Tyler Vermilion and the Movement and map by Chris Sullivan
            Feel free to use parts of this for inspiration or for your own project.
            Dislaimer however, this code is by far not the cleanest it could have been and needs to be redone sometime.
            By the time you read this I should have added comments explaining each part of the application.
            
            Check out my Github here: https://github.com/MTVExtreme || Portfoilio: https://mtvextreme.github.io/
            Check out my Linked.In here: https://www.linkedin.com/in/michael-vermillion-0121a412a/

            Thanks for taking your time to read my code and to play my Console Game.

            If you see any bugs in my code you may contact me about them, or you may fix it yourself and issue a pull request.
            I may go back later and remake the project in a much cleaner way once I have spare time and have more expirence.
        */
        #region Public Variables
        public static PlayerClass player1;
        public static PlayerClass player2;
        public static PlayerClass player3;

        protected static int EnemyCount;
        protected static int PlayerCount;

        protected static bool HasLost;

        //Current Version Displayed in game. This is purely a string and for informal tracking of the current version of the game.
        public static string Version = "0.12.16";
        #endregion
        static void Main(string[] args)
        {
            #region Startup Items
            AdvancedRNG rnd = new AdvancedRNG();
            HasLost = false;

            bool TwoPlayers;
            bool ThreePlayers;

            int gameType = WelcomeScreen();
            CreatePlayer(out TwoPlayers, out ThreePlayers, out player1, ref player2, ref player3, gameType, rnd);

            player1.ID = 0;
            if (TwoPlayers == true) player2.ID = 1;
            if (ThreePlayers == true) player3.ID = 2;

            #endregion

            while (HasLost == false)
            {
                NewBattle(rnd, TwoPlayers, ThreePlayers);

            }

            GameOver();

        }

        //Banner and Main Menu
        private static int WelcomeScreen()
        {
            int input;
            while (true)
            {
                Console.WriteLine("Welcome to DURF (Deadly Underground Reference Fighting)");
                Console.WriteLine("Version: {0} | Author: Tyler Vermillion ©2017-{1}", Version, DateTime.Now.Year);
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

                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input < 4 && input >= 0)
                    {
                        break;
                    }
                }
                Console.Clear();
            }

            return input;


        }

        //Starts up the Game Character Creation
        private static PlayerClass Startup(bool isAi, AdvancedRNG rnd)
        {

            #region Local Variables + AI Name + Faction Lists
            PlayerClass player1;
            int playerType;
            string name;
            string faction;
            bool npc;



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

                int aiName = rnd.GetNext(aiNameList.Count);
                int aiFaction = rnd.GetNext(aiFactionList.Count);

                faction = aiFactionList.ElementAt(aiFaction); //AdvancedRNG AI Name
                name = aiNameList.ElementAt(aiName); //AdvancedRNG AI Faction
                npc = true;


                playerType = rnd.GetNext(4);

            }
            else
            {
                string type;
                while (true)
                {
                    int reTry;
                    SetPlayerData(out playerType, out name, out faction, out npc);
                    if (playerType == 0) type = "Ninja";
                    else if (playerType == 1) type = "Mage";
                    else if (playerType == 2) type = "Paladin";
                    else if (playerType == 3) type = "Ranger";
                    else type = "Human";


                    Console.Clear();


                    Console.WriteLine("Your player name is : {0}\nFrom the faction/guild: {1}\nAnd their class is: {2}\nDo you want to change this?", name, faction, type);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("|--Type 0 for no. | Type 1 for yes.--|");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Int32.TryParse(Console.ReadLine(), out reTry))
                    {
                        if (reTry == 0)
                        {
                            Console.WriteLine("Input Confirmed. Moving On");
                            Thread.Sleep(1500);
                            break;
                        }
                        if (reTry == 1)
                        {
                            Console.WriteLine("Input Confirmed. Remaking Player");
                            Thread.Sleep(1500);
                        }
                        else Console.WriteLine("Invalid Input Remaking Player"); Thread.Sleep(1500);
                    }

                }
            }

            #endregion

            #region Player Class Assignment
            if (playerType == 0)
            {
                player1 = new Ninja(name, faction, npc);
            }
            else if (playerType == 1)
            {
                player1 = new Mage(name, faction, npc);
            }
            else if (playerType == 2)
            {
                player1 = new Paladin(name, faction, npc);
            }
            else if (playerType == 3)
            {
                player1 = new Ranger(name, faction, npc);
            }
            else
            {
                player1 = new Human(name, faction, npc);
            }
            #endregion
            Console.WriteLine(player1.ToString());
            return player1;

        }

        private static void SetPlayerData(out int playerType, out string name, out string faction, out bool npc)
        {
            Console.WriteLine("\nWhat will the name of your Adventurer be?");
            name = Console.ReadLine();
            Console.WriteLine("What clan of faction are is your adventurer a part of?");
            faction = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("What class is your adventurer?\n" +
                    "0: Ninja\n" +
                    "1: Mage\n" +
                    "2: Paladin\n" +
                    "3: Ranger");
                if (Int32.TryParse(Console.ReadLine(), out playerType))
                {
                    if (playerType >= 0 && playerType < 4)
                    {
                        npc = false;
                        break;
                    }
                }
                Console.Clear();
            }
        }

        //Creates Players
        private static void CreatePlayer(out bool TwoPlayers, out bool ThreePlayers, out PlayerClass player1, ref PlayerClass player2, ref PlayerClass player3, int gameType, AdvancedRNG rnd)
        {
            switch (gameType)
            {
                case 0:
                    TwoPlayers = true;
                    ThreePlayers = true;
                    PlayerCount = 3;
                    player1 = Startup(false, rnd);//Player
                    player2 = Startup(true, rnd);//AI
                    player3 = Startup(true, rnd);//AI
                    break;
                case 1:
                    TwoPlayers = true;
                    ThreePlayers = true;
                    PlayerCount = 3;
                    player1 = Startup(false, rnd);//Player
                    player2 = Startup(false, rnd);//Player
                    player3 = Startup(true, rnd);//AI
                    break;
                case 2:
                    TwoPlayers = true;
                    ThreePlayers = true;
                    PlayerCount = 3;
                    player1 = Startup(false, rnd);//Player
                    player2 = Startup(false, rnd);//Player
                    player3 = Startup(false, rnd);//Player
                    break;
                case 3:
                    TwoPlayers = false;
                    ThreePlayers = false;
                    PlayerCount = 1;
                    player1 = Startup(false, rnd);//Player
                    break;
                case 4:
                    TwoPlayers = true;
                    ThreePlayers = false;
                    PlayerCount = 2;
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

        //Starts New Battle And Generates Enemies
        private static void NewBattle(AdvancedRNG rnd, bool TwoPlayers, bool ThreePlayers)
        {
            AdvancedRNG enemyRND = new AdvancedRNG();

            bool battle = true;

            Dictionary<string, RandomEnemy> enemyList = BattleCommenceNotice(enemyRND);
            //Renders Stats
            DisplayStats(TwoPlayers, ThreePlayers, enemyList);

            EnemyCount = enemyList.Count();

            var combatOrder = setCombatOrder(TwoPlayers, ThreePlayers, enemyList);
#if DEBUG
            int i = 0;
            foreach (var item in combatOrder)
            {
                i++;
                Console.WriteLine("Order: {4} | Name: {0} | Speed: {1} | Unit ID: {2} | NPC: {3}", item.Key.Name, item.Key.Speed, item.Key.ID, item.Key.NPC, i);
            }
            Console.ReadLine();
#endif
            do
            {
                battle = ConductBattle(rnd, TwoPlayers, ThreePlayers, battle, enemyList, combatOrder);

            } while (battle == true);
        }

        //Warning the User of the Incoming Battle And Creates Enemies
        private static Dictionary<string, RandomEnemy> BattleCommenceNotice(AdvancedRNG enemyRND)
        {
            #region Battle Commence Notice
            int enemies = enemyRND.GetNext(1, 4);
            Dictionary<string, RandomEnemy> enemyList = new Dictionary<string, RandomEnemy>();
            for (int i = 0; i < enemies; i++)
            {
                enemyList.Add("enemy" + i, new RandomEnemy(enemyRND));
            }

            enemyList.ElementAt(0).Value.ID = 3;
            if (enemies >= 2)
            {
                enemyList.ElementAt(1).Value.ID = 4;
            }
            if (enemies >= 3)
            {
                enemyList.ElementAt(2).Value.ID = 5;
            }
            if (enemies >= 4)
            {
                enemyList.ElementAt(3).Value.ID = 6;
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ENEMY ENCOUNTER!\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hit enter to Commence the Battle >");
            Console.Clear();
            #endregion
            return enemyList;
        }

        //All battle code
        private static bool ConductBattle(AdvancedRNG rnd, bool TwoPlayers, bool ThreePlayers, bool battle, Dictionary<string, RandomEnemy> enemyList, List<KeyValuePair<Character, int>> combatOrder)
        {
            //Loop Over All Combatants
            foreach (var combatant in combatOrder)
            {
                string playerTurn;
                int id = combatant.Key.ID;

                //Checks for winning/Losing battle
                battle = CheckLoseBattle(TwoPlayers, ThreePlayers, battle);
                battle = CheckWinBattle(battle, enemyList);
                if (battle == false) break;

                if (combatant.Key.HealthPoints <= 0)
                {
                    combatant.Key.IsDead = true;
                    Console.WriteLine("{0} Is Dead and cannot make a move", combatant.Key.Name);
                    Console.ReadLine();
                }
                //NPC Actions
                else if (combatant.Key.NPC == true && combatant.Key.HealthPoints > 0)
                {
                    //Enemy Random Decision
                    if (id > 2 && id < 7)
                    {
                        int number = rnd.GetNext(1, 100);

                        RandomEnemy currentEnemy = (RandomEnemy)combatant.Key;
                        if (currentEnemy.HealthPoints >= (currentEnemy.MaxHealthPoints * .7))
                        {
                            EnemyHighHPDecision(rnd, enemyList, number, currentEnemy, TwoPlayers, ThreePlayers);
                        }
                        if (currentEnemy.HealthPoints <= (currentEnemy.MaxHealthPoints * .5))
                        {
                            EnemyMidHPDecision(rnd, enemyList, number, currentEnemy, TwoPlayers, ThreePlayers);
                        }
                        if (currentEnemy.HealthPoints <= (currentEnemy.MaxHealthPoints * .3))
                        {
                            EnemyLowHPDecision(rnd, enemyList, number, currentEnemy, TwoPlayers, ThreePlayers);
                        }
                    }
                    //AI Ally Random Decision
                    if (id < 3 && id > 0)
                    {
                        NPCRandomAction(rnd, enemyList, combatant, TwoPlayers, ThreePlayers);
                    }

                }
                //Human Actions
                else if (combatant.Key.NPC == false && combatant.Key.HealthPoints > 0)
                {

                    playerTurn = combatant.Key.Name;



                    if (id == 0)
                    {
                        RunPlayerCombat(TwoPlayers, ThreePlayers, enemyList, combatant, playerTurn);

                    }
                    if (id == 1)
                    {
                        RunPlayerCombat(TwoPlayers, ThreePlayers, enemyList, combatant, playerTurn);
                    }
                    if (id == 2)
                    {
                        RunPlayerCombat(TwoPlayers, ThreePlayers, enemyList, combatant, playerTurn);
                    }
                }
                //If Combatant is Dead
    
                //Failed
                else
                {
                    throw new FormatException();
                }


            }
            

            
            return battle;
        }

        //Displays All combatants stats
        private static void DisplayStats(bool TwoPlayers, bool ThreePlayers, Dictionary<string, RandomEnemy> enemyList)
        {
            Console.Clear();
            #region Player Stats
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Your Party's Stats");
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" {0} {1}'s HP: {2}/{6} | Speed: {3} | {4}: {5}", player1.Type, player1.Name, player1.HealthPoints, player1.Speed, player1.GetExtraStat(), player1.GetExtraStatValue(), player1.MaxHealthPoints);
            if (TwoPlayers == true)
            { Console.WriteLine(" {0} {1}'s HP: {2}/{6} | Speed: {3} | {4}: {5}", player2.Type, player2.Name, player2.HealthPoints, player2.Speed, player2.GetExtraStat(), player2.GetExtraStatValue(), player2.MaxHealthPoints); }
            if (ThreePlayers == true)
            { Console.WriteLine(" {0} {1}'s HP: {2}/{6} | Speed: {3} | {4}: {5}", player3.Type, player3.Name, player3.HealthPoints, player3.Speed, player3.GetExtraStat(), player3.GetExtraStatValue(), player3.MaxHealthPoints); }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________________________");
            #endregion

            #region Enemy Stats
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enemy's Stats");
            Console.WriteLine("_____________________________________________________________________________");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var count in enemyList)
            {
                Console.WriteLine(" {0} {1}'s HP: {2}/{4} | Speed: {3}", count.Value.Name, count.Value.Type, count.Value.HealthPoints, count.Value.Speed, count.Value.MaxHealthPoints);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("_____________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }

        //Enemy Low Hp Decision
        private static void EnemyLowHPDecision(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, int number, RandomEnemy currentEnemy, bool TwoPlayers, bool ThreePlayers)
        {
            if (number >= 30)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.Heal();
            }
            if (number < 30)
            {
                EnemySpecialAttacking(rnd, enemyList, currentEnemy, TwoPlayers, ThreePlayers);
            }
        }

        //Enemy Mid Hp Decision
        private static void EnemyMidHPDecision(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, int number, RandomEnemy currentEnemy, bool TwoPlayers, bool ThreePlayers)
        {
            if (number >= 60)
            {
                EnemySpecialAttacking(rnd, enemyList, currentEnemy, TwoPlayers, ThreePlayers);
            }
            if (number >= 30 && number < 60)
            {
                EnemyAttacking(rnd, enemyList, currentEnemy, TwoPlayers, ThreePlayers);


            }
            if (number < 30)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.Heal();
            }
        }

        //Enemy High Hp Decision
        private static void EnemyHighHPDecision(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, int number, RandomEnemy currentEnemy, bool TwoPlayers, bool ThreePlayers)
        {
            if (number >= 40)
            {
                EnemyAttacking(rnd, enemyList, currentEnemy, TwoPlayers, ThreePlayers);
            }
            if (number >= 20 && number < 40)
            {
                EnemySpecialAttacking(rnd, enemyList, currentEnemy, TwoPlayers, ThreePlayers);
            }
            if (number < 20)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.Heal();
            }
        }

        //Goes over Enemy's Normal Attack
        private static void EnemyAttacking(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, RandomEnemy currentEnemy, bool TwoPlayers, bool ThreePlayers)
        {
            int num = rnd.GetNext(0, PlayerCount - 1);


            if (num == 0)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.RandomAttack(player1);
                Console.ReadLine();
            }
            else if (num == 1)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.RandomAttack(player2);
                Console.ReadLine();

            }
            else if (num == 2)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.RandomAttack(player3);
                Console.ReadLine();

            }

        }

        //Goes over Enemy's Special Attack
        private static void EnemySpecialAttacking(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, RandomEnemy currentEnemy, bool TwoPlayers, bool ThreePlayers)
        {
            int num = rnd.GetNext(0, PlayerCount);


            if (num == 0)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.RandomSpecialAttack(player1);
                Console.ReadLine();
            }
            else if (num == 1)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.RandomSpecialAttack(player2);
                Console.ReadLine();

            }
            else if (num == 2)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentEnemy.RandomSpecialAttack(player3);
                Console.ReadLine();

            }

        }

        //AI NPC Partner Actions
        private static void NPCRandomAction(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, KeyValuePair<Character, int> combatant, bool TwoPlayers, bool ThreePlayers)
        {
            int number = rnd.GetNext(1, 100);
            PlayerClass currentPlayer = (PlayerClass)combatant.Key;

            if (currentPlayer.HealthPoints >= (currentPlayer.MaxHealthPoints * .5))
            {
                if (number >= 40)
                {
                    NPCPlayerAttacking(rnd, enemyList, currentPlayer, TwoPlayers, ThreePlayers);

                }
                if (number >= 20 && number < 40)
                {
                    NPCPlayerSpecialAttacking(rnd, enemyList, currentPlayer, TwoPlayers, ThreePlayers);
                }
                if (number < 20)
                {
                    Console.Clear();
                    DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                    currentPlayer.Heal();
                }
            }
            if (currentPlayer.HealthPoints <= (currentPlayer.MaxHealthPoints * .3))
            {
                if (number >= 60)
                {
                    NPCPlayerSpecialAttacking(rnd, enemyList, currentPlayer, TwoPlayers, ThreePlayers);
                }
                if (number >= 30 && number < 60)
                {
                    NPCPlayerAttacking(rnd, enemyList, currentPlayer, TwoPlayers, ThreePlayers);

                }
                if (number < 30)
                {
                    Console.Clear();
                    DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                    currentPlayer.Heal();
                }
            }
            if (currentPlayer.HealthPoints <= (currentPlayer.MaxHealthPoints * .15))
            {
                if (number >= 15)
                {
                    Console.Clear();
                    DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                    currentPlayer.Heal();
                }
                if (number < 15)
                {
                    Console.Clear();
                    DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                    NPCPlayerSpecialAttacking(rnd, enemyList, currentPlayer, TwoPlayers, ThreePlayers);
                }
            }

        }

        //Friendly Parnter Special Attacking
        private static void NPCPlayerSpecialAttacking(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, PlayerClass currentPlayer, bool TwoPlayer, bool ThreePlayer)
        {
            bool loop = true;
            while (loop == true)
            {
                int num = rnd.GetNext(1, EnemyCount);
                int atk;
                if (num == 1)
                {
                    atk = SpecialAttackSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayer, ThreePlayer);
                }
                else if (num == 2)
                {
                    atk = SpecialAttackSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayer, ThreePlayer);

                }
                else if (num == 3)
                {
                    atk = SpecialAttackSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayer, ThreePlayer);
                }
                else if (num == 4)
                {
                    atk = SpecialAttackSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayer, ThreePlayer);
                }
                else
                {
                    Console.WriteLine("This is Not supposed to happen");
                }

            }

        }

        private static int SpecialAttackSpecificEnemy(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, PlayerClass currentPlayer, ref bool loop, int num, bool TwoPlayers, bool ThreePlayers)
        {
            int atk = rnd.GetNext(0, 2);
            if (enemyList["enemy" + (num - 1)].IsDead == false)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.SpecialAttack(enemyList["enemy" + (num - 1)], atk, currentPlayer.SpecialAttacks, enemyList["enemy" + (num - 1)].Name);
                loop = false;
                Console.ReadLine();
            }

            return atk;
        }

        //Friendly Parnter Normal Attacking
        private static void NPCPlayerAttacking(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, PlayerClass currentPlayer, bool TwoPlayers, bool ThreePlayers)
        {


            bool loop = true;
            while (loop == true)
            {
                int num = rnd.GetNext(1, EnemyCount);
                int atk;

                if (num == 1)
                {
                    atk = AttackingSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayers, ThreePlayers);
                }
                else if (num == 2)
                {
                    atk = AttackingSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayers, ThreePlayers);

                }
                else if (num == 3)
                {
                    atk = AttackingSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayers, ThreePlayers);

                }
                else if (num == 4)
                {
                    atk = AttackingSpecificEnemy(rnd, enemyList, currentPlayer, ref loop, num, TwoPlayers, ThreePlayers);

                }
                else
                {
                    Console.WriteLine("This is Not supposed to happen");
                    Console.ReadLine();
                }
            }

            
        }

        private static int AttackingSpecificEnemy(AdvancedRNG rnd, Dictionary<string, RandomEnemy> enemyList, PlayerClass currentPlayer, ref bool loop, int num, bool TwoPlayers, bool ThreePlayers)
        {
            int atk = rnd.GetNext(0, 4);
            if (enemyList["enemy" + (num - 1)].IsDead == false)
            {
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.Attack(enemyList["enemy" + (num - 1)], atk, enemyList["enemy" + (num - 1)].Name);
                loop = false;
                Console.ReadLine();
            }

            return atk;
        }

        //Runs the Human Player Combat Section
        private static void RunPlayerCombat(bool TwoPlayers, bool ThreePlayers, Dictionary<string, RandomEnemy> enemyList, KeyValuePair<Character, int> combatant, string playerTurn)
        {
            PlayerClass currentPlayer = (PlayerClass)combatant.Key;
            bool running = true;
            while (running == true)
            {
                #region Render Battle Menu
                int x = 0;
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                DisplayCombatName(TwoPlayers, ThreePlayers, enemyList, playerTurn);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("|--Menu Select the Number of the Option You Want--|");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("0: Attacks");
                Console.WriteLine("1: Special Attacks");
                Console.WriteLine("2: Heal");
                //Console.WriteLine("3: Skip To Boss");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("_____________________________________________________________________________");
                Console.ForegroundColor = ConsoleColor.White;

                #endregion

                int value;
                if (Int32.TryParse(Console.ReadLine(), out value))
                {
                    if (value == 0)
                    {
                        while (true)
                        {
                            int attacker;
                            #region Player Attacking using Generic Attacks

                            currentPlayer.ReadAttacks();
                            int num;
                            if (Int32.TryParse(Console.ReadLine(), out num) && num >= 0 && num <= 4)
                            {
                                while (true)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                                    Console.WriteLine("Pick an Enemy: ");
                                    foreach (var count in enemyList)
                                    {
                                        Console.WriteLine("{0}: Attack {1} {2}", x, count.Value.Name, count.Value.Type);
                                        x++;
                                    }

                                    Console.ForegroundColor = ConsoleColor.White;
                                    //attacker = Int32.Parse(Console.ReadLine());
                                    if (Int32.TryParse(Console.ReadLine(), out attacker) && attacker >= 0 && attacker <= enemyList.Count)
                                    {
                                        running = Attacking(enemyList, currentPlayer, running, attacker, num, TwoPlayers, ThreePlayers);
                                        break;
                                    }

                                }
                                break;
                                #endregion
                            }
                        }


                    }
                    else if (value == 1)
                    {
                        #region Player Attacking using Special Attacks

                        while (true)
                        {
                            int attacker;


                            currentPlayer.ReadSpecialAttacks();
                            int num;
                            if (Int32.TryParse(Console.ReadLine(), out num) && num >= 0 && num <= 2)
                            {
                                while (true)
                                {

                                    Console.ForegroundColor = ConsoleColor.DarkYellow;

                                    Console.WriteLine("Pick an Enemy: ");
                                    foreach (var count in enemyList)
                                    {
                                        Console.WriteLine("{0}: Attack {1} {2}", x, count.Value.Name, count.Value.Type);
                                        x++;
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;
                                    if (Int32.TryParse(Console.ReadLine(), out attacker) && attacker >= 0 && attacker <= enemyList.Count)
                                    {
                                        running = SpecialAttacking(enemyList, currentPlayer, running, num, attacker, TwoPlayers, ThreePlayers);
                                        break;
                                    }
                                }
                                break;

                            }
                        }

                        #endregion


                    }
                    else if (value == 2)
                    {
                        Console.Clear();
                        DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                        currentPlayer.Heal();
                        running = false;

                    }
                }


            }
        }

        //Runs the Human Player Special Attacking Section
        private static bool SpecialAttacking(Dictionary<string, RandomEnemy> enemyList, PlayerClass currentPlayer, bool running, int num, int attacker, bool TwoPlayers, bool ThreePlayers)
        {
            if (attacker == 0 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy0"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.SpecialAttack(val, num, currentPlayer.SpecialAttacks, val.Name);
                Console.ReadLine();
                running = false;
            }

            if (attacker == 1 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy1"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.SpecialAttack(val, num, currentPlayer.SpecialAttacks, val.Name);
                Console.ReadLine();
                running = false;
            }

            if (attacker == 2 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy2"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.SpecialAttack(val, num, currentPlayer.SpecialAttacks, val.Name);
                Console.ReadLine();
                running = false;
            }
            if (attacker == 3 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy3"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.SpecialAttack(val, num, currentPlayer.SpecialAttacks, val.Name);
                Console.ReadLine();
                running = false;
            }

            return running;
        }

        //Runs the Human Player Normal Attacking Section
        private static bool Attacking(Dictionary<string, RandomEnemy> enemyList, PlayerClass currentPlayer, bool running, int attacker, int num, bool TwoPlayers, bool ThreePlayers)
        {
            if (attacker == 0 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy0"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.Attack(val, num, val.Name);
                Console.ReadLine();
                running = false;
            }

            if (attacker == 1 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy1"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.Attack(val, num, val.Name);
                Console.ReadLine();
                running = false;
            }

            if (attacker == 2 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy2"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.Attack(val, num, val.Name);
                Console.ReadLine();
                running = false;
            }

            if (attacker == 3 && enemyList["enemy" + attacker] != null && enemyList["enemy" + attacker].IsDead != true)
            {
                var val = enemyList["enemy3"];
                Console.Clear();
                DisplayStats(TwoPlayers, ThreePlayers, enemyList);
                currentPlayer.Attack(val, num, val.Name);
                Console.ReadLine();
                running = false;
            }

            return running;
        }

        //Displays who the Attacking Player is
        private static void DisplayCombatName(bool TwoPlayers, bool ThreePlayers, Dictionary<string, RandomEnemy> enemyList, string playerTurn)
        {
            Console.Clear();
            DisplayStats(TwoPlayers, ThreePlayers, enemyList);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("|---|{0}'s turn to attack|---|", playerTurn);
            Console.WriteLine("_____________________________________________________________________________");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Sets the Combat Order based on speed
        public static List<KeyValuePair<Character, int>> setCombatOrder(bool TwoPlayers, bool ThreePlayers, Dictionary<string, RandomEnemy> enemyList)
        {
            Dictionary<Character, int> order = new Dictionary<Character, int>();


            order.Add(player1, player1.Speed);
            if (TwoPlayers == true)
                order.Add(player2, player2.Speed);
            if (ThreePlayers == true)
                order.Add(player3, player3.Speed);

            foreach (var enemy in enemyList)
            {
                order.Add(enemy.Value, enemy.Value.Speed);
            }

            List<KeyValuePair<Character, int>> combatOrder = order.ToList();


            combatOrder.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            return combatOrder;


        }

        //Checks if the Players lose the battle
        private static bool CheckLoseBattle(bool TwoPlayers, bool ThreePlayers, bool battle)
        {
            if (TwoPlayers == false && ThreePlayers == false)
            {
                if (player1.HealthPoints <= 0)
                {
                    battle = false;
                    HasLost = true;
                }
            }
            if (TwoPlayers == true)
            {
                if (player1.HealthPoints <= 0 && player2.HealthPoints <= 0)
                {
                    battle = false;
                    HasLost = true;
                }
            }
            if (ThreePlayers == true)
            {
                if (player1.HealthPoints <= 0 && player2.HealthPoints <= 0 && player3.HealthPoints <= 0)
                {
                    battle = false;
                    HasLost = true;
                }
            }

            return battle;
        }

        //Checks if the Players win the battle
        private static bool CheckWinBattle(bool battle, Dictionary<string, RandomEnemy> enemyList)
        {
            if (EnemyCount == 1)
            {
                if (enemyList["enemy0"].IsDead == true)
                {
                    Console.WriteLine("Congrats! You have Defeated the Enemy!");
                    Console.ReadLine();
                    battle = false;
                }
            }
            if (EnemyCount == 2)
            {
                if (enemyList["enemy0"].IsDead == true && enemyList["enemy1"].IsDead)
                {
                    Console.WriteLine("Congrats! You have Defeated the Enemies!");
                    Console.ReadLine();

                    battle = false;
                }
            }
            if (EnemyCount == 3)
            {
                if (enemyList["enemy0"].IsDead == true && enemyList["enemy1"].IsDead && enemyList["enemy2"].IsDead)
                {
                    Console.WriteLine("Congrats! You have Defeated the Enemies!");
                    Console.ReadLine();

                    battle = false;

                }
            }
            if (EnemyCount == 4)
            {
                if (enemyList["enemy0"].IsDead == true && enemyList["enemy1"].IsDead && enemyList["enemy2"].IsDead && enemyList["enemy3"].IsDead)
                {
                    Console.WriteLine("Congrats! You have Defeated the Enemies!");
                    Console.ReadLine();

                    battle = false;

                }
            }

            return battle;
        }

        //Ends the Game
        private static void GameOver()
        {
            Console.Clear();
            Console.WriteLine(
@"Your party has parished to the never ending herds. Do not fear adventurer
your legacy will still live on. You have existed in the world only to
run the course to the end of your natural life. Maybe one day you
will defy all odds and rise among the ashes and live once again. But for now
you are dead and for now you're adventure is over and will live in memory
of those who you have encountered along your journey.

                See You In The Next Life Adventurer");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"
  ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
 ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
 ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
      ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                     ░                   ");
            Console.ReadLine();
        }


    }


}
