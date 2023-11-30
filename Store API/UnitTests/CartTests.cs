using Microsoft.AspNetCore.Mvc;
using Store_API.Controllers;
using Store_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class CartTests
    {

        [TestMethod]
        public void TestGetCart() 
        {
            //Creating new controller means we won't get old cart data in other tests because its kept in controller memory
            CartController controller = new CartController();

            List<CartItem> cart = controller.GetCart();
            Assert.AreEqual(0, cart.Count);

            Item item = new StoreController().Get(1);
            controller.AddItem(item.Id, 1);

            cart = controller.GetCart();

            Assert.AreEqual(1, cart.Count);
            Assert.AreEqual(1, cart.First().Quantity);

        }

        [TestMethod]
        public void TestAdd() 
        {
            CartController controller = new CartController();

            Item item = new StoreController().Get(1);
            controller.AddItem(item.Id, 1);

            List<CartItem> cart = controller.GetCart();

            Assert.AreEqual(item.Id, cart.First().Item.Id);
            Assert.AreEqual(item.Title, cart.First().Item.Title);
            Assert.AreEqual(item.Price, cart.First().Item.Price);
            Assert.AreEqual(1, cart.First().Quantity);
        }

        [TestMethod]
        public void TestDelete()
        {
            CartController controller = new CartController();

            Item item = new StoreController().Get(1);
            controller.AddItem(item.Id, 1);

            List<CartItem> cart = controller.GetCart();
            Assert.AreEqual(1, cart.Count);

            cart = controller.DeleteItem(1);
            Assert.AreEqual(0, cart.Count);
        }

        [TestMethod]
        public void TestUpdate()
        {
            CartController controller = new CartController();

            Item item = new StoreController().Get(1);
            controller.AddItem(item.Id, 1);

            List<CartItem> cart = controller.GetCart();
            Assert.AreEqual(1, cart.First().Quantity);

            cart = controller.UpdateQuantity(cart.First().Item.Id, 10);
            Assert.AreEqual(cart.First().Quantity, 10);
        }
    }
}
