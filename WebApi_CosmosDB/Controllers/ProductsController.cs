using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApi_CosmosDB.Context;
using WebApi_CosmosDB.Models;

namespace WebApi_CosmosDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var productModel = new ProductModel
            {
                Id = Guid.NewGuid(),
                PartitionKey = "Products",
                Articlenumber = product.Articlenumber,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description

            };
         
            _context.Add(productModel);
            await _context.SaveChangesAsync();

            return new OkObjectResult(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _context.ProductCatalog.Include(x => x.Category).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModel(Guid id)
        {
            var productModel = await _context.ProductCatalog.FindAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return productModel;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModel(Guid id, ProductUpdate productModel)
        {
            try
            {
                var product = await _context.ProductCatalog.FindAsync(id);
                product.Name = productModel.Name;
                product.Articlenumber = productModel.Articlenumber;
                product.Price = productModel.Price;
                product.Description = productModel.Description;

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }

        private bool ProductModelExists(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(Guid id)
        {
            var productModel = await _context.ProductCatalog.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            _context.ProductCatalog.Remove(productModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
