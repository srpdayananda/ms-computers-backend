namespace backend.Model
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public ShoppingItem(int id, string name, string img, string description, int quantity, int price)
        {
            Id = id;
            Name = name;
            Img = img;
            Description = description;
            Quantity = quantity;
            Price = price;
        }
    }
}
