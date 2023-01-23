namespace ShoppingCart
{
    public class Article
    {
        public Article(long code, double price, string name)
        {
            Code = code;
            Price = price;
            Name = name;
        }

        public long Code { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }
    }

    public class Food : Article
    {
        public Food(long code, double price, string name) : base(code, price, name) { }

        public bool ContainsAlergenes { get; set; }

        public DateTime ExpirationDate { get; set; }
    }

    public class Cosmetics : Article
    {
        public Cosmetics(long code, double price, string name) : base(code, price, name) { }
        public bool IsNatural { get; set; }

        public bool TestedOnAnimals { get; set; }
    }

    public class Publications : Article
    {
        public Publications(long code, double price, string name) : base(code, price, name) { }
        public DateTime PublishedDate { get; set; }
    }
}