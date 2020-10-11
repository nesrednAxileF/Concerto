using Model.DBConstraint;
using Model.DTO;
using Repository.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public interface IUserRepository : IRepository<UserDTO>
    {
        UserDTO FindByEmail(string Email);
    }
    public class UserRepository : BaseRepository<UserDTO>, IUserRepository
    {
        public UserRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public UserDTO FindByEmail(string Email)
        {
            return Context.userDTOs
                .Where(x => x.Email.ToLower().Trim().Equals(Email.ToLower()
                .Trim())&&
                x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .FirstOrDefault();
        }
       
    }
}
