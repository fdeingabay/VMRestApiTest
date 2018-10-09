using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public partial interface IUserContext : IDisposable
    {
        void SaveChanges(int? userid = null);

        void RegisterChanges<TEntidad>(TEntidad entidad) where TEntidad : class;

        DbSet<TEntidad> GetEntitySet<TEntidad>() where TEntidad : class;

        void RemoveEntities<TEntidad>(ICollection<TEntidad> entities) where TEntidad : class;

        void Remove<TEntidad>(TEntidad entity) where TEntidad : class;

        DbSet<TEntidad> SetEntity<TEntidad>() where TEntidad : class;

        IQueryable<TEntidad> CreateSet<TEntidad>() where TEntidad : class;

        void Seed();
    }
}
