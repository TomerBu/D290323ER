using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lec1Apis.Models
{
    public class Product
    {

        public static int _id = 0;
        public  int Id { get; set; }
         public string Name { get; set; } = "";
        public  double Price { get; set; }

        public Product()
        {
            Id = ++_id;
        }

        public Product(string name, double price):this()
        {
            Name = name;
            Price = price;
        }
    }
}