using System;

namespace DungeonExplorer
{
    public interface IDamagable
    {
        void TakeDamage(int damage);
        void Heal(int amount);
    }

    public abstract class Creature : IDamagable
    {
        public string name { get; protected set; }
        public int maxhealth { get; protected set; }
        public int currenthealth { get; set; }
        protected int baseDamage;
        public bool isAlive { get; protected set; } = true;

        public Creature(string name, int maxhealth, int baseDamage = 0)
        {
            this.currenthealth = maxhealth;
            this.name = name;
            this.maxhealth = maxhealth;
            this.baseDamage = baseDamage;
        }

        public abstract void onDeath();

        public virtual void TakeDamage(int damage)
        {
            currenthealth -= damage;
            Console.WriteLine($"{name} takes {damage} damage!");
            
            if (currenthealth <= 0)
            {
                currenthealth = 0;
                isAlive = false;
                onDeath();
            }
        }

        public virtual void Heal(int amount)
        {
            currenthealth += amount;
            if (currenthealth > maxhealth)
            {
                currenthealth = maxhealth;
            }
            Console.WriteLine($"{name} heals for {amount} health!");
        }

        public abstract int Attack();

        public void DisplayHealth()
        {
            Console.WriteLine($"{name} has {currenthealth} out of {maxhealth} health");
        }
    }

    public class Monster : Creature
    {
        public Monster(string name, int health, int damage) : base(name, health, damage)
        {
        }

        public override void onDeath()
        {
            Console.WriteLine($"{name} has been defeated!");
        }

        public override int Attack()
        {
            Random rnd = new Random();
            int damage = baseDamage + rnd.Next(-2, 3); // Random damage
            Console.WriteLine($"{name} attacks for {damage} damage!");
            return damage;
        }
    }
}