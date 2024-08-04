using Lec7Practice.DTOs;
using Lec7Practice.Mappings;
using Lec7Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lec7Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //AddProductDto => Product
        //Product => ProductResponseDto
        //prop
        static List<Product> Products = [];

        //methods:

        [HttpGet]
        public IActionResult Get()
        {
            //var res = new List<ProductResponseDto>();
            //foreach (var product in Products)
            //{
            //    res.Add(product.ToDto());
            //}


            return Ok(Products.Select(p => p.ToDto()));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddProductDto dto)
        {
            var p = dto.ToProduct();
            p.Id = Guid.NewGuid().ToString();//the id will be given by the database

            //add to list
            Products.Add(p);
            return Ok("Product added!");
        }

        //  /api/products/123
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            Product? product = Products.Find(x => x.Id == id);

            if (product is null)
            {
                return NotFound($"No product with id={id}");
            }

            Products.Remove(product);

            return Ok("Product deleted succesfully");
        }

        //  /api/products/123
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] AddProductDto dto)
        {
            var index = Products.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return NotFound($"No product with id={id}");
            }

            //dto stuff: (1) from dto to model
            var updated = dto.ToProduct();
            //demo project, we need to set the id (no database yet)
            updated.Id = id;

            //perform the replacement:
            Products[index] = updated;

            return Ok("Product updated succesfully");
        }
    }
}


//    /api/products