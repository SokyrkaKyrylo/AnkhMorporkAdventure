using AnkhMorporkAdventure.Domain.Concrete;
using AnkhMorporkAdventure.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnkhMorporkAdventure.Tests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        [DataRow(0, "Incorrect quanitty of items")]
        [DataRow(3, "Incorrect quanitty of items")]
        [DataRow(5, "Incorrect quanitty of items")]
        public void AddInventory_WhenQuantityIsntCorrect_ReturnMessage(int quanity, string resMes)
        {
            var item = new Item();

            var invertory = new Inventory();

            Assert.AreEqual(invertory.AddItem(item, quanity), resMes);
        }

        [TestMethod]
        public void AddItem_WhenItemIsAlreadyInIt2Times_ReturnErrorMessage()
        {
            var item1 = new Item();

            var inventory = new Inventory();
            inventory.AddItem(item1, 2);
            Assert.AreEqual(inventory.AddItem(item1, 1), "You backpack can only held 2 numbers of each item");
        }

        [TestMethod]
        public void AddItem_WhenAddingAnExistingItem_ReturnEmptyString()
        {
            var item = new Item();

            var invetory = new Inventory();

            invetory.AddItem(item, 1);

            Assert.AreEqual(invetory.AddItem(item, 1), "");
            Assert.AreEqual(invetory.Items[item], 2);
        }
    }
}
