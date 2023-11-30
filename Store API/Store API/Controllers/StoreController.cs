using Microsoft.AspNetCore.Mvc;
using Store_API.Models;

namespace Store_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        List<Item> StoreItems;

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
    }
}
