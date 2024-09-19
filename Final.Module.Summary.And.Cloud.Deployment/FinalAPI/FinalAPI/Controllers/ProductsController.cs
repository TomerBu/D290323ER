using DAL.Data;
using FinalAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductsController(
    ProductsRepository repository,
    CategoryRepository categoryRepository
    ) : ControllerBase
{
    [HttpGet]
    public ActionResult GetProducts()
    {
        var allProducts = repository.GetAll();

        //Product->category
        return Ok(allProducts.Select(p => p.ToDto()));
    }

    [HttpGet("{id}")]
    public ActionResult GetProductById(int id)
    {

        var product = repository.GetById(id);

        if (product is null)
        {
            return NotFound();
        }
        return Ok(product.ToDto());
    }

    //CAN ADD PRODUCT ONLY WITH VALID JWT
    [HttpPost]
    [Authorize(Roles = "admin")]
    public ActionResult AddProduct(CreateProductDto dto)
    {
        if (User.Claims.Any(c => c.Type == "isHappy" && c.Value == "true")) {
            Console.WriteLine("Welcome Happy Person");
        }

        if (ModelState.IsValid)
        {
            var category = categoryRepository.GetById(dto.CategoryId);
            if (category is null)
            {
                return BadRequest(new { message = "Invalid Category" });
            }
            var product = dto.ToProduct();
            
            repository.Add(product);
            product.Category = category;
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product.ToDto());
        }
        return BadRequest(ModelState);
    }

}
