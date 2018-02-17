using System.Collections.Generic;
using System.Linq;
using Biz.Interfaces;
using Core.Domains;
using Data;

namespace Biz.Services
{
    public class FacilityService : IFacilityService
    {
        #region Properties
        private readonly IRepository<Facility> _facilityRepo;

        #endregion

        #region Constructor

        public FacilityService()
        {
            _facilityRepo = new Repository<Facility>();
        }

        public FacilityService(IRepository<Facility> facilityRepo)
        {
            _facilityRepo = facilityRepo;
        }
        #endregion

        #region Methods
        public IQueryable<Facility> GetAll()
        {
            return _facilityRepo.Table;
        }

        public Facility GetById(int id)
        {
            return _facilityRepo.GetById(id);
        }

        public IEnumerable<Facility> GetAllDataTable(string sortOrder, string search, bool? activeFilter = null)
        {
            var queryTable = _facilityRepo.Table;


            if (activeFilter != null)
            {
                queryTable = queryTable.Where(x => x.IsActive == activeFilter);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchValue = search.ToLower();

                queryTable = queryTable.Where(x => x.Name.ToLower().Contains(searchValue) || x.Landmark.ToLower().Contains(searchValue) || x.Address.ToLower().Contains(searchValue)
                                                   || x.Address2.ToLower().Contains(searchValue) || x.City.ToLower().Contains(searchValue) || x.State.ToLower().Contains(searchValue) ||
                                                   x.ZipCode.ToString().ToLower().Contains(searchValue));
            }
            return queryTable;


        }

        public void InsertOrUpdate(Facility facility)
        {
            if (facility.Id == 0)
            {
                _facilityRepo.Insert(facility);
            }
            else
            {
                _facilityRepo.Update(facility);
            }
        }
        #endregion
        
    }
}
