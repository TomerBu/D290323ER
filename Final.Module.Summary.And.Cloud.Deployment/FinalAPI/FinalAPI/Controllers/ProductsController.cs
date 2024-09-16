using DAL.Data;
using FinalAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductsController(ProductsRepository repository) : ControllerBase
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
}
