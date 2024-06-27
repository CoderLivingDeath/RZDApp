using rzd;

namespace RZDModel.Interfaces.Services
{
    public interface IAuthorizationService
    {
        bool Authenticate(string login, string password, out int UserId);
        UserCredentials CreateCredentials(string login, string password, int userId);
        UserCredentials GetUserCredentials(string login);
        bool TryGetUserCredentials(string login, out UserCredentials? credentials);
    }
}