using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DungeonExplorer
{
    public class InputVerify
    {
        public static string GetInput(List<string> ValidInputs)
        {
            string input = Console.ReadLine();
            if (ValidInputs.Contains(input))
                return input;
            else
                while (!ValidInputs.Contains(input))
                {
                    Console.WriteLine("Invalid input, please try again");
                    input = Console.ReadLine();
                }
            return input;
        }
    }
    public class Program
    {
        public static Game game;
        public static void Main(string[] Args)
        {
            game = new Game();
        }
    }
}
