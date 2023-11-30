namespace Store_API.Models
{
    public class Item
    {
        public Item(int id, string title, decimal price) 
        { 
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

    }
}