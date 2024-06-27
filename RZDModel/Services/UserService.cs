using rzd;
using RZDModel.Interfaces.Repositories;
using RZDModel.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<BankAccount> _bankAccountRepository;

        public UserService(IRepository<User> userRepositoru, IRepository<BankAccount> bankAccountRepository)
        {
            _userRepository = userRepositoru;
            _bankAccountRepository = bankAccountRepository;
        }

        public User GetById(int id)
        {
            var user = _userRepository.Read(id);
            if (user != null)
            {
                return user;
            }

            throw new InvalidOperationException();
        }

        public User CreateNewUser(string fullName, string role = "user")
        {
            var user = new User()
            {
                id = 0,
                FullName = fullName,
                BankAccount_id = null,
                Role = role
            };

            _userRepository.Create(user);

            return user;
        }

        public void AddCard(int userId, string CardNumber)
        {
            var user = _userRepository.Read(userId);

            if (user != null)
            {
                BankAccount bankAccount = new BankAccount()
                {
                    id = 0,
                    User_id = userId,
                    CardNumber = CardNumber
                };

                _bankAccountRepository.Create(bankAccount);
                user.BankAccount_id = bankAccount.id;
                _userRepository.Update(user);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.ReadAll();
        }
    }
}
