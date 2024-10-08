﻿using Lec7Practice.Models;
using System.ComponentModel.DataAnnotations;

namespace Lec7Practice.DTOs
{
    public class AddProductDto
    {   //No id in the dto (id is generated by the database/controller) 
        //Name

        [Required, MinLength(5), MaxLength(255)]
        public required string Name { get; set; }

        [Required, Range(1, 9999)]
        public decimal Price { get; set; }
    }
}
