using GildedRoseKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GildedRoseKata.Test
{
    [TestClass]
    public class GildedRoseKataTests
    {
        private Operations _ops = new Operations();
        private Data _data = new Data();

        #region Update Method Tests
        [TestCategory("Update"), TestMethod]
        public void Normal_Item_Update()
        {
            Item item = new Item()
            {
                Name = "Normal Item",
                Quality = 20,
                SellIn = 2
            };
            item.Update();
            Assert.AreEqual(19, item.Quality);
            Assert.AreEqual(1, item.SellIn);
            item.Update();
            Assert.AreEqual(18, item.Quality);
            Assert.AreEqual(0, item.SellIn);
            item.Update();
            Assert.AreEqual(16, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }
        [TestCategory("Update"), TestMethod]
        public void Conjured_Item_Update()
        {
            Conjured item = new Conjured()
            {
                Name = "Conjured",
                Quality = 10,
                SellIn = 2
            };
            item.Update();
            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(1, item.SellIn);
            item.Update();
            Assert.AreEqual(6, item.Quality);
            Assert.AreEqual(0, item.SellIn);
            item.Update();
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }
        [TestCategory("Update"), TestMethod]
        public void Aged_Brie_Update()
        {
            Aged_Brie item = new Aged_Brie()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 1
            };
            item.Update();
            Assert.AreEqual(1, item.Quality);
            Assert.AreEqual(0, item.SellIn);
            item.Update();
            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
            item.Update();
            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }
        [TestCategory("Update"), TestMethod]
        public void Sulfuras_Item_Update()
        {
            Sulfuras item = new Sulfuras()
            {
                Name = "Sulfuras",
                Quality = 8,
                SellIn = 8
            };
            item.Update();
            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(8, item.SellIn);
        }
        [TestCategory("Update"), TestMethod]
        public void Backstage_Pass_Item_Update()
        {
            Backstage_Pass item = new Backstage_Pass()
            {
                Name = "Backstage passes",
                Quality = 4,
                SellIn = 6
            };
            item.Update();
            Assert.AreEqual(6, item.Quality);
            Assert.AreEqual(5, item.SellIn);
            item.Update();
            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(4, item.SellIn);
            item.Update();
            Assert.AreEqual(12, item.Quality);
            Assert.AreEqual(3, item.SellIn);
            item.Update(); item.Update(); item.Update(); item.Update();
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }
        #endregion
        #region Parse Method Tests
        [TestCategory("Parse"), TestMethod]
        public void Normal_Item_Parse()
        {
            var item = _ops.ParseToType(new ItemDTO()
            {
                Name = "Normal Item",
                Quality = "2",
                SellIn = "2"
            });

            Assert.AreEqual("Normal Item", item.Name);
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(-1, item.QualityRate);
            Assert.AreEqual(2, item.SellIn);
        }
        [TestCategory("Parse"), TestMethod]
        public void Conjured_Item_Parse()
        {
            var item = _ops.ParseToType(new ItemDTO()
            {
                Name = "Conjured",
                Quality = "2",
                SellIn = "2"
            });

            Assert.AreEqual("Conjured", item.Name);
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(new Item().QualityRate * 2, item.QualityRate);
            Assert.AreEqual(2, item.SellIn);
        }
        [TestCategory("Parse"), TestMethod]
        public void Aged_Brie_Parse()
        {
            var item = _ops.ParseToType(new ItemDTO()
            {
                Name = "Aged Brie",
                Quality = "2",
                SellIn = "2"
            });

            Assert.AreEqual("Aged Brie", item.Name);
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(1, item.QualityRate);
            Assert.AreEqual(2, item.SellIn);
        }
        [TestCategory("Parse"), TestMethod]
        public void Sulfuras_Parse()
        {
            var item = _ops.ParseToType(new ItemDTO()
            {
                Name = "Sulfuras",
                Quality = "2",
                SellIn = "2"
            });

            Assert.AreEqual("Sulfuras", item.Name);
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(0, item.QualityRate);
            Assert.AreEqual(2, item.SellIn);
        }
        [TestCategory("Parse"), TestMethod]
        public void Backstage_Pass_Parse()
        {
            var item = _ops.ParseToType(new ItemDTO()
            {
                Name = "Backstage passes",
                Quality = "2",
                SellIn = "2"
            });

            Assert.AreEqual("Backstage passes", item.Name);
            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(1, item.QualityRate);
            Assert.AreEqual(2, item.SellIn);
        }
        #endregion
        #region Extract Method
        [TestCategory("Extract"), TestMethod]
        public void List_Extract()
        {
            List<string> list = new List<string>()
            {
                "first", "second", "third", "fourth"
            };
            Assert.AreEqual("fourth", _data.ExtractLast(list));
            Assert.AreEqual("third", _data.ExtractLast(list));
            Assert.AreEqual("second", _data.ExtractLast(list));
            Assert.AreEqual("first", _data.ExtractLast(list));
            Assert.AreEqual(null, _data.ExtractLast(list));
        }
        #endregion
        #region Test Input
        [TestCategory("DTO Input"), TestMethod]
        public void DTO_Input()
        {
            List<string> expectedName = new List<string>() {"Aged Brie", "Backstage passes", "Backstage passes", "Sulfuras", "Normal Item", "Normal Item", "NO SUCH ITEM", "Conjured", "Conjured"};
            List<int?> expectedSellIn = new List<int?>() { 0, -2, 8, 2, -2, 1, 0, 1, -2};
            List<int?> expectedQuality = new List<int?>() { 2, 0, 4, 2, 50, 1, 0, 0, 1};
            List<ItemDTO> inputList = new List<ItemDTO>()
            {
                new ItemDTO(){Name = "Aged Brie", SellIn = "1", Quality = "1"},
                new ItemDTO(){Name = "Backstage passes", SellIn = "-1", Quality = "2"},
                new ItemDTO(){Name = "Backstage passes", SellIn = "9", Quality = "2"},
                new ItemDTO(){Name = "Sulfuras", SellIn = "2", Quality = "2"},
                new ItemDTO(){Name = "Normal Item", SellIn = "-1", Quality = "55"},
                new ItemDTO(){Name = "Normal Item", SellIn = "2", Quality = "2"},
                new ItemDTO(){Name = "INVALID ITEM", SellIn = "2", Quality = "2"},
                new ItemDTO(){Name = "Conjured", SellIn = "2", Quality = "2"},
                new ItemDTO(){Name = "Conjured", SellIn = "-1", Quality = "5"},
            };

            List<Item> inventory = _ops.SortInput(inputList);

            for (int i = 0; i < inventory.Count; i++)
            {
                inventory[i].Update();
                Assert.AreEqual(expectedName[i], inventory[i].Name);
                Assert.AreEqual(expectedSellIn[i], inventory[i].SellIn);
                Assert.AreEqual(expectedQuality[i], inventory[i].Quality);
            }
        }
        #endregion
    }
}
