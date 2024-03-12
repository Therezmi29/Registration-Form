using Registration_Form.Data;
using Registration_Form.Ioc.Repository;
using Registration_Form.Models;

namespace Registration_Form.Ioc.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }


        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }

        public bool IsExistByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistByUserName(string username)
        {
            return _context.Users.Any(n => n.UserName == username);
        }
    }
}
