using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("MsConcertStatistic")]
    public class ConcertStatisticDTO : BaseModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ConcertId")]
        public int ConcertId{ get; set; }
        [Column("MaxViewer")]
        public int MaxViewer { get; set; }
        [Column("TotalReaction")]
        public int TotalReaction { get; set; }
        [Column("TotalChatbox")]
        public int TotalChatbox { get; set; }
    }
}
