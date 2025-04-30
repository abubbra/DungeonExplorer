using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using static DungeonExplorer.roomtypes;

namespace DungeonExplorer
{
    public class Room
    {
        protected string description { get; set; } 
        public bool hasItem { get; protected set; } = true;
        public Item item { get; protected set; }                      
        public string GetDescription() => description;
        public Item GetItem()
        {
            hasItem = false; //sets the item to not have an item
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
                item = new Weapon("sword", 10);
            }
        }
        public class GoblinRoom : Room
        {
            public GoblinRoom()
            {
                description = "a goblin appears before you";
                item = new HealthPotion("small health oil", 20);
            }
        }
        public class TrollRoom : Room
        {
            public TrollRoom()
            {
                description = "a troll appears before you";
                item = new Weapon("axe", 20);
            }
        }
        public class BabyDragonRoom : Room
        {
            public BabyDragonRoom()
            {
                description = "a baby dragon appears before you";
                item = new HealthPotion("big health oil", 35);
            }
        }
        public class GollemRoom : Room
        {
            public GollemRoom()
            {
                description = "the room around you is covered in weird rock formations and crystals in the wall. a gollem blocks your path";
                item = new Weapon("Spear of light", 50);
            }
        }
        public class FinalRoom : Room
        {
            public FinalRoom()
            {
                description = "this room is empty";
                hasItem = false;
            }
        }
    }

    public class GameMap
    {
        private List<Room> rooms = new List<Room>();
        public GameMap()
        {
            rooms = new List<Room>
            {
                new Entrance(),
                new GoblinRoom(),
                new TrollRoom(),
                new BabyDragonRoom(),
                new GollemRoom(),
                new FinalRoom(),
            };
        }
        public Room getNewRoom(int origIndex,string direction)
        {
            try
            {
                if (direction == "left")
                {
                    Program.game.player.currentRoomIndex = origIndex - 1;
                    return rooms[origIndex - 1];
                }
                else if (direction == "right")
                {
                    Program.game.player.currentRoomIndex = origIndex + 1;
                    return rooms[origIndex + 1];
                }
                else
                {
                    Console.WriteLine("invalid input");
                    return rooms[origIndex];
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("you cannot go that way");
                return null;
            };
        }
        public void displaymap(Room current)
        {
            foreach (Room r in rooms)
            {
                Console.Write(r.GetDescription() + " ");
            }
            Console.WriteLine("\nYou are in " + current.GetDescription());
        }
    }
}
