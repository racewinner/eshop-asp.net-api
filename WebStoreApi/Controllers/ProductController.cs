using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Xml;
using WebStoreApi.Models;

namespace WebStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("get_products")]
        public JsonResult get_tasks()
        {
            List<SingleProductDto> products = new List<SingleProductDto>();

            string query = "select * from product";
            DataTable table = new DataTable();
            string SqlDatasource = _configuration.GetConnectionString("mydb");
            //SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(SqlDatasource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            SingleProductDto singleProduct = new SingleProductDto()
                            {
                                Id = myReader.GetInt32(myReader.GetOrdinal("Id")),
                                Title = myReader.GetString(myReader.GetOrdinal("Title")),
                                Price = myReader.GetInt32(myReader.GetOrdinal("Price"))
                            };
                            products.Add(singleProduct);
                        }
                    }
                    //myReader = myCommand.ExecuteReader();
                    //table.Load(myReader);
                }
            }

            ProductListDto productList = new ProductListDto()
            {
                products = products
            };            

            return new JsonResult(productList);
        }

        //[HttpPost("add_singleproduct")]
        //public JsonResult add_task([FromForm] string task)
        //{
        //    string query = "insert into product values (@singleproduct)";
        //    DataTable table = new DataTable();
        //    string SqlDatasource = _configuration.GetConnectionString("mydb");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(SqlDatasource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@task", task);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //        }
        //    }

        //    return new JsonResult("Added Successfully");
        //}

        //[HttpPost("delete_task")]
        //public JsonResult delete_task([FromForm] string id)
        //{
        //    string query = "delete from todo where id=@id";
        //    DataTable table = new DataTable();
        //    string SqlDatasource = _configuration.GetConnectionString("mydb");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(SqlDatasource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myCommand.Parameters.AddWithValue("@id", id);
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);
        //        }
        //    }

        //    return new JsonResult("Deleted Successfully");
        //}
    }
}
