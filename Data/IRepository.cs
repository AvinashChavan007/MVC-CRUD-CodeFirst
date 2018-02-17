using System.Collections.Generic;
using System.Linq;
using Core;

namespace Data
{
    public interface IRepository<T> where T : BaseEntity
    {

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        ///  Gets the modified properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        IDictionary<string, object> GetModifiedProperties(T entity);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>
        ///  Gets the table.
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets the table untracked.
        /// </summary>
        IQueryable<T> TableUntracked { get; }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);
    }
}