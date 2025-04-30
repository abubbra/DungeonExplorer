using System;

namespace DungeonExplorer
{
	public interface IDamageable
	{
		void takeDamage(int amount);
		int health { get; }
	}
	

	
}
