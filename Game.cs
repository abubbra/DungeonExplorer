using System;
using System.Media;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;

namespace DungeonExplorer
{
    public class Game
    {
        private GameMap gamemap;
        private Player player;
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
                Console.WriteLine("game options: 1)check health 2)inventory stats 3) continue 4) quit game");
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
                        Console.WriteLine("you have chosen to quit the game");
                        System.Threading.Thread.Sleep(500);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" the player option you chose is not valid so please try again");                        
                        break;
                }
            }
                
        }


        private void moveplayer()
        {
            Console.WriteLine("which direction would you like to move to ? (north, east, south, west)");
            string direction = Console.ReadLine().ToLower();

            gamemap.MovePlayer(direction);

            Room nextRoom = gamemap.GetCurrentRoom();

            
            if (nextRoom != null)
            {
                Console.Clear();

                EnterRoom(nextRoom);
            }
            else
            {
                Console.WriteLine("sorry but you cant go that way please try a different direction");
            }


            switch (direction)
            {
                case "north":
                    currentRoom = new roomtypes.GoblinRoom();
                    break;

                case "east":
                    currentRoom = new roomtypes.TrollRoom();
                    break;

                case "south":
                    currentRoom = new roomtypes.GollemRoom();
                    break;

                case "west":
                    currentRoom = new roomtypes.BabyDragonRoom();
                    break;

                default:
                    Console.WriteLine("invalid direction choice");
                    return;





                    EnterRoom(currentRoom);
            }
        }
         
        
       


       

        private void EnterRoom(Room room)
        {
            currentRoom = room;

            Console.WriteLine(currentRoom.GetDescription());

            if (string.IsNullOrEmpty(currentRoom.GetItem()))
            {
                Console.WriteLine("you found an item:  {currentRoom.GetItem()} ! do you want to pick it up? (yes/no)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes")     //picks up item if answer is "yes" and they dont if the answer is "no"
                {
                    //player.PickUpItem();
                }
                player.showinventory();
            }
            else
            {
                Console.WriteLine("there is nothing in this room");
            }
            //Console.WriteLine("you find a health potion on the floor of the first room. do you want to pick it up? (yes/no)");
            

        }
    }
}