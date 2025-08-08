using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("getproducts")]    // Get /api/productcontroller/getproducts
        public object GetProducts()
        {
            //Person person = new Person();

            //person.Name = "Test";
            //person.Age = 18;
            //person.Location = "United States";

            //return person;

            SingleProduct product = new SingleProduct();
            product.Id = 1;
            product.Title = "Test100";
            product.Price = 10;

            ProductResponse response = new ProductResponse();
            response.products = [product];

            return Ok(response);
        }
    }
}
