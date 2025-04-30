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
        public bool hasItem { get; set; } = true;
        public Item item { get; set; }
        public Monster monster { get; set; }
        public bool hasMonster { get; set; } = false;
        public string GetDescription() => description;
        
        public Item GetItem()
        {
            if (hasItem == false) 
                return null;
            hasItem = false;
            return item;
        }
    }
    internal class roomtypes
    {
        public class Entrance : Room
        {
            public Entrance()
            {
                description = "You stand in the entrance of the dungeon. Lava flows down the walls and the floor is covered in bones and skulls.";
                item = new Weapon("Rusty Sword", 10);
                monster = null;
                hasMonster = false;
            }
        }
        public class GoblinRoom : Room
        {
            public GoblinRoom()
            {
                description = "A dark chamber with flickering torches. A vicious goblin appears before you!";
                item = new HealthPotion("Small Health Potion", 20);
                monster = new Monster("Goblin", 30, 5);
                hasMonster = true;
            }
        }
        public class TrollRoom : Room
        {
            public TrollRoom()
            {
                description = "A massive cavern with a horrible stench. A troll lumbers towards you!";
                item = new Weapon("Battle Axe", 20);
                monster = new Monster("Troll", 50, 8);
                hasMonster = true;
            }
        }
        public class BabyDragonRoom : Room
        {
            public BabyDragonRoom()
            {
                description = "A chamber filled with smoke and embers. A baby dragon spreads its wings menacingly!";
                item = new HealthPotion("Large Health Potion", 35);
                monster = new Monster("Baby Dragon", 60, 12);
                hasMonster = true;
            }
        }
        public class GolemRoom : Room
        {
            public GolemRoom()
            {
                description = "The room is covered in strange rock formations and glowing crystals. An ancient golem blocks your path!";
                item = new Weapon("Spear of Light", 50);
                monster = new Monster("Crystal Golem", 100, 15);
                hasMonster = true;
            }
        }
        public class FinalRoom : Room
        {
            public FinalRoom()
            {
                description = "A grand chamber with ancient runes covering the walls. An enormous dragon sleeps on a mountain of treasure!";
                item = new Weapon("Dragon Slayer", 75);
                monster = new Monster("Ancient Dragon", 150, 25);
                hasMonster = true;
            }
        }
    }

    public class GameMap
    {
        private List<Room> rooms;
        
        public GameMap()
        {
            rooms = new List<Room>
            {
                new roomtypes.Entrance(),
                new roomtypes.GoblinRoom(),
                new roomtypes.TrollRoom(),
                new roomtypes.BabyDragonRoom(),
                new roomtypes.GolemRoom(),
                new roomtypes.FinalRoom()
            };
        }

        public Room getNewRoom(int currentIndex, string direction)
        {
            int newIndex = currentIndex;
            
            if (direction.ToLower() == "right")
            {
                newIndex++;
            }
            else if (direction.ToLower() == "left")
            {
                newIndex--;
            }                        
            return rooms[newIndex];
        }

        public Room getCurrentRoom(int index)
        {            
            return rooms[index];
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
