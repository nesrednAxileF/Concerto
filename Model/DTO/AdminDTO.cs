using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("MsAdmin")]
    public class AdminDTO : BaseModel
    {
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("RoleId")]
        public int RoleId{ get; set; }
        [Column("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [Column("Gender")]
        public string Gender { get; set; }
        [Column("Preference")]
        public string Preference { get; set; }
    }
}
