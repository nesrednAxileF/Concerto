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
    public interface ITicketRepository : IRepository<TicketDTO>
    {
        List<TicketDTO> FindByConcertId(int ConcertId);
        List<TicketDTO> FindByUserId(int UserId);
    }
    public class TicketRepository : BaseRepository<TicketDTO>, ITicketRepository
    {
        public TicketRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public List<TicketDTO> FindByConcertId(int ConcertId)
        { 
            return Context.ticketDTOs
                .Where(x => x.ConcertId == ConcertId
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }

        public List<TicketDTO> FindByUserId(int UserId)
        {
            return Context.ticketDTOs
                .Where(x => x.UserId == UserId
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }
    }
}
