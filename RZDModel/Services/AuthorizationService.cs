using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto.Generators;
using rzd;
using RZDModel.Interfaces.Repositories;
using RZDModel.Interfaces.Services;
using RZDModel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRepository<UserCredentials> _repository;
        private readonly IUserService _userService;
        private readonly PasswordHasher<string> passwordHasher;
        public AuthorizationService(IRepository<UserCredentials> userCredentials, IUserService userService)
        {
            _repository = userCredentials;
            _userService = userService;

            passwordHasher = new PasswordHasher<string>();
        }

        public bool Authenticate(string login, string password, out int UserId)
        {
            var userCredentials = _repository.ReadAll().FirstOrDefault(x => x.Login == login);
            UserId = -1;
            if (userCredentials == null)
            {
                return false;
            }

            if (!VerifyPasswordHash(login ,password, userCredentials.StoredPasswordHash))
            {
                return false;
            }

            UserId = userCredentials.User_id;
            return true;
        }

        public UserCredentials GetUserCredentials(string login)
        {
            var credentials = _repository.ReadAll().FirstOrDefault(x => x.Login == login);
            if (credentials != null)
            {
                return credentials;
            }
            throw new InvalidOperationException();
        }

        public bool TryGetUserCredentials(string login, out UserCredentials? credentials)
        {
            var FindedCredentials = _repository.ReadAll().FirstOrDefault(x => x.Login == login);
            credentials = FindedCredentials;
            if (FindedCredentials != null)
            {
                return true;
            }
            return false;
        }

        public UserCredentials CreateCredentials(string login, string password, int userId)
        {
            if (!TryGetUserCredentials(login,out _))
            {
                var newUserCredentials = new UserCredentials() { id = 0, User_id = userId, Login = login, Password = password, StoredPasswordHash = passwordHasher.HashPassword(login,password) };
                _repository.Create(newUserCredentials);
                return newUserCredentials;
            }
            throw new InvalidOperationException();
        }

        private bool VerifyPasswordHash(string login, string providedPassword, string storedPasswordHash)
        {
            var result = passwordHasher.VerifyHashedPassword(login,storedPasswordHash,providedPassword);
            return PasswordVerificationResult.Success == result;
        }
    }
}
