using System.Linq;
using Core.Domains;

namespace Biz.Interfaces
{
    public interface IAccountService
    {

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<Account> GetAll();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Account GetById(int id);

        /// <summary>
        /// Inserts or updates the model.
        /// </summary>
        /// <param name="account">The account.</param>
        void InsertOrUpdate(Account account);




    }
}