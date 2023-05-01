using System;
using EZInput;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using myGame.GL;

namespace myGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player hawk = new Player();
            Enemy1 c1 = new Enemy1();
            List<Bullet> b = new List<Bullet>();
            List<E1Fire> e1 = new List<E1Fire>();
            hawk.playerX = 15;
            hawk.playerY = 30;
            c1.enemy1X = 5;
            c1.enemy1Y = 5;
            int score = 0;

            int playerHealth = 50, playerlives = 3, enemy1Health = 100;
            int timer = 0, enemy1slower = 0, fireofEnemy1timer = 0;
            char[,] border = new char[37, 122];
            char[,] player = new char[4, 7]{{ ' ', ' ', ' ',(char)238, ' ', ' ', ' '},
                                         { '-', '-', '{', 'H', '}', '-', '-'},
                                         { ' ', '/', '/', (char)219, '\\', '\\', ' '},
                                         { ' ', ' ', ' ', (char)89, ' ', ' ', ' '}};
            char[,] enemy1 = new char[3, 7] {{ (char)171, (char)171, ' ', (char)238, ' ', (char)187, (char)187},
                                             { ' ', (char)171, '\\', 'C', '/', (char)187, ' '},
                                             { ' ', ' ', ' ', '?', ' ', ' ', ' ' }};
            string enemy1direction = "right";
            bool playerenemycollide = true;

            Console.Clear();
            WelcomeScreen();
            string choice = "";
            while (choice != "3")
            {
                GameLogo();
                choice = Mainmenu();
                if (choice == "1")
                {
                    bool gamerunning = true;
                    Console.Clear();
                    ReadData(border);
                    PrintMaze(border);
                    PrintPlayer(hawk, ref player, ref border);
                    while (gamerunning)
                    {
                        Thread.Sleep(90);
                        PrintScore(ref score, ref playerHealth, ref playerlives, ref enemy1Health);
                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            MoveHawkUp(hawk ,ref border, ref player, ref score, ref playerHealth);
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            MoveHawkDown(hawk, ref border, ref player, ref playerHealth, ref score);
                        }
                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            MoveHawkLeft(hawk, ref border, ref player, ref playerHealth, ref score);
                        }
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            MoveHawkRight(hawk, ref border, ref player, ref playerHealth, ref score);
                        }
                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                            GenerateBullet(hawk, b, ref border);
                        }
                       

                        if (timer == 28)
                        {
                            GenerateFood(ref border);
                            timer = 0;
                        }
                        timer++;

                        if (enemy1slower == 4)            // Slowest Movement Enemy 
                        {
                            if (enemy1Health > 0)
                            {
                                playerenemycollide = MoveGhostInLine(ref enemy1direction, ref border, c1, enemy1);
                            }
                            if (enemy1Health <= 0)
                            {
                                EraseChicken1(c1, ref border);
                                Makinggameover(ref score);
                                gamerunning = false;
                                break;
                            }
                            enemy1slower = 0;
                        }
                        enemy1slower++;

                        if (fireofEnemy1timer == 10)
                        {
                            if (enemy1Health > 0)
                            {
                                Generateenemy1fire(c1, e1, border);
                                fireofEnemy1timer = 0;
                            }
                        }
                        fireofEnemy1timer++;

                        if (playerHealth <= 0)
                        {
                            playerlives--;
                            playerHealth = 50;
                            // regenrating player when he loses one life
                            ErasePlayer(hawk, ref border);
                            hawk.playerX = 15;
                            hawk.playerY = 30;
                            PrintPlayer(hawk, ref player, ref border);
                        }
                        if (playerlives == 0)
                        {
                            Makinggameover(ref score);
                            gamerunning = false;       // finishing game when all lives of player are finished
                        }
                        CheckPlayerHealth(hawk, ref border, ref playerHealth);
                        Moveenemy1fire(e1, ref border);
                        MoveBullet( b , ref border);
                        bulletcollisionwithEnemy1(ref score, b, c1, ref enemy1Health);
                        checkplayercollisionwithenemy(hawk, ref playerHealth, border);
                        }
                    // resetting game stats
                    score = 0;
                    playerlives = 3;
                    playerHealth = 50;
                    enemy1Health = 100;
                    hawk.playerX = 15;
                    hawk.playerY = 30;
                    timer = 0;
                    enemy1slower = 0;
                    c1.enemy1X = 5;
                    c1.enemy1Y = 5;
                    enemy1Health = 100;
                    fireofEnemy1timer = 0;

                }
                if (choice == "2")
                {
                    string further = "0";
                    while (further != "3")
                    {
                        GameLogo();
                        further = Optionmenu();
                        if (further == "1")
                        {
                            GameLogo();
                            KeysMenu();
                            Thread.Sleep(100);
                        }
                        if (further == "2")
                        {
                            GameLogo();
                            InstructionsMenu();
                            Thread.Sleep(100);
                        }
                    }
                }
                else if (choice != "1" && choice != "2" && choice != "3")
                {
                    Console.Write("       invalid choice!Press any key to enter again   ");
                    choice = Console.ReadLine();
                }
                Console.ReadKey();
            }
        }

        static string Mainmenu()
        {
            string option;
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine("           <><><>---<>---<>---<>---<>---<>---<>---<>---<<           Menu            >>---<>---<>---<>---<>---<>---<>---<><><>");
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine();
            Console.WriteLine("         1. Start  ");
            Console.WriteLine("         2. Option ");
            Console.WriteLine("         3. Exit   ");
            Console.Write("         select an option...");
            option = Console.ReadLine();
            return option;
        }
        static string Optionmenu()
        {
            string option;
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine("        <><><>---<>---<>---<>---<>---<>---<>---<<           Menu>>options       >>---<>---<>---<>---<>---<>---<>---<><><>");
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine();
            Console.WriteLine("       1. key");
            Console.WriteLine("       2. Intructions");
            Console.WriteLine("       3. Go Back");
            option = Console.ReadLine();
            return option;
        }
        static void KeysMenu()
        {
            Console.WriteLine();
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine("        <><><>---<>---<>---<>---<>---<>---<<           Menu>>options>>keys       >>---<>---<>---<>---<>---<>---<>---<><><>");
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine();
            Console.WriteLine("      1. UP       go up");
            Console.WriteLine("      2. DOWN     go down");
            Console.WriteLine("      3. RIGHT    go right");
            Console.WriteLine("      4. LEFT     go left");
            Console.WriteLine("      5. SPACE    fire ");
            Console.WriteLine("      6. ESCAPE   end game");
            Console.WriteLine("      7. P        pause game");
            Console.Write("      press any key to go back..   ");
            Console.ReadKey();
            Thread.Sleep(100);
        }
        static void InstructionsMenu()
        {
            Console.WriteLine();
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine("        <><><>---<>---<>---<>---<>---<>---<>---<<      Menu>>options>>instructions     >>---<>---<>---<>---<>---<>---<>---<><><>");
            Console.WriteLine("      <><><>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>---<>----<>---<>---<>---<>---<>---<>----<>----<>---<><><>");
            Console.WriteLine("         SAVE THE WORLD!");
            Console.WriteLine("               You  are  the  only  hope  of  humans. Only  you  can  the  save  the  Earth   from   this  invasion.");
            Console.WriteLine("               To  kill  all  the  chickens   you  have  first  save  yourself  from   their  eggs. You  can   move ");
            Console.WriteLine("               around  in  space,  by  pressing  arrows  keys   you   can  move  the  hawk  up/down/right/left. The ");
            Console.WriteLine("               chicken (cruella)is  moving  horizontally  and   hitting  you  with  eggs. The  chicken (zelda) is   ");
            Console.WriteLine("               ranomly  moving  and  firing  eggs  the  most  powerful  of  them  Tiana  is  the   master   of  them.");
            Console.WriteLine("               After  killing  her  the  first   wave   will be  over  and  next   wave  will   come  in  next  version");
            Console.WriteLine("               of  the  game. Bext  of  luck  for  the  first wave! ");
            Console.WriteLine("            Press any key to continue.....");
            Console.ReadKey();
        }
        static void ReadData(char[,] border)
        {
            StreamReader borderfile = new StreamReader("D:\\OOP\\maze.txt");
            string line;
            int row = 0;
            while ((line = borderfile.ReadLine()) != null)
            {
                for (int x = 0; x < 122; x++)
                {
                    border[row, x] = line[x];
                }
                row++;
            }

            borderfile.Close();
        }
        static void PrintMaze(char[,] maze)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void WelcomeScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(43, 7);
            Console.WriteLine("                              :*:                             ");
            Console.SetCursorPosition(43, 8);
            Console.WriteLine("                            -::.::-                           ");
            Console.SetCursorPosition(43, 9);
            Console.WriteLine("                            -.\\ /.-                          ");
            Console.SetCursorPosition(43, 10);
            Console.WriteLine("                          -= ++0 0++ += -                     ");
            Console.SetCursorPosition(43, 11);
            Console.WriteLine("                            --+ %> +--                         ");
            Console.SetCursorPosition(43, 12);
            Console.WriteLine("     ...::.::...           -+=#%%#=+-            ...::.::...    ");
            Console.SetCursorPosition(43, 13);
            Console.WriteLine("           ..::..::..       =%%%%%%=      ..::..::..            ");
            Console.SetCursorPosition(43, 14);
            Console.WriteLine("               ...:::.::...@@@@@@@@@@...:::.::...                ");
            Console.SetCursorPosition(43, 15);
            Console.WriteLine("....:::::..               @@@@@@@@@@@@              ..:::::.... ");
            Console.SetCursorPosition(43, 16);
            Console.WriteLine("    ...:::.::..         %%%%%%%%%%%%%%%%       ::.:::..:..      ");
            Console.SetCursorPosition(43, 17);
            Console.WriteLine("          ..:..::.::..%%%%%%%%%%%%%%%%%%%% ::..::.:::..         ");
            Console.SetCursorPosition(43, 18);
            Console.WriteLine("                     $$%################%$$                     ");
            Console.SetCursorPosition(43, 19);
            Console.WriteLine("                     %%%%%%%%%%%@@@@@@@@@@@                     ");
            Console.SetCursorPosition(43, 20);
            Console.WriteLine("                     $%%%%%%%%%%%%%%%%%%%%$                     ");
            Console.SetCursorPosition(43, 21);
            Console.WriteLine("                   +==++@@@@@@@%%@@@@@@@++==+                   ");
            Console.SetCursorPosition(43, 22);
            Console.WriteLine("                       ...::::....:::::...                      ");
            Console.SetCursorPosition(43, 23);
            Console.WriteLine("                    ::::::::::::::::::::::::                   ");
            Console.SetCursorPosition(43, 24);
            Console.WriteLine("                  :==*******==:   :==*******==:                ");
            Console.SetCursorPosition(43, 25);
            Console.WriteLine("                  :******+***:    +***+-+****+-                ");
            Console.SetCursorPosition(43, 26);
            Console.WriteLine("                  :***+-+****:    =*+**+-+***+                 ");
            Console.SetCursorPosition(43, 27);
            Console.WriteLine();
            Console.SetCursorPosition(43, 28);
            Console.WriteLine();
            Console.SetCursorPosition(43, 29);
            Console.WriteLine();
            Console.SetCursorPosition(43, 30);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(45, 31);
            Console.Write("          LOADING ");
            Console.SetCursorPosition(63, 31);
            Load();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Load()
        {
            char character;
            character = (char)238;
            for (int i = 0; i < 26; i++)
            {
                Console.Write(character);
                Thread.Sleep(100);
            }
        }
        static void GameLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("     $$$$$$\\  $$\\       $$\\           $$\\                                     $$$$$$\\                                    $$\\                      ");
            Console.WriteLine("   $$  __$$\\ $$ |      \\__|          $$ |                                    \\_$$  _|                                   $$ |                     ");
            Console.WriteLine("   $$ /  \\__|$$$$$$$\\  $$\\  $$$$$$$\\ $$ |  $$\\  $$$$$$\\  $$$$$$$\\              $$ |  $$$$$$$\\ $$\\    $$\\ $$$$$$\\   $$$$$$$ | $$$$$$\\   $$$$$$\\   $$$$$$$\\ ");
            Console.WriteLine("   $$ |      $$  __$$\\ $$ |$$  _____|$$ | $$  |$$  __$$\\ $$  __$$\\             $$ |  $$  __$$\\ $$\\  $$  |\\____$$\\ $$  __$$ |$$  __$$\\ $$  __$$\\ $$  _____| ");
            Console.WriteLine("   $$ |      $$ |  $$ |$$ |$$ /      $$$$$$  / $$$$$$$$ |$$ |  $$ |            $$ |  $$ |  $$ |\\$$\\$$  / $$$$$$$ |$$ /  $$ |$$$$$$$$ |$$ |  \\__|\\$$$$$$\\  ");
            Console.WriteLine("   $$ |  $$\\ $$ |  $$ |$$ |$$ |      $$  _$$<  $$   ____|$$ |  $$ |            $$ |  $$ |  $$ | \\$$$  / $$  __$$ |$$ |  $$ |$$   ____|$$ |       \\____$$\\ ");
            Console.WriteLine("   \\$$$$$$  |$$ |  $$ |$$ |\\$$$$$$$\\ $$ | \\$$\\ \\$$$$$$$\\ $$ |  $$ |          $$$$$$\\ $$ |  $$ |  \\$  /  \\$$$$$$$ |\\$$$$$$$ |\\$$$$$$$\\ $$ |      $$$$$$$  | ");
            Console.WriteLine("    \\______/ \\__|  \\__|\\__| \\_______|\\__|  \\__| \\_______|\\__|  \\__|          \\______|\\__|  \\__|   \\_/    \\_______| \\_______| \\_______|\\__|      \\_______/ ");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void gameoverborder()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(38, 16);
            Console.Write ("*********************************");
            Console.SetCursorPosition(38, 17);
            Console.Write ("*                               *");
            Console.SetCursorPosition(38, 18);
            Console.Write ("*                               *");
            Console.SetCursorPosition(38, 19);
            Console.Write ("*                               *");
            Console.SetCursorPosition(38, 20);
            Console.Write ("*                               *");
            Console.SetCursorPosition(38, 21);
            Console.Write ("*                               *");
            Console.SetCursorPosition(38, 22);
            Console.Write ("*********************************");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Makinggameover(ref int score)
        {
            Console.Clear();
            gameoverborder();
            Console.SetCursorPosition(46, 18);
            Console.Write("GAME OVER!");
            Console.SetCursorPosition(46, 20);
            Console.Write("YOUR SCORE: " + score);
            Thread.Sleep(4000);
        }
        static void Foodscore(char next, ref int score)
        {
            if (next == '+')
            {
                score = score + 2;
            }
        }

        static void PrintPlayer(Player hawk, ref char[,] player, ref char[,] border)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.SetCursorPosition(hawk.playerY + col, hawk.playerX + row);
                    Console.Write(player[row, col]);
                    border[(hawk.playerX + row), (hawk.playerY + col)] = player[row, col];
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void ErasePlayer(Player hawk, ref char[,] border)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.SetCursorPosition(hawk.playerY + col, hawk.playerX + row);
                    Console.Write(" ");
                    border[hawk.playerX + row, hawk.playerY + col] = ' ';
                }
            }
        }
        static void MoveHawkUp(Player hawk, ref char[,] border, ref char[,] player, ref int score, ref int playerHealth)
        {
            if (border[hawk.playerX - 1, hawk.playerY] == ' ' || border[hawk.playerX - 1, hawk.playerY] == '.' || border[hawk.playerX - 1, hawk.playerY] == '+')
            {
                CheckPlayerHealth(hawk , ref border, ref playerHealth);
                ErasePlayer(hawk , ref border);
                hawk.playerX = hawk.playerX - 1;
                for (int i = 0; i < 6; i++)
                {
                    char next = border[hawk.playerX, hawk.playerY + i];
                    Foodscore(next, ref score);
                }
                PrintPlayer( hawk, ref player, ref border);

            }
        }
        static void MoveHawkDown(Player hawk, ref char[,] border, ref char[,] player, ref int playerHealth, ref int score)
        {
            if (border[hawk.playerX + 4, hawk.playerY] == ' ' || border[hawk.playerX + 4, hawk.playerY] == '.' || border[hawk.playerX + 4, hawk.playerY] == '+')
            {
                CheckPlayerHealth(hawk, ref border, ref playerHealth);
                ErasePlayer(hawk, ref border);
                hawk.playerX = hawk.playerX + 1;
                for (int i = 0; i < 6; i++)
                {
                    char next = border[hawk.playerX+ 3, hawk.playerY + i];
                    Foodscore(next, ref score);
                }
                PrintPlayer(hawk, ref player, ref border);
            }
        }
        static void MoveHawkLeft(Player hawk, ref char[,] border, ref char[,] player, ref int playerHealth, ref int score)
        {
            if (border[hawk.playerX, hawk.playerY - 1] == ' ' || border[hawk.playerX, hawk.playerY - 1] == '.'|| border[hawk.playerX, hawk.playerY - 1] == '+')
            {
                CheckPlayerHealth(hawk, ref border, ref playerHealth);
                ErasePlayer(hawk, ref border);
                hawk.playerY = hawk.playerY - 1;
                for (int i = 0; i < 4; i++)
                {
                    char next = border[hawk.playerX + i, hawk.playerY];
                    Foodscore(next, ref score);
                }
                PrintPlayer(hawk, ref player, ref border);
            }
        }
        static void MoveHawkRight(Player hawk, ref char[,] border, ref char[,] player, ref int playerHealth, ref int score)
        {
            if (border[hawk.playerX, hawk.playerY + 7] == ' ' || border[hawk.playerX, hawk.playerY + 7] == '.' || border[hawk.playerX, hawk.playerY + 7] == '+')
            {
                CheckPlayerHealth(hawk, ref border, ref playerHealth);
                ErasePlayer(hawk, ref border);
                hawk.playerY = hawk.playerY + 1;
                for (int i = 0; i < 4; i++)
                {
                    char next = border[hawk.playerX + i, hawk.playerY + 6];
                    Foodscore(next, ref score);
                }
                PrintPlayer(hawk, ref player, ref border);
            }
        }
        static void PrintChicken1(Enemy1 c1, char[,] enemy1, ref char[,] border)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.SetCursorPosition(c1.enemy1Y + col, c1.enemy1X + row);
                    Console.Write(enemy1[row, col]);
                    border[(c1.enemy1X + row), (c1.enemy1Y + col)] = enemy1[row, col];
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void EraseChicken1(Enemy1 c1, ref char[,] border)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.SetCursorPosition(c1.enemy1Y + col, c1.enemy1X + row);
                    Console.Write(" ");
                    border[(c1.enemy1X + row), (c1.enemy1Y + col)] = ' ';
                }
            }
        }
        static bool MoveGhostInLine(ref string enemy1direction, ref char[,] border, Enemy1 c1, char[,] enemy1)
        {
            if ((enemy1direction == "left") && (border[c1.enemy1X, c1.enemy1Y - 1] == ' ' || border[c1.enemy1X, c1.enemy1Y - 1] == '.'))
            {
                EraseChicken1(c1, ref border);
                c1.enemy1Y = c1.enemy1Y - 1;

                PrintChicken1( c1, enemy1, ref border);
                if (border[c1.enemy1X, c1.enemy1Y - 1] == '&')
                {
                    enemy1direction = "right";
                }
            }
            else if (enemy1direction == "right" && (border[c1.enemy1X, c1.enemy1Y + 7] == ' ' || border[c1.enemy1X, c1.enemy1Y + 7] == '.'))
            {
                EraseChicken1(c1, ref border);

                c1.enemy1Y = c1.enemy1Y + 1;

                PrintChicken1(c1, enemy1, ref border);

                if (border[c1.enemy1X, c1.enemy1Y + 7] == '&')
                {
                    enemy1direction = "left";
                }
            }
            return true;
        }

        static void PrintScore(ref int score, ref int playerHealth, ref int playerlives, ref int enemy1Health)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(135, 17);
            Console.Write("Total score: " + score);
            Console.SetCursorPosition(135, 19);
            Console.Write("LIVES: " + playerlives);
            Console.SetCursorPosition(135, 20);
            Console.Write("Player health: " + playerHealth + " ");
            if(enemy1Health > 0)
            {
                Console.SetCursorPosition(135, 23);
                Console.Write("Enenmy1 health: " + enemy1Health + " ");
            }
            else
            {
                Console.SetCursorPosition(135, 23);
                Console.Write("Enemy1 health: " + "FINISHED!! ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void GenerateFood(ref char[,] border)
        {
            Random rnd = new Random();
            int randnum1 = rnd.Next(4, 119);
            int randnum2 = rnd.Next(3, 29);
            if (border[randnum2, randnum1] == ' ')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(randnum1, randnum2);
                Console.Write("+");
                Console.ForegroundColor = ConsoleColor.White;
                border[randnum2, randnum1] = '+';
            }
        }

        static void PrintBullet(int x, int y, ref char[,] border)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(y, x);
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.White;
            border[x, y] = '.';
        }
        static void EraseBullet(int x, int y, ref char[,] border)
        {
            Console.SetCursorPosition(y, x);
            Console.Write(" ");
            border[x, y] = ' ';
        }
        static void GenerateBullet(Player hawk, List<Bullet> b, ref char[,] border)
        {
            Bullet printb = new Bullet();
            printb.bulletX= hawk.playerX - 1;
            printb.bulletY = hawk.playerY + 3;
            char next = border[(printb.bulletX), (printb.bulletY)];
            if (next != '&')
            {
                PrintBullet(printb.bulletX, printb.bulletY, ref border);
                b.Add(printb);
            }
        }
        static void MoveBullet(List<Bullet> b, ref char[,] border)
        {
            for (int i = 0; i < b.Count; i++)
            {
                char next = border[b[i].bulletX - 1, b[i].bulletY];
                if (next == ' ')
                {
                    EraseBullet(b[i].bulletX, b[i].bulletY, ref border);
                    b[i].bulletX--;
                    PrintBullet(b[i].bulletX, b[i].bulletY, ref border);
                }
                else
                {
                    EraseBullet(b[i].bulletX, b[i].bulletY, ref border);
                    b.RemoveAt(i);
                }
            }
        }
        static void Printenemy1fire(int x, int y, ref char[,] border)
        {
            Console.SetCursorPosition(y, x);
            Console.Write("O");
            border[x, y] = 'O';
        }
        static void Generateenemy1fire(Enemy1 c1, List<E1Fire> e1, char[,] border)
        {
            E1Fire ef = new E1Fire();
            ef.enemy1fX = c1.enemy1X + 3;
            ef.enemy1fY = c1.enemy1Y + 3;
            char next = border[(ef.enemy1fX), (ef.enemy1fY)];
            if (next == ' ')
            {
                Printenemy1fire(ef.enemy1fX, ef.enemy1fY, ref border);
                e1.Add(ef);
            }
        }
        static void Moveenemy1fire(List<E1Fire> e1, ref char[,] border)
        {
            for (int i = 0; i < e1.Count ; i++)
            {
                char next = border[e1[i].enemy1fX, e1[i].enemy1fY + 1];
                char nextr = border[e1[i].enemy1fX + 1, e1[i].enemy1fY];
                char nextl = border[e1[i].enemy1fX, e1[i].enemy1fY - 1];
                if (next == ' ' && nextr == ' ' && nextl == ' ')
                {
                    EraseBullet(e1[i].enemy1fX, e1[i].enemy1fY, ref border);
                    e1[i].enemy1fX++;
                    Printenemy1fire(e1[i].enemy1fX, e1[i].enemy1fY, ref border);
                }
                else
                {
                    EraseBullet(e1[i].enemy1fX, e1[i].enemy1fY, ref border);
                    e1.RemoveAt(i);
                }
            }
        }
        static void CheckPlayerHealth(Player hawk, ref char[,] border, ref int playerHealth)
        {
            char next = border[hawk.playerX - 1, hawk.playerY];
            checkDamage(next, ref  playerHealth);
            char next1 = border[hawk.playerX - 1 , hawk.playerY+1];
            checkDamage(next1, ref  playerHealth);
            char next2 = border[hawk.playerX - 1 , hawk.playerY+2];
            checkDamage(next2, ref  playerHealth);
            char next3 = border[hawk.playerX - 1, hawk.playerY + 3];
            checkDamage(next3, ref  playerHealth);
            char next4 = border[hawk.playerX - 1, hawk.playerY +4];
            checkDamage(next4, ref  playerHealth);
            char next5 = border[hawk.playerX - 1 , hawk.playerY + 5];
            checkDamage(next5, ref  playerHealth);
            char next6 = border[hawk.playerX - 1, hawk.playerY + 6];
            checkDamage(next6, ref  playerHealth);
        }
        static void checkDamage(char next, ref int playerHealth)
        {
            if (next == 'O')
            {
                playerHealth--;
            }
        }
        static void bulletcollisionwithEnemy1(ref int score, List<Bullet> b, Enemy1 c1, ref int enemy1health)
        {
            if (enemy1health > 0)
            {
                for (int i = 0; i < b.Count; i++)
                {
                    if(c1.enemy1X + 2 == b[i].bulletX && (c1.enemy1Y == b[i].bulletY || c1.enemy1Y+1  == b[i].bulletY || c1.enemy1Y+2 == b[i].bulletY || c1.enemy1Y+3 == b[i].bulletY || c1.enemy1Y+4 == b[i].bulletY || c1.enemy1Y+5 == b[i].bulletY || c1.enemy1Y+6 == b[i].bulletY))
                    {
                        score++;
                        enemy1health--;
                    }
                    if (c1.enemy1X + 1 == b[i].bulletX && (c1.enemy1Y == b[i].bulletY || c1.enemy1Y + 6 == b[i].bulletY))
                    {
                        score++;
                        enemy1health--;
                    }
                }
            }
        }
        static void checkplayercollisionwithenemy(Player hawk, ref int playerHealth, char[,] border)
        {
            // checking all coordinates of player for presence of enemy
            char next = border[hawk.playerX, hawk.playerY];
            playerenemycollision(next, ref playerHealth);
            char next1 = border[hawk.playerX , hawk.playerY+1];
            playerenemycollision(next1, ref playerHealth);
            char next2 = border[hawk.playerX , hawk.playerY+2];
            playerenemycollision(next2, ref playerHealth);
            char next3 = border[hawk.playerX-1, hawk.playerY+3];
            playerenemycollision(next3, ref playerHealth);
            char next4 = border[hawk.playerX , hawk.playerY+4];
            playerenemycollision(next4, ref playerHealth);
            char next5 = border[hawk.playerX , hawk.playerY+5];
            playerenemycollision(next5, ref playerHealth);
            char next6 = border[hawk.playerX, hawk.playerY+6];
            playerenemycollision(next6, ref playerHealth);
            char next7 = border[hawk.playerX + 1, hawk.playerY - 1];
            playerenemycollision(next7, ref playerHealth);
            char next8 = border[hawk.playerX + 1, hawk.playerY + 7];
            playerenemycollision(next8, ref playerHealth);
            char next9 = border[hawk.playerX+2, hawk.playerY];
            playerenemycollision(next9, ref playerHealth);
            char next10 = border[hawk.playerX+2, hawk.playerY + 6];
            playerenemycollision(next10, ref playerHealth);
            char next11 = border[hawk.playerX+3, hawk.playerY];
            playerenemycollision(next11, ref playerHealth);
            char next12 = border[hawk.playerX + 3, hawk.playerY + 1];
            playerenemycollision(next12, ref playerHealth);
            char next13 = border[hawk.playerX + 3, hawk.playerY + 2];
            playerenemycollision(next13, ref playerHealth);
            char next14 = border[hawk.playerX + 4, hawk.playerY + 3];
            playerenemycollision(next14, ref playerHealth);
            char next15 = border[hawk.playerX + 3, hawk.playerY + 4];
            playerenemycollision(next15, ref playerHealth);
            char next16 = border[hawk.playerX + 3, hawk.playerY + 5];
            playerenemycollision(next16, ref playerHealth);
            char next17 = border[hawk.playerX + 3, hawk.playerY + 6];
            playerenemycollision(next17, ref playerHealth);
        }
        static void playerenemycollision(char next,ref int playerHealth)
        {
            if (next != '&' && next != ' ' && next != '+' && next != 'O' && next != '.')   // deducting 1 life if player touches enemy
            {
                playerHealth = 0;
            }
        }
    }
}
