using Hasseeb.Application.Domain;
using Hasseeb.Application.Repository;
using Hasseeb.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hasseeb.Service
{
    public class AccountManager : BaseService<Account>, IAccountManager
    {
        public AccountManager(IRepository<Account> repository) : base(repository)
        {
        }
        public Account GetAccountNatureWithItems(int id)
        {
            return _repository.GetAll().Where(x => x.ID == id).ToList().First();
        }
    }
}
