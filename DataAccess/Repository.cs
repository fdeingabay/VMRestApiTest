using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class Repository<TEntidad> : IRepository<TEntidad> where TEntidad : class
    {
        private readonly IUserContext dbContext;

        public Repository(IUserContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Insert(TEntidad entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entidad", "La entidad no puede ser null.");

            this.dbContext.SetEntity<TEntidad>().Add(entity);
        }

        public void Update(TEntidad entity)
        {
            this.dbContext.RegisterChanges(entity);
        }

        public void Delete(TEntidad entity)
        {
            this.dbContext.SetEntity<TEntidad>().Remove(entity);
        }

        public void Delete<T>(T id)
        {
            this.dbContext.SetEntity<TEntidad>().Remove(this.GetByID(id));
        }

        public TEntidad GetByID<T>(T id)
        {
            return this.dbContext.SetEntity<TEntidad>().Find(id);
        }

        public List<TEntidad> GetAll()
        {
            return this.dbContext.SetEntity<TEntidad>().ToList();
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
