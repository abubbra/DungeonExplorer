using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using static DungeonExplorer.roomtypes;

namespace DungeonExplorer
{
    public class Room
    {
        // Git test 
        protected string description;
        public string item { get; set; }

        //Room room1descrip = new Room("the room fills with a cold and sharp air, lava flows down the walls and the floor is covered in bones and skulls");

        //Represents a single room in the game with a description and possibly an item

        protected string roomdescription;
        

        public Room()
        {

            // this.description = description;   // the class for the room description
            //item = item;
        }
        public virtual void setroomdetails()
        {

        }
        public virtual string GetDescription()
        {
            //Console.WriteLine(description);
            //Console.WriteLine("you find a health potion here");

            return description;
        }
        public string GetItem()
        {
            // Console.WriteLine("you picked up a health potion ");
            return item;
        }

    }

    

    internal class roomtypes
    {
        public class Entrance : Room
        {
            public Entrance()
            {
                description = "you stand in the entrance of the dungeon, lava flows down the walls and the floor is covered in bones and skulls";
                item = "health potion";
            }
        }
        public class GoblinRoom : Room
        {
            public GoblinRoom()
            {
                description = "a goblin appears before you";
                item = "goblin club";
            }
        }
        public class TrollRoom : Room
        {
            public TrollRoom()
            {
                description = "a troll appears before you";
                item = "troll eyeball";
            }
        }

        public class BabyDragonRoom : Room
        {
            public BabyDragonRoom()
            {
                description = "a baby dragon appears before you";
                item = "dragon blade";
            }
        }

        public class GollemRoom : Room
        {
            public GollemRoom()
            {
                description = "the room around you is covered in weird rock formations and crystals in the wall. a gollem blocks your path";
                item = "golem stone heart";
            }
        }

        public class EmptyRoom : Room
        {
            public EmptyRoom()
            {
                description = "this room is empty";
                item = null;
            }
        }
    }




    public class GameMap
    {
        private Room[,] rooms;
        private int playerX = 0;
        private int playerY = 0;






        public GameMap()
        {
            rooms = new Room[3, 3]
            {
                {new Entrance(), new GoblinRoom(), new TrollRoom()},
                {new BabyDragonRoom(), new GollemRoom(), new EmptyRoom ()},
                {new EmptyRoom(), new EmptyRoom(), new EmptyRoom()}


            };

            
        }

        public  Room GetCurrentRoom()
        {
            return rooms[playerY, playerX];
        }
        

        public void displaymap()
        {
            for (int y = 0; y < rooms.GetLength(0); y++)
            {
                for (int x = 0; x < rooms.GetLength(1); x++)
                {
                    if (rooms[y, x] != null)
                        Console.Write("[Room]");
                    else
                        Console.WriteLine("[empty]");
                }
                Console.WriteLine();
            }
        }

        public void CurrentRoomDetails()
        {
            Room currentroom = rooms[playerY, playerX];

            if (currentroom != null)
            {
                Console.WriteLine(" you are currently in :");
                Console.WriteLine(currentroom.GetDescription());

                if (string.IsNullOrEmpty(currentroom.GetItem()))
                {
                    Console.WriteLine("you found an item:  {currentroom.GetItem()}");
                }
                else
                {
                    Console.WriteLine("there is nothing in this room");
                }
            }
            else
            {
                Console.WriteLine("you are in an empty room");
            }


        }

        public void MovePlayer(string direction)
        {
            switch (direction.ToLower())
            {
                case "north":
                    if (playerY > 0)                   
                        playerY--;                        
                    break;
                case "south":
                    if (playerY < rooms.GetLength(0) - 1)
                    
                        playerY++;
                   
                    break;
                case "east":
                    if (playerX < rooms.GetLength(1) - 1)
                    
                        playerX++;
                     
                    break;
                case "west":
                    if (playerX > 0)
                    
                        playerX--;
                  
                    break;
                default:
                    Console.WriteLine("Invalid direction");
                    break;
            }
        }


        public abstract class Item
        {
            public string Name { get; set; }
            public Item(string name)
            {
                Name = name;
            }
            public abstract void Use(Player player);


        }

        public class healthpotion : Item
        {
            private int healingamount = 30;
            public healthpotion() : base("health potion")
            {

            }

            public override void Use(Player player)
            {
                player.Heal(healingamount);
                Console.WriteLine("you used a health potion and healed {healingamount} health");
            }

        }

        //public class weapon : Item
        //{
        //    public int bonusdamageamount { get; set; }
        //    public dragonblade(string name, int bonusdamageamount) : base(name)
        //    {
        //        bonusdamageamount = bonusdamageamount;
        //    }
           

        //    public override void Use(Player player)
        //    {
        //        player.equipweapon(this);
        //        Console.WriteLine("you equipped the {name}! your attack damage now does 30 more damage");
        //    }

        //}
          
        
        

            
        







        }
}
