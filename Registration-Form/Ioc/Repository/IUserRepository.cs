using Registration_Form.Models;

namespace Registration_Form.Ioc.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        bool IsExistByEmail(string email);
        bool IsExistByUserName(string email);
        User GetUser(string email, string password);
    }
}
