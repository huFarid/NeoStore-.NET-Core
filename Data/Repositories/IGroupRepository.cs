using NeoStore.Models;

namespace NeoStore.Data.Repositories
{
    public interface IGroupRepository
    {
        public IEnumerable<Category> GetCategories();
        public IEnumerable<ShowGroupViewModel> GetGroupForShow();
    }

    public class GroupRepository : IGroupRepository
    {

        private EshopContext _context;

        public GroupRepository(EshopContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }


        public IEnumerable<ShowGroupViewModel> GetGroupForShow()
        {
            return _context.Categories.Select(c => 
            new ShowGroupViewModel() 
            { GroupId = c.Id,
                Name = c.Name ,
                ProductQuantity =_context.CategoryToProducts.Count(C2P=> C2P.CategoryID == c.Id) }).ToList();


        }
    }




}
