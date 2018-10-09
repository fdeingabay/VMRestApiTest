using DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext() : base("UserContext")
        {
            Database.SetInitializer<UserContext>(new CreateDatabaseIfNotExists<UserContext>());

            Database.Initialize(force: false);
        }

        public IQueryable<TEntidad> CreateSet<TEntidad>() where TEntidad : class
        {
            IQueryable<TEntidad> query = base.Set<TEntidad>();

            return query;
        }

        public DbSet<TEntidad> GetEntitySet<TEntidad>() where TEntidad : class
        {
            return base.Set<TEntidad>();
        }

        public void RegisterChanges<TEntidad>(TEntidad entidad) where TEntidad : class
        {
            this.Entry(entidad).State = System.Data.Entity.EntityState.Modified;
        }

        public void Remove<TEntidad>(TEntidad entity) where TEntidad : class
        {
            this.GetEntitySet<TEntidad>().Remove(entity);
        }

        public void RemoveEntities<TEntidad>(ICollection<TEntidad> entities) where TEntidad : class
        {
            this.GetEntitySet<TEntidad>().RemoveRange(entities);
            entities.Clear();
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }

        public DbSet<TEntidad> SetEntity<TEntidad>() where TEntidad : class
        {
            return base.Set<TEntidad>() as DbSet<TEntidad>;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public new void SaveChanges(int? userid = null)
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation(
                              "Class: {0}, Property: {1}, Error: {2}",
                              validationErrors.Entry.Entity.GetType().FullName,
                              validationError.PropertyName,
                              validationError.ErrorMessage);
                    }
                }

                throw;
            }
        }
    }
}
