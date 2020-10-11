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
    public interface IAdminRepository : IRepository<AdminDTO>
    {
        AdminDTO FindByEmail(string Email);
    }
    public class AdminRepository : BaseRepository<AdminDTO>, IAdminRepository
    {
        public AdminRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public AdminDTO FindByEmail(string Email)
        {
            return Context.adminDTOs
                .Where(x => x.Email.ToLower().Trim().Equals(Email.ToLower()
                .Trim())&&
                x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .FirstOrDefault();
        }
       
    }
}
