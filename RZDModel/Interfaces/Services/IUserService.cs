using rzd;

namespace RZDModel.Interfaces.Services
{
    public interface IUserService
    {
        void AddCard(int userId, string CardNumber);
        User CreateNewUser(string fullName, string role);
        User GetById(int id);
        IEnumerable<User> GetAll();
    }
}