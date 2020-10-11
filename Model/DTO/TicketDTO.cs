using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("TrTicket")]
    public class TicketDTO : BaseModel
    {
        [Column("ConcertId")]
        public int ConcertId { get; set; }
        [Column("UserId")]
        public int UserId{ get; set; }
    }
}
