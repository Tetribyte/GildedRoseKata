using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseKata
{
    //<summary>
    //Class object that contains the basic stucture of all objects that will inherit from it
    //Contains an update method that can be used to call an invidual item update without constructing additonal methods
    //This method can also be overrided depending of the item's update conditions
    //</summary>
    //<value> 
    public class Item
    {
        //<value>Name of the item</value>
        public string Name { get; set; }
        //<value>Days until the item should be sold</value>
        public int SellIn { get; set; }
        //<value>Rate at which the item quality changes</value>
        public int QualityRate { get; set; }
        //<value>Quality the item starts at</value>
        public int Quality { get; set; }
        //<remarks>Base update method with normal item conditions</remarks>
        public virtual void Update()
        {
            Quality += SellIn > 0 ? QualityRate : 2 * QualityRate;
            Quality = Quality < 50 && Quality > 0 ? Quality : Quality > 0 ? 50 : 0;
            SellIn--;
        }

        public Item()
        {
            QualityRate = -1;
        }
    }

    public class Conjured : Item
    {
        public Conjured()
        {
            QualityRate = new Item().QualityRate * 2;
        }
        public Conjured(Item item)
        {
            Name = item.Name;
            SellIn = item.SellIn;
            Quality = item.Quality;
            QualityRate = new Item().QualityRate * 2;
        }
    }

    public class Aged_Brie : Item
    {
        public Aged_Brie()
        {
            QualityRate = 1;
        }
        public Aged_Brie(Item item)
        {
            Name = item.Name;
            SellIn = item.SellIn;
            Quality = item.Quality;
            QualityRate = 1;
        }
    }

    public class Sulfuras : Item
    {
        public Sulfuras()
        {
            QualityRate = 0;
        }
        public Sulfuras(Item item)
        {
            Name = item.Name;
            SellIn = item.SellIn;
            Quality = item.Quality;
            QualityRate = 0;
        }

        public override void Update()
        {
            Quality = Quality < 50 && Quality > 0 ? Quality : Quality > 0 ? 50 : 0;
        }
    }

    public class Backstage_Pass : Item
    {
        public override void Update()
        {
            if (SellIn <= 10 && SellIn > 5)
            {
                QualityRate = 2;
            }
            else if (SellIn <= 5 && SellIn > 0)
            {
                QualityRate = 3;
            }
            Quality += SellIn > 0 ? QualityRate : -Quality;
            Quality = Quality < 50 && Quality > 0 ? Quality : Quality > 0 ? 50 : 0;
            SellIn--;
        }
        public Backstage_Pass(){
            QualityRate = 1;
        }
        public Backstage_Pass(Item item)
        {
            Name = item.Name;
            SellIn = item.SellIn;
            Quality = item.Quality;
            QualityRate = 1;
        }
    }

    public class Invalid : Item
    {
        public Invalid()
        {
            Name = "NO SUCH ITEM";
            SellIn = 0;
            Quality = 0;
            SellIn = 0;
        }
        public override void Update() {}
    }
}
