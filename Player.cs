using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Xml.Schema;

namespace DungeonExplorer
{
    public class Player : Creature
    {
        public override int Attack()
        {
            throw new NotImplementedException();
        }
        public override void onDeath()
        {
            throw new NotImplementedException();
        }

        public Player(string name, int health) : base(name, health) {
            Inventory = new List<Item>();
        }

        public List<Item> Inventory { get; private set; }


        public void PickUpItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine($"{name} picked up {item.Name}");
        }

        public void Useitem(Item item)
        {
            Item founditem = Inventory.Find(i => i.Name == item.Name.ToLower()); //finds the item in the players inventory
            if (item != null) //if the item is in the players inventory
            {
                item.Use(this); //uses the item
                Inventory.Remove(item); //removes the item from the players inventory
            }
            else
            {
                Console.WriteLine("you do not have this item in your inventory"); //if the item is not in the players inventory
            }
        }

        public void showinventory(string query)
        {
            List<Item> showItems = new List<Item>();
            if (query == "default")
                showItems = Inventory; //if the query is default, show all items in the inventory
            else
                showItems = Inventory.Where(i=> i.type == query).ToList(); //filters the players inventory by the query

            if (showItems.Count == 0)
            {
                Console.WriteLine("empty");  //shows that the players inventory is empty 
            }
            else
            {
                Console.WriteLine("currently in your inventory is:");   // shows the players current inventory 
                foreach (var item in showItems)
                {
                    Console.WriteLine($"-{item.Name}  => {item.type}");     //displays the current item in the players inventory
                }
            }
            Console.WriteLine("sort by weapon, or potion, or enter return to return.");
            switch(InputVerify.GetInput(new List<string> {"weapon", "potion", "return" }))
            {
                case "weapon":
                    showinventory("weapon");
                    break;
                case "potion":
                    showinventory("potion");
                    break;
                case "return":
                    break;
            }
        }
        public void showinventory() => showinventory("default"); //overload for the showinventory method, this is used to show the inventory without a query
    }
}
