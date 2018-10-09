using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.User
{
    public interface IUserService
    {
        void Insert(Entities.User newUser);

        void Update(Entities.User user);

        void Delete(int id);

        Entities.User GetByID(int id);

        IEnumerable<Entities.User> GetAll();
    }
}
