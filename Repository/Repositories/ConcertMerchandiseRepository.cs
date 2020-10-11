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
    public interface IConcertMerchandiseRepository : IRepository<ConcertMerchandiseDTO>
    {
        List<ConcertMerchandiseDTO> FindByConcertId(int ConcertId);
    }
    public class ConcertMerchandiseRepository : BaseRepository<ConcertMerchandiseDTO>, IConcertMerchandiseRepository
    {
        public ConcertMerchandiseRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public List<ConcertMerchandiseDTO> FindByConcertId(int ConcertId)
        {
            return Context.concertMerchandiseDTOs
                .Where(x => x.ConcertId==ConcertId
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }
       
    }
}
