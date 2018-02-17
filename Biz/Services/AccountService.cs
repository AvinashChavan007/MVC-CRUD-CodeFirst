using System.Linq;
using Biz.Interfaces;
using Core.Domains;
using Data;

namespace Biz.Services
{
    public class AccountService : IAccountService
    {
        #region Properties

        private readonly IRepository<Account> _accountRepo;

        #endregion

        #region Constructor
        public AccountService()
        {
            _accountRepo = new Repository<Account>();
        }

        public AccountService(IRepository<Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }
        #endregion

        #region Methods
        public IQueryable<Account> GetAll()
        {
            return _accountRepo.Table;
        }

        public Account GetById(int id)
        {
            return _accountRepo.GetById(id);
        }

        public void InsertOrUpdate(Account account)
        {
            if (account.Id == 0)
            {
                _accountRepo.Insert(account);
            }
            else
            {
                _accountRepo.Update(account);
            }
        }
        #endregion
    }
}
