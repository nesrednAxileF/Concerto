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
    public interface IConcertStatisticRepository : IRepository<ConcertStatisticDTO>
    {
        List<ConcertStatisticDTO> FindByConcertId(int ConcertId);
        //Find where Max Viewer is Higher or equal than param
        List<ConcertStatisticDTO> FindByMaxViewer(int MaxViewer);
        //Find where DATE IN is equal than param
        List<ConcertStatisticDTO> FindByConcertDate(DateTime Time);
    }
    public class ConcertStatisticRepository : BaseRepository<ConcertStatisticDTO>, IConcertStatisticRepository
    {
        public ConcertStatisticRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public List<ConcertStatisticDTO> FindByConcertDate(DateTime Time)
        {
            return Context.concertStatisticDTOs
                .Where(x => x.DateIn.Date == Time.Date
                && x.DateIn.Month == Time.Month
                && x.DateIn.Year == Time.Year
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }

        public List<ConcertStatisticDTO> FindByConcertId(int ConcertId)
        {
            return Context.concertStatisticDTOs
                .Where(x => x.ConcertId == ConcertId
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }

        public List<ConcertStatisticDTO> FindByMaxViewer(int MaxViewer)
        {
            return Context.concertStatisticDTOs
                 .Where(x => x.MaxViewer >= MaxViewer
                 && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                 .ToList();
        }
    }
}
