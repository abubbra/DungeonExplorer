using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item
    {
        public string type { get; protected set; }
        public string Name { get; protected set; }
        public Item(string _name)
        {
            this.Name = _name;
            this.type = type;
        }

        public virtual Player Use(Player player)
        {
            Console.WriteLine("Cannot be used. Press enter to return");
            Console.ReadLine();
            return player;
        }
    }
    public class HealthPotion : Item
    {
        public int healAmount { get; protected set; }
        public HealthPotion(string _name, int _healAmount) : base(_name)
        {
            this.healAmount = _healAmount;
            type = "potion";
        }
        public override Player Use(Player player)
        {
            player.Heal(healAmount);
            Console.WriteLine($"{player.name} used {Name} and healed for {healAmount} health");
            return player;
        }
    }
    public class Weapon : Item
    {
        public int Damage { get; private set; }
        public Weapon(string _name, int damage) : base(_name)
        {
            type = "weapon";
            Damage = damage;
        }
    }
}
