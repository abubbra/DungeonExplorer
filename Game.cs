using System;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;

namespace DungeonExplorer
{
    public class Game
    {
        private GameMap gamemap;
        private Player player;
        private Room currentRoom;
       
        public Game()
        {
            gamemap = new GameMap();
            Console.WriteLine("Welcome to the Dragon Dungeon, hero! State your name...");
            string playername = Console.ReadLine();
            player = new Player(playername, 100);
            currentRoom = gamemap.getCurrentRoom(player.currentRoomIndex);
            Console.WriteLine($"Welcome, {player.name}! Your adventure begins...\n");
            Console.WriteLine(currentRoom.GetDescription());
            Gameloop();
        }

        private void Combat(Monster monster)
        {
            
            
            Console.WriteLine($"\nBattle with {monster.name} begins!");
            
            while (monster.isAlive && player.isAlive)
            {
                Console.WriteLine("\nCombat Options: 1) Attack 2) Use Item 3) Run");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        // Player attacks first
                        int playerDamage = player.Attack();
                        monster.TakeDamage(playerDamage);
                        
                        // Monster counterattacks if still alive
                        if (monster.isAlive)
                        {
                            int monsterDamage = monster.Attack();
                            player.TakeDamage(monsterDamage);
                        }
                        break;
                        
                    case "2":
                        player.showinventory();
                        Console.WriteLine("\nEnter item name to use (or 'cancel'):");
                        string itemChoice = Console.ReadLine();
                        if (itemChoice.ToLower() != "cancel")
                        {
                            try
                            {
                                player.UseItem(player.Inventory.First(i => i.Name.ToLower() == itemChoice.ToLower())); // Find and use that item
                            }
                            catch {  }
                            // Monster gets a free attack if player uses item
                            if (monster.isAlive)
                            {
                                int monsterDamage = monster.Attack();
                                player.TakeDamage(monsterDamage);
                            }
                        }
                        break;                        
                    case "3":
                        if (new Random().Next(2) == 0)
                        {
                            Console.WriteLine("You successfully fled from battle!");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Failed to escape!");
                            int monsterDamage = monster.Attack();
                            player.TakeDamage(monsterDamage);
                        }
                        break;
                        
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                
                // Display current health after each round
                Console.WriteLine("\nStatus:");
                player.DisplayHealth();
                if (monster.isAlive) 
                    monster.DisplayHealth();
            }
        }

        public void Gameloop()
        {
            while (true)               
            {
                Console.WriteLine("\nGame Options:");
                Console.WriteLine("1) Check health");
                Console.WriteLine("2) View inventory");
                Console.WriteLine("3) Search room");
                Console.WriteLine("4) Fight monster");
                Console.WriteLine("5) Move room");
                
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        player.DisplayHealth();
                        break;                      
                    case "2":
                        player.showinventory();
                        break;             
                    case "3":
                        player.scout(currentRoom);
                        break;                        
                    case "4":
                        if (currentRoom.hasMonster && currentRoom.monster.isAlive)                      
                            Combat(currentRoom.monster);
                        else
                            Console.WriteLine("There are no monsters to fight in this room.");                        
                        break;                        
                    case "5":
                        Console.WriteLine("Which direction? (left/right)");
                        while (true)
                        {
                            try
                            {
                                string direction = Console.ReadLine().ToLower();
                                if (direction != "left" && direction != "right")
                                {
                                    Console.WriteLine("Invalid direction. Please enter 'left' or 'right'.");
                                    continue;
                                }
                                
                                Room newRoom = gamemap.getNewRoom(player.currentRoomIndex, direction);                                
                                if (direction == "right") 
                                    player.currentRoomIndex++;
                                else
                                    player.currentRoomIndex--;                                    
                                currentRoom = newRoom;
                                Console.WriteLine("\n" + currentRoom.GetDescription());
                                
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("You cannot go that way.");
                                break;
                            }
                        }
                        break;
                        
                    default:
                        Console.WriteLine("Invalid input. Please choose a number between 1 and 5.");
                        break;
                }
            }                
        }        
    }
}