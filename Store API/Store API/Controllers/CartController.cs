using Microsoft.AspNetCore.Mvc;
using Store_API.Models;

namespace Store_API.Controllers
{
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        List<CartItem> CartItems;
        public CartController() 
        {
            CartItems = new List<CartItem>();
        }

        [HttpGet("GetCart")]
        public List<CartItem> GetCart()
        {
            return CartItems;
        }

        [HttpPost("AddItem")]
        public void AddItem(int Id, int quantity = 1)
        {
            Item newItem = new StoreController().Get().FirstOrDefault(x => x.Id == Id);

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
