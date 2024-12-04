using Microsoft.Identity.Client;
using NeoStore.Models;

namespace NeoStore.Data.Repositories
{
    
    public interface IUserRepository
    {
        bool HasUser(string username);
        void AddUser(User user);
    }

    public class UserRepository : IUserRepository
    {
        private EshopContext _context;
        public UserRepository(EshopContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool HasUser(string email)
        {
            if( _context.Users.Any(u => u.Email == email))
            { return true; }
            return false;
        }
    }
}
