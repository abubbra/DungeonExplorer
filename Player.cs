using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public int currentRoomIndex = 0;
        private Weapon equippedWeapon = null;
        
        public override int Attack()
        {
            int damage = baseDamage;
            if (equippedWeapon != null)            
                damage += equippedWeapon.damage;
            
            Console.WriteLine($"{name} attacks for {damage} damage!");
            return damage;
        }

        public override void onDeath()
        {
            Console.WriteLine($"Game Over! {name} has fallen in battle...\nPress enter to leave");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public Player(string name, int health) : base(name, health, 5)
        {
            Inventory = new List<Item>();
        }

        public List<Item> Inventory { get; private set; }

        public void scout(Room room)
        {
            Console.WriteLine(room.GetDescription());
            if (room.hasItem)
            {
                Console.WriteLine($"You have found a {room.item.Name}");
                Console.WriteLine("Do you want to pick it up? (y/n)");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    PickUpItem(room.GetItem());
                }
            }
        }
        public void PickUpItem(Item item)
        {
            if (item != null)
            {
                Inventory.Add(item);
                Console.WriteLine($"{name} picked up {item.Name}");
            }
        }

        public void UseItem(Item itemName)
        {            
            itemName.Use(this);
            Inventory.Remove(itemName);
                
            if (itemName is Weapon weapon)
            {
                if (equippedWeapon != null)
                {
                    Inventory.Add(equippedWeapon); // Put old weapon back in inventory
                    Console.WriteLine($"{equippedWeapon.Name} has been unequipped.");
                }
                equippedWeapon = weapon;
            }          
        }

        public void showinventory(string query = "default")
        {
            List<Item> showItems = query == "default" 
                ? Inventory 
                : Inventory.Where(i => i.type.ToLower() == query.ToLower()).ToList();

            if (showItems.Count == 0)
            {
                Console.WriteLine("Inventory is empty");
                return;
            }

            Console.WriteLine("\nCurrently in your inventory:");

            for (int i = 0; i < showItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {showItems[i].Name} ({showItems[i].type})");
            }

            if (equippedWeapon != null)
            {
                Console.WriteLine($"\nEquipped weapon: {equippedWeapon.Name}");
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1) Use/Equip item");
            Console.WriteLine("2) Filter by weapons");
            Console.WriteLine("3) Filter by potions");
            Console.WriteLine("4) Show all items");
            Console.WriteLine("5) Return to game");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (showItems.Count != 0)
                    {
                        try
                        {
                            Console.WriteLine("\nEnter the number of the item you want to use (or 0 to cancel):");
                            int itemIndex = int.Parse(Console.ReadLine());
                            if (itemIndex > 0 && itemIndex <= showItems.Count)
                            {
                                UseItem(showItems[itemIndex - 1]);
                            }
                            else if (itemIndex != 0)
                            {
                                Console.WriteLine("Invalid item number.");
                            }
                        } catch
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                    }
                    showinventory();
                    break;
                case "2":
                    showinventory("weapon");
                    break;
                case "3":
                    showinventory("potion");
                    break;
                case "4":
                    showinventory("default");
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    showinventory();
                    break;
            }
        }
    }
}
