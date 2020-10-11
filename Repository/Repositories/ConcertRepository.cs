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
    public interface IConcertRepository : IRepository<ConcertDTO>
    {
        List<ConcertDTO> FindByGenre(string Genre);
        List<ConcertDTO> FindByArtist(string Artist);
        //Find where Date , Month , And Year less or equal than param
        List<ConcertDTO> FindByDateTimeOpenTicket(DateTime Time);
        //Find where Minute , Date , Month , And Year less or equal than param
        List<ConcertDTO> FindByDateTimeConcert(DateTime Time);
    }
    public class ConcertRepository : BaseRepository<ConcertDTO>, IConcertRepository
    {
        public ConcertRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }

        public List<ConcertDTO> FindByArtist(string Artist)
        {
            return Context.concertDTOs
                .Where(x => x.Artist.Trim().ToLower().Contains(Artist.Trim().ToLower())
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }

        public List<ConcertDTO> FindByDateTimeConcert(DateTime Time)
        {
            return Context.concertDTOs
                .Where(x => x.DateTimeConcert.Day <= Time.Day
                && x.DateTimeConcert.Month <= Time.Month
                && x.DateTimeConcert.Year <= Time.Year
                && x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }

        public List<ConcertDTO> FindByDateTimeOpenTicket(DateTime Time)
        {
            return Context.concertDTOs
               .Where(x => x.DateTimeOpenTicket <= Time
               && x.StrSc.Equals(BaseConstraint.StrSC.Active))
               .ToList();
        }

        public List<ConcertDTO> FindByGenre(string Genre)
        {
            return Context.concertDTOs
                .Where(x => x.Genre.ToLower().Trim().Contains(Genre.ToLower()
                .Trim()) &&
                x.StrSc.Equals(BaseConstraint.StrSC.Active))
                .ToList();
        }
    }
}
