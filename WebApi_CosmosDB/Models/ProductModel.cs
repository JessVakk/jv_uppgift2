
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace WebApi_CosmosDB.Models
{
    public class ProductModel
    {
        [Key]
        [JsonProperty("id")]
        public Guid Id { get; set; }
        public int Articlenumber { get; set; } 

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Description { get; set; } = null!;

        public string PartitionKey { get; set; } = null!;

        public CategoryModel Category { get; set; }
    }
}
