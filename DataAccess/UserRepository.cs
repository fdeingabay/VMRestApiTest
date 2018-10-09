using Domain;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IUserContext userContext) : base(userContext)
        {

        }
    }
}
