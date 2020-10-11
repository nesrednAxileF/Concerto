using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("MsConcert")]
    public class ConcertDTO : BaseModel
    {
        [Column("Title")]
        public string Title{ get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("Genre")]
        public string Genre { get; set; }
        [Column("DateTimeOpenTicket")]
        public DateTime DateTimeOpenTicket { get; set; }
        [Column("DateTimeConcert")]
        public DateTime DateTimeConcert { get; set; }
        [Column("Artist")]
        public string Artist { get; set; }
        [Column("AudienceQuota")]
        public int AudienceQuota { get; set; }
        [Column("TicketPrice")]
        public string TicketPrice { get; set; }
        [Column("LiveStreamId")]
        public string LiveStreamId { get; set; }
    }
}
