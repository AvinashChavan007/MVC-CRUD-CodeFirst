using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using Core;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region Properties
        private IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());
        private readonly AppContext _context;
        private IDbSet<T> _entities;
        #endregion

        #region constructors
        public Repository()
        {
            _context = new AppContext();
        }
        #endregion

        #region Methods
        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                    current + (Environment.NewLine + $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public IDictionary<string, object> GetModifiedProperties(T entity)
        {
            return _context.GetModifiedProperties(entity);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                     validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                     current + (Environment.NewLine + $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public IQueryable<T> Table => Entities;

        public IQueryable<T> TableUntracked => Entities.AsNoTracking();

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    var alreadyAttached = Entities.Local.FirstOrDefault(x => x.Id == entity.Id);
                    if (alreadyAttached != null)
                    {
                        _context.Entry(alreadyAttached).CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        _context.Entry(entity).State = EntityState.Modified;
                    }
                }

                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) =>
                    validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) =>
                    current + (Environment.NewLine + $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}")));

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        #endregion


    }
}
