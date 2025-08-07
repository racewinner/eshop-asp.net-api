using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.Sales
{
    //[Area("Sales")]
    public class Product : Controller
    {
        public string Index()
        {
            return "Hello World!";
        }
    }
}
