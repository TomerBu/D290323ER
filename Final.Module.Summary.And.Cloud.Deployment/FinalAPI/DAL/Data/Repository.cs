using DataAccess.Models;

namespace DAL.Data;

public class Repository(ContextDAL context)
{
    public void AddProduct(Product product)
    {
        context.Products.Add(product);
        context.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
        context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = context.Products.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Item not found");
        context.Products.Remove(product);
        context.SaveChanges();
    }
}
