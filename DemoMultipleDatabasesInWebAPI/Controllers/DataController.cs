using DemoMultipleDatabasesInWebAPI.Context;
using DemoMultipleDatabasesInWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DemoMultipleDatabasesInWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController(CompositeDbContext compositeDbContext) : ControllerBase
    {
        [HttpGet("product/get")]
        public async Task<IActionResult> GetProducts() =>
            Ok(await compositeDbContext.ProductDbContext!.Products.ToListAsync());

        [HttpGet("user/get")]
        public async Task<IActionResult> GetUsers() =>
            Ok(await compositeDbContext.UserDbContext!.Users.ToListAsync());

        [HttpPost("product/add")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            compositeDbContext.ProductDbContext!.Products.Add(product);
            await compositeDbContext.ProductDbContext.SaveChangesAsync();
            return Created();
        }

        [HttpPost("user/add")]
        public async Task<IActionResult> AddUser(User user)
        {
            compositeDbContext.UserDbContext!.Users.Add(user);
            await compositeDbContext.UserDbContext.SaveChangesAsync();
            return Created();
        }
    }
}
