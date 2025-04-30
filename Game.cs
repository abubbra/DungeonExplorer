using System;
using System.Media;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;

namespace DungeonExplorer
{
    public class Game
    {
        private GameMap gamemap;
        public Player player;
        private Room currentRoom;
       
        public Game()
        {
            gamemap = new GameMap();
            Console.WriteLine("welcome to the dragon dungeon hero, state your name...");
            string playername = Console.ReadLine();
            player = new Player(playername, 100);
            Console.WriteLine("good name you will be remembered: " + player.name);
            Gameloop();
        }
        

        public void Gameloop()
        {
            while (true)               
            {
                Console.WriteLine("game options: 1)check health 2)inventory 3)hunt for floor items 4)fight room monster 5)move room");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        player.DisplayHealth();
                        break;
                    case "2":
                        player.showinventory();
                        break;
                    case "3":
                        Console.WriteLine("click enter to continue");
                        Console.ReadLine();
                        break;
                    case "4":
                        throw null;
                        
                    case "5":
                        Console.WriteLine("left or right");
                        while (true)
                        {
                            try
                            {
                                string direction = Console.ReadLine();
                                currentRoom = gamemap.getNewRoom(player.currentRoomIndex, direction);
                                break;
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("invalid input");
                                break;
                            }
                        };
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }                
        }        
    }
}