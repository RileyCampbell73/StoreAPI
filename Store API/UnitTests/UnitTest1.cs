using Store_API.Controllers;
using Store_API.Models;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGet()
        {
            var controller = new StoreController();

            var item = controller.Get(1);

            //Assert.IsTrue(response.TryGetContentValue<Product>(out product));
            Assert.AreEqual(1, item.Id);
        }
        
        [TestMethod]
        public void TestGetAll()
        {
            var controller = new StoreController();

            var items = controller.Get();

            Assert.IsTrue(items.GetType() == typeof(List<Item>));
            // Assert.AreEqual(1, item.Id);
        }

        [TestMethod]
        public void TestCart()
        {
            var controller = new StoreController();

            Item item = controller.Get(1);
            controller.AddItem(item.Id, 1);

            List<CartItem> cart = controller.GetCart();

            Assert.AreEqual(1, cart.Count);

            cart = controller.UpdateQuantity(cart.First().Item.Id, 10);

            Assert.AreEqual(cart.First().Quantity, 10);

            cart = controller.DeleteItem(cart.First().Item.Id); 

            Assert.AreEqual(0, cart.Count);
        }
    }
}