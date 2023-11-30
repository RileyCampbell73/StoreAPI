using Store_API.Controllers;
using Store_API.Models;

namespace UnitTests
{
    [TestClass]
    public class StoreTests
    {
        StoreController controller;
        public StoreTests () 
        {
            controller = new StoreController();
        }
        [TestMethod]
        public void TestGet()
        {
            var item = controller.Get(1);

            Assert.AreEqual(1, item.Id);
        }
        
        [TestMethod]
        public void TestGetAll()
        {
            var items = controller.Get();

            Assert.IsTrue(items.GetType() == typeof(List<Item>));//Not sure what to assert here
        }
    }
}