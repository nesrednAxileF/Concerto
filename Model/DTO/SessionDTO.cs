using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("TrSession")]
    public class SessionDTO : BaseModel
    {
        [Column("ConcertId")]
        public int ConcertId { get; set; }

        [Column("UserId")]
        public int UserId { get; set; }
        [Column("TimeIn")]
        public DateTime TimeIn { get; set; }
        [Column("TimeOut")]
        public DateTime? TimeOut{ get; set; }
    }
}
