using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lec5.Data;
using Lec5.Models;

namespace Lec5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GAPIController(Lec5Context context) : ControllerBase
{

    // GET: api/GAPI
    [HttpGet]
    public async Task<ActionResult> GetGenres()
    {
        var genres =  await context.Genres.ToListAsync();

        return Ok(genres);
    }
  
}
