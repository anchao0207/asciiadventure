using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

/*
 Cool ass stuff people could implement:
 > jumping
 > attacking
 > randomly moving monsters
 > smarter moving monsters
*/
namespace asciiadventure {
    public class Game {
        private Random random = new Random();
        private static Boolean Eq(char c1, char c2){
            return c1.ToString().Equals(c2.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        private static string Menu() {
            return "WASD to move\nIJKL to attack/interact\nEnter command: ";
        }

        private static void PrintScreen(Screen screen, string message, string menu) {
            Console.Clear();
            Console.WriteLine(screen);
            Console.WriteLine($"\n{message}");
            Console.WriteLine($"\n{menu}");
        }
        public void Run() {
            Console.ForegroundColor = ConsoleColor.Green;
            List<Screen> screens = new List<Screen>();
            List<Player> players = new List<Player>();
            List<Treasure> treasures = new List<Treasure>();
            List<List<Mob>> Mobs = new List<List<Mob>>();
            List<NextFloor> Ups = new List<NextFloor>();
            List<PreviousFloor> Downs = new List<PreviousFloor>();
            List<Wall> Walls = new List<Wall>();
            for (int i = 0; i < 5; i++)
            {
                screens.Add(new Screen(10, 10));
                players.Add(new Player(0, 0, screens[i], "Zelda"));
                if(i!=4)
                    Ups.Add(new NextFloor(0, 9, screens[i]));
                if(i!=0)
                    Downs.Add(new PreviousFloor(9, 0, screens[i]));
                if (i == 0)
                    treasures.Add(new Treasure(6, 2, screens[i]));
                if (i == 1||i==4)
                    treasures.Add(new Treasure(5, 5, screens[i]));
                if (i == 2)
                    treasures.Add(new Treasure(9, 9, screens[i]));
                if (i == 3)
                    treasures.Add(new Treasure(2, 7, screens[i]));
                List<Mob> mobs = new List<Mob>();
                if (i == 0) 
                    mobs.Add(new Mob(9, 8, screens[i]));
                else if (i == 1)
                    mobs.Add(new Mob(6, 7, screens[i]));
                else if (i == 2)
                {
                    mobs.Add(new Mob(3, 7, screens[i]));
                    mobs.Add(new Mob(7, 7, screens[i]));
                }
                else if (i == 3)
                {
                    mobs.Add(new Mob(2, 6, screens[i]));
                    mobs.Add(new Mob(9, 4, screens[i]));
                }
                else
                {
                    mobs.Add(new Mob(2, 8, screens[i]));
                    mobs.Add(new Mob(5, 1, screens[i]));
                    mobs.Add(new Mob(3, 5, screens[i]));
                }
                Mobs.Add(mobs);
                if (i == 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        new Wall(1, 2 + j, screens[i]);
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        new Wall(3 + j, 4, screens[i]);
                    }
                }
                if (i == 1)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        new Wall(2, 2 + j, screens[i]);
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        new Wall(2+j, 2, screens[i]);
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        new Wall(2+j, 6, screens[i]);
                    }
                }
                if (i == 2)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (j == 4 || j == 2 || j == 3)
                            continue;
                        new Wall(2, 2 + j, screens[i]);
                    }
                    for (int j = 0; j < 7; j++)
                    {
                        if (j == 4 || j == 2 || j == 3)
                            continue;
                        new Wall(8, j+2, screens[i]);
                    }
                    for (int j = 0; j < 7; j++)
                    {
                        if (j == 4 || j == 2 || j == 3)
                            continue;
                        new Wall(2 + j, 2, screens[i]);
                    }
                    for (int j = 0; j < 7; j++)
                    {
                        if (j == 4 || j == 2 || j == 3)
                            continue;
                        new Wall(2 + j, 8, screens[i]);
                    }
                }
                if (i == 3)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        new Wall(1, 1 + j, screens[i]);
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        if (j == 3||j==4)
                            continue;
                        new Wall(3, 1+j, screens[i]);
                    }
                    new Wall(2, 1, screens[i]);
                    new Wall(2, 8, screens[i]);
                    for (int j = 0; j < 5; j++)
                    {
                        new Wall(j+4, 3, screens[i]);
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        new Wall(j+4, 6, screens[i]);
                    }
                }
                if (i == 4)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        new Wall(1, 1 + j, screens[i]);
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        new Wall(8, 1 + j, screens[i]);
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (j == 2)
                            continue;
                        new Wall(3, 3 + j, screens[i]);
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (j == 2)
                            continue;
                        new Wall(6, 3 + j, screens[i]);
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        new Wall(4+j, 3, screens[i]);
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        new Wall(4 + j, 7, screens[i]);
                    }
                    for (int j = 0; j < 6; j++)
                    {
                        if (j == 3)
                            continue;
                        new Wall(j+2, 1, screens[i]);
                    }
                }
            }
            Screen screen = screens[0];
            int level = 0;
            // initially print the game board
            PrintScreen(screen, "Welcome!", Menu());
            
            Boolean gameOver = false;
            
            while (!gameOver) {
                char input = Console.ReadKey(true).KeyChar;

                String message = "";

                if (Eq(input, 'q'))
                {
                    break;
                }
                else if (Eq(input, 'w'))
                {
                    message +=players[level].Move(-1, 0);
                    if (message == "Exploded")
                        gameOver = true;
                }
                else if (Eq(input, 's'))
                {
                    message += players[level].Move(1, 0);
                    if (message == "Exploded")
                        gameOver = true;
                }
                else if (Eq(input, 'a'))
                {
                    message += players[level].Move(0, -1);
                    if (message == "Exploded")
                        gameOver = true;
                }
                else if (Eq(input, 'd'))
                {
                    message += players[level].Move(0, 1);
                    if (message == "Exploded")
                        gameOver = true;
                }
                else if (Eq(input, 'i'))
                {
                    message += players[level].Action(-1, 0) ;
                    if (message == "Move to next floor")
                    {
                        screen = screens[level + 1];
                        level++;
                    }
                    if (message == "Move to previous floor")
                    {
                        screen = screens[level - 1];
                        level--;
                    }
                }
                else if (Eq(input, 'k'))
                {
                    message += players[level].Action(1, 0);
                    //fix this need to check for up or down
                    if (message == "Move to next floor")
                    {
                        screen = screens[level + 1];
                        level++;
                    }
                    if(message== "Move to previous floor")
                    {
                        screen = screens[level - 1];
                        level--;
                    }
                }
                else if (Eq(input, 'j'))
                {
                    message += players[level].Action(0, -1);
                    if (message == "Move to next floor")
                    {
                        screen = screens[level + 1];
                        level++;
                    }
                    if (message == "Move to previous floor")
                    {
                        screen = screens[level - 1];
                        level--;
                    }
                }
                else if (Eq(input, 'l'))
                {
                    message += players[level].Action(0, 1);
                    if (message == "Move to next floor")
                    {
                        screen = screens[level + 1];
                        level++;
                    }
                    if (message == "Move to previous floor")
                    {
                        screen = screens[level - 1];
                        level--;
                    }
                }
                else if(Eq(input,' '))
                {
                    new Boom(players[level].Row, players[level].Col, screen);
                    message = "Boom planted\n";
                } else if (Eq(input, 'v')) {
                    // TODO: handle inventory
                    message = "You have nothing\n";
                } else {
                    message = $"Unknown command: {input}";
                }

                // OK, now move the mobs
                foreach (Mob mob in Mobs[level]){
                    // TODO: Make mobs smarter, so they jump on the player, if it's possible to do so
                    List<Tuple<int, int>> moves = screen.GetLegalMoves(mob.Row, mob.Col);
                    if (moves.Count == 0){
                        continue;
                    }
                    // mobs move randomly
                    //var (deltaRow, deltaCol) = moves[random.Next(moves.Count)];
                    if ((players[level].Row - mob.Row) > 0&&moves.Count>1)
                        moves.RemoveAll(item => item.Item1 < 0);
                    if ((players[level].Row - mob.Row) < 0 && moves.Count > 1)
                        moves.RemoveAll(item => item.Item1 > 0);
                    if ((players[level].Col - mob.Col) > 0 && moves.Count > 1)
                        moves.RemoveAll(item => item.Item2 < 0);
                    if ((players[level].Col - mob.Col) < 0 && moves.Count > 1)
                        moves.RemoveAll(item => item.Item2 > 0);
                    Tuple<int, int> T = moves[random.Next(moves.Count)];
                    int deltaRow = T.Item1;
                    int deltaCol = T.Item2;
                    if (screen[mob.Row + deltaRow, mob.Col + deltaCol] is Player){
                        // the mob got the player!
                        mob.Token = "*";
                        message += "A MOB GOT YOU! GAME OVER\n";
                        gameOver = true;
                    }
                    if (screen[mob.Row + deltaRow, mob.Col + deltaCol] is Boom)
                    {
                        // the mob hit the boom!
                        screen[mob.Row + deltaRow, mob.Col + deltaCol].Token = "*";
                        screen[mob.Row , mob.Col] = null;
                        message += "A MOB HIT BY THE BOOM\n";
                        Mobs[level].Remove(mob);
                        break;
                    }
                    mob.Move(deltaRow, deltaCol);
                }

                PrintScreen(screen, message, Menu());
            }
        }

        public static void Main(string[] args){
            Game game = new Game();
            game.Run();
        }
    }
}