using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    public class Operations
    {
        //<summary>
        //Take an input of item data transfer objects and attempts to parse them to their respective type
        //If any of the inputs do not meet the set object format, they are returns as an 'ITEM ERROR' in the output
        //</summary>
        //<params name="inputList">List of item DTO's created by the Data.ReadInput() method</params>
        //<returns>Returns a list items</returns>
        public List<Item> SortInput(List<ItemDTO> inputList)
        {
            List<Item> inventory = new List<Item>(); //Construct the inventory that will be outputted

            foreach (var input in inputList)
            {
                try
                {
                    inventory.Add(ParseToType(input));
                }
                catch (Exception ex)
                {
                    inventory.Add(new Item() { Name = "ITEM ERROR" });
                }
            }
            return inventory;
        }

        //<summary>
        //Method containing all of the specified item types, that will be used to parse given the item name
        //</summary>
        //<params name="item">Single input that contains name, quality, and sellin values</params>
        //<returns>Returns an item type based upon the DTO name received</returns>
        public Item ParseToType(ItemDTO input)
        {
            Item item = new Item()
            {
                Name = input.Name,
                Quality = Int32.Parse(input.Quality),
                SellIn = Int32.Parse(input.SellIn)
            };

            switch (item.Name) //Switch statement of known item types
            {
                case "Normal Item":
                    return item;
                case "Conjured":
                    return new Conjured(item);
                case "Aged Brie":
                    return new Aged_Brie(item);
                case "Sulfuras":
                    return new Sulfuras(item);
                case "Backstage passes":
                    return new Backstage_Pass(item);
                default:
                    return new Invalid();
            }
        }
    }
}
