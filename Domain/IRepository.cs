using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain
{
    public partial interface IRepository<TEntidad> where TEntidad : class
    {
        void Insert(TEntidad entity);

        void Update(TEntidad entity);

        void Delete(TEntidad entity);

        void Delete<T>(T id);

        TEntidad GetByID<T>(T id);

        List<TEntidad> GetAll();

        void SaveChanges();
    }
}
