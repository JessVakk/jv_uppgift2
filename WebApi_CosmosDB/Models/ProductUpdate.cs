namespace WebApi_CosmosDB.Models
{
    public class ProductUpdate
    {
        public int Articlenumber { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;
    }
}
