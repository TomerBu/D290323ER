using Lec1Apis.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lec1Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        static List<Product> Products = new List<Product>();
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product? p = Products.Find(p => p.Id == id);
            if (p is null)
            {
                return NotFound();
            }

            else return Ok(p);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product p)
        {
            p.Id = ++Product._id;
            Products.Add(p);

            return Created();//201;
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}




//create a Model class Product:
//each product has: id int, name string, price double
//scaffold a controller with actions
//in the controller - var myList = new List<Product>()
//CRUD operations