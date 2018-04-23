using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    //<summary>
    //Class object that holds data retrieved from the input file before parsing
    //</summary>
    public class ItemDTO
    {
        public string Name { get; set; }
        public string SellIn { get; set; }
        public string Quality { get; set; }
    }
}
