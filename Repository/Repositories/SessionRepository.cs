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
    public interface ISessionRepository : IRepository<SessionDTO>
    {
        List<SessionDTO> FindByConcertId(int ConcertId);
        List<SessionDTO> FindByUserId(int UserId);
    }
    public class SessionRepository : BaseRepository<SessionDTO>, ISessionRepository
    {
        public SessionRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public List<SessionDTO> FindByConcertId(int ConcertId)
        { 
            return Context.sessionDTOs
                .Where(x => x.ConcertId == ConcertId
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }

        public List<SessionDTO> FindByUserId(int UserId)
        {
            return Context.sessionDTOs
                .Where(x => x.UserId == UserId
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }
    }
}
