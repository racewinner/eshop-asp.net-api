using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class FirstController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }

        public object Info()
        {
            Person person = new Person();

            person.Name = "Jhon";
            person.Age = 18;
            person.Location = "United States";

            return person;
        }
    }
}
