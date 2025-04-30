using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public abstract class Item
    {
        public string type { get; protected set; }
        public string Name { get; protected set; }

        protected Item(string name)
        {
            this.Name = name;
        }

        public abstract void Use(Player player);
    }

    public class HealthPotion : Item
    {
        private int healAmount;

        public HealthPotion(string name, int healAmount) : base(name)
        {
            this.healAmount = healAmount;
            type = "potion";
        }

        public override void Use(Player player)
        {
            player.Heal(healAmount);
            Console.WriteLine($"{player.name} used {Name} and healed for {healAmount} health!");
        }
    }

    public class Weapon : Item
    {
        public int damage { get; private set; }

        public Weapon(string name, int damage) : base(name)
        {
            this.damage = damage;
            type = "weapon";
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"{Name} has been equipped!");
        }
    }
}
