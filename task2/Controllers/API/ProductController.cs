using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2.Models;
using task2.Models.data;

namespace task2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ApplicationDbContext _db) : ControllerBase
    {

        [HttpGet]
        public List<Product> getProduct()
        {
            var products = _db.Products.Include(m => m.company).ToList();
            return products;

        }

        [HttpGet("{id}")]

        public ActionResult<Product> getProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var products = _db.Products.Include(m => m.company).FirstOrDefault(m => m.Id == id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        
        [HttpPost]
        public IActionResult AddProduct( Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok();

        }
        [Route("del")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id<= 0)
            {
                return BadRequest();
            }
            var product = _db.Products.Include(x => x.company).FirstOrDefault(m => m.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            if(product.Id<=0 || !ModelState.IsValid)
            {  return BadRequest(); }

            var product2 = _db.Products.Include(_ => _.company).FirstOrDefault(m => m.Id == product.Id);
            if (product2 == null) {return NotFound(); }
            product2.Name= product.Name;
            product2.Description= product.Description;
            product2.price = product.price;
            product2.CompanyId = product.CompanyId;
            product2.EnablSize= product.EnablSize;
            _db.SaveChanges();
            return Ok();
        }
    }
}
