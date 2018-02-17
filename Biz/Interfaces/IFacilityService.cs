using System.Collections.Generic;
using System.Linq;
using Core.Domains;

namespace Biz.Interfaces
{
    public interface IFacilityService
    {

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<Facility> GetAll();
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Facility GetById(int id);

        /// <summary>
        /// Inserts or updates the model.
        /// </summary>
        /// <param name="facility">The Facility.</param>
        void InsertOrUpdate(Facility facility);

        /// <summary>
        /// Return Datatable for 
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="search"></param>
        /// <param name="activeFilter"></param>
        /// <returns></returns>
        IEnumerable<Facility> GetAllDataTable(string sortOrder, string search, bool? activeFilter = null);



    }
}