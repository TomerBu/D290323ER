using DAL.Models;

namespace DAL.Data
{
    public sealed class CategoryRepository(ContextDAL context) : Repository<Category>(context)
    {
        
    }
}
