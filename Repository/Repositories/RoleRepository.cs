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
    public interface IRoleRepository : IRepository<RoleDTO>
    {
    }
    public class RoleRepository : BaseRepository<RoleDTO>, IRoleRepository
    {
        public RoleRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
       
    }
}
