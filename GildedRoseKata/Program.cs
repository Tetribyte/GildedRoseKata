using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    class Program
    {
        //<summary>
        //Main program method that constructs input variables, provides UI through Console,
        //and calls the update method on each item before output
        //</summary>
        static void Main(string[] args)
        {
            Operations _ops = new Operations();
            Data _data = new Data();
            List<ItemDTO> itemInput = null;
            List<Item> inventory = new List<Item>();
            string fileInput;
            string fileOutput;

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter a fully defined input path for the file");
                Console.WriteLine(@"i.e. 'C:\Users\user\Desktop\input.txt'");
                fileInput = Console.ReadLine();

                if ((itemInput = _data.ReadInput(fileInput)) != null)
                {
                    Console.WriteLine("File input was successful! Press ENTER to continue");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("File path specified is not valid please hit ENTER and try again.");
                Console.ReadLine();
            } while (itemInput == null);

            inventory = _ops.SortInput(itemInput);

            foreach (var item in inventory)
            {
                item.Update();
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Please enter a fully defined output path for the file");
                Console.WriteLine("Your input path was {0}", fileInput);
                fileOutput = Console.ReadLine();

                 if (_data.WriteOutput(fileOutput, inventory))
                {
                    Console.WriteLine("File output was successful!");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("File path specified is not valid please hit ENTER and try again.");
                Console.ReadLine();
            } while (true);
        }
    }
}