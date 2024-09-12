using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }


    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    //Likes/Rating (when we add users/identity)


    //Navigation props:
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}
