using Microsoft.EntityFrameworkCore;
using Model.DBConstraint;
using Model.DTO;
using Repository.Base;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public interface IUserRepository : IRepository<UserDTO>
    {
        UserDTO FindByEmail(string Email);
        Task<UserDTO> FindByEmailAndPassword(string Email, string Password);
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

        public async Task<UserDTO> FindByEmailAndPassword(string Email, string Password)
        {
            return await Context.userDTOs
                .Where(x => x.Email.Equals(Email)
                            && x.Password.Equals(Password)
                            && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .FirstOrDefaultAsync();
        }
    }
}
