
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

        
        public Creature(string name, int maxhealth)
        {
            this.currenthealth = maxhealth;
            this.name = name;
            this.maxhealth = maxhealth;
        }
        public abstract void onDeath();
        public virtual void TakeDamage(int damage)
        {
            currenthealth -= damage;
            if (currenthealth < 0)
            {
                currenthealth = 0;
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
        }
        public abstract int Attack();
        public void DisplayHealth()
        {
            Console.WriteLine($"{name} has {currenthealth} out of {maxhealth}");
        }
    }
}