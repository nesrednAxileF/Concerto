using Model.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.DTO
{
    [Table("MsRole")]
    public class RoleDTO : BaseModel
    {
        [Column("Name")]
        public string Name { get; set; }
    }
}
