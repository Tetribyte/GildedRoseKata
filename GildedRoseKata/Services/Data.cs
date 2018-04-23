using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    //<summary>
    //Contains the methods relating to the processing and output of data 
    //</summary>
    public class Data
    {
        //<summary>
        //Reads a stream of text from a provided file path. 
        //If there are any errors, they are caught on the console level, until a valid path has been received 
        //</summary>
        //<params name="filePath">Direct file path to the input file</params>
        //<returns>Returns a list of item DTO's if successful, otherwise null</returns>
        public List<ItemDTO> ReadInput(string filePath)
        {
            string row;
            List<ItemDTO> inputs = new List<ItemDTO>();
            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    while ((row = file.ReadLine()) != null)
                    {
                        List<string> column = row.Split(' ').ToList();
                        inputs.Add(new ItemDTO()
                        {
                            Quality = ExtractLast(column),
                            SellIn = ExtractLast(column),
                            Name =  string.Join(" ", column)
                        });
                    }
                }
                return inputs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //<summary>
        //Takes the last index in a list of strings, removes it, and then returns the removed index
        //</summary>
        //<params name="list">List containing any amount of strings</params>
        //<returns>Returns a string if the list contains data, otherwise null</returns>
        public string ExtractLast(List<string> list)
        {
            if (list.Count > 0) //No need to return a result if there is nothing in the list
            {
                string result = list[list.Count - 1]; //Can also be done as list.Last()
                list.RemoveAt(list.Count - 1);
                return result;
            }
            return null;
        }

        //<summary>
        //Takes a list of objects, Item, and outputs it to a direct file path specified by the user
        //As with the input method, this method will error out until a valid path is received
        //</summary>
        //<params name="filePath">Direct file path for the output file</params>
        //<params name="items">List containing all transformed items that have been updated</params>
        //<returns>Returns a boolean depending on the success of the file stream</returns>
        public bool WriteOutput(string filePath, List<Item> items)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(filePath, false))
                {
                    foreach (var item in items)
                    {
                        if (item.Name == "NO SUCH ITEM" || item.Name == "ITEM ERROR")
                        {
                            file.WriteLine(item.Name);
                        }
                        else
                        {
                            file.WriteLine("{0} {1} {2}", item.Name, item.SellIn, item.Quality);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
