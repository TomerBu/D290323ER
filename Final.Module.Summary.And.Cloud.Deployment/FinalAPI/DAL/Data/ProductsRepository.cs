using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data;

public sealed class ProductsRepository(ContextDAL context) : Repository<Product>(context)
{
    public override IEnumerable<Product> GetAll()
    {
        return context.Products.Include(p => p.Category);
    }

    public override Product? GetById(int id)
    {
        return context.Products.Include(p => p.Category).SingleOrDefault(p => p.Id == id);
    }
}


//Product
//CategoryDtoWOProducts