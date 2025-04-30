using System;

namespace DungeonExplorer
{
	public abstact class Item : Icollectible
	{
		public string name { get; protected set; }

		protected Item (string name)
		{
			Item.name = name;
		}
		public abstract void Use(Player player);
	}

	public class potion : Item
	{
		public int healamount { get; private set; }

		public potion(string name, int healamount) : base(name)
        {
            this.healamount = healamount;
        }

		public override void Use(Player player)
		{
			console.writeline("{player.name}has used potion and will restore {healamount} health");
			player.heal(healamount);
		}
    }

	public class weapon : Item
	{
		public int damage { get; private set; }
		public weaponc(string name, int damage) : base(name)
		{
			this.damage = damage;
		}
        public override void Use(Player player)
        {
            console.writeline("{name} has been equipped");
        }
    }
