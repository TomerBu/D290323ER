using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;

namespace Lec7Practice.DTOs
{
	public class ProductResponseDto
	{
        public string Id { get; set; }
        public string ProdcutName { get; set; }
        public decimal Price { get; set; }

        public string Color => Price > 100 ? "Red" : "Green";
    }
}

//Dto=>Product=>ProductResponse