using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("MsConcertMerchandise")]
    public class ConcertMerchandiseDTO : BaseModel
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ConcertId")]
        public int ConcertId{ get; set; }
        [Column("MerchandiseName")]
        public string MerchandiseName { get; set; }
        [Column("ImageURL")]
        public string ImageURL { get; set; }
        [Column("MerchandiseURL")]
        public string MerchandiseURL { get; set; }
    }
}
