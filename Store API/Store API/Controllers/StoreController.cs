using Microsoft.AspNetCore.Mvc;
using Store_API.Models;

namespace Store_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        List<Item> StoreItems;
        List<CartItem> CartItems;

        public StoreController()
        {
            StoreItems = new List<Item>()
            {
                new Item(1, "Teddy Bear Keychain", 9.99m),
                new Item(2, "Teddy Bear Plushy", 19.99m),
                new Item(3, "Black Bear", 29.99m),
                new Item(4, "Brown Bear", 39.99m),
                new Item(5, "Runebear", 49.99m),
            };

            CartItems = new List<CartItem>();
        }

        [HttpGet("GetById")]
        public Item Get(int Id)
        {
            return StoreItems.FirstOrDefault(x => x.Id == Id);
        }

        [HttpGet("Get")]
        public List<Item> Get()
        {
            return StoreItems;
        }

        [HttpGet("GetCart")]
        public List<CartItem> GetCart()
        {
            return CartItems;
        }

        [HttpPost("AddItem")]
        public void AddItem(int Id, int quantity = 1)
        {
            Item newItem = StoreItems.FirstOrDefault(x => x.Id == Id);
            
            if (newItem != null)
                CartItems.Add(new CartItem(newItem, quantity));
        }

        [HttpPost("DeleteItem")]
        public List<CartItem> DeleteItem(int Id)
        {
            CartItems.RemoveAll(x => x.Item.Id == Id);

            return CartItems;
        }

        [HttpPost("UpdateQuantity")]
        public List<CartItem> UpdateQuantity(int Id, int newQuantity)
        {
            CartItem item = CartItems.FirstOrDefault(x => x.Item.Id == Id);
            if (item != null)
                item.Quantity = newQuantity;

            return CartItems;
        }

    }
}
