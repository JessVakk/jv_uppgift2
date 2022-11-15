using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApi_CosmosDB.Models
{
    public class Product
    {

        public int Articlenumber { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public CategoryModel Category { get; set; }

    }
}
