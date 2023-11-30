namespace Store_API.Models
{
    public class CartItem
    {
        public CartItem(Item item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }
        public Item Item { get; set; }

        public int Quantity { get; set; }

        public decimal Subtotal => Item.Price * Quantity;
    }
}
