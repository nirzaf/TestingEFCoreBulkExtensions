using Bogus;

using EFCore.BulkExtensions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TestingEFCoreBulkExtensions.Model;

namespace TestingEFCoreBulkExtensions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductsController(ProductDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public string Post()
        {
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            var products = new Faker<Product>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .Generate(100000);

            timer.Stop();

            _context.BulkInsert(products);

            //return the elapsed time

            return timer.Elapsed.Milliseconds.ToString();
        }

        //Post using EF Core 
        [HttpPost("EFCore")]
        public string PostEFCore()
        {
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            var products = new Faker<Product>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .Generate(100000);

            _context.Products.AddRange(products);
            _context.SaveChanges();
            
            timer.Stop();

            //return the elapsed time

            return timer.Elapsed.Milliseconds.ToString();
        }

    }
}
