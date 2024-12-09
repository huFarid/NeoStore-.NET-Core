using Microsoft.Identity.Client;
using NeoStore.Models;

namespace NeoStore.Data.Repositories
{
    
    public interface IUserRepository
    {
        bool HasUserByEmail(string email);
        void AddUser(User user);
        User GetUserForLogin(string email, string password);
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

        public User GetUserForLogin(string email, string password)
        {  
            return _context.Users.SingleOrDefault(u=> u.Email == email && u.Password == password);
            
        }

        public bool HasUserByEmail(string email)
        {
            if( _context.Users.Any(u => u.Email == email.ToLower()))
            { return true; }
            return false;
        }



    }
}
