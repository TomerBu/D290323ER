using DAL.Data;
using FinalAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinalAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

//TODO: USE Repo instead of DB CONTEXT
public class ProductsController(ProductsRepository repository) : ControllerBase
{
    [HttpGet]
    public ActionResult GetProducts()
    {
        return Ok(repository.GetAll().Select(p => p.ToDto()));
    }

    [HttpGet("{id}")]
    public ActionResult GetProductById(int id)
    {

        var product = repository.GetById(id);

        if(product is null)
        {
            return NotFound();
        }
        return Ok(product.ToDto());
    }
}
