using System;
using System.ComponentModel.DataAnnotations;

namespace Model.DTO.DB.Base
{
    public class ExecuteResultDTO
    {
        [Key]
        public int InstanceId { get; set; }
    }
}
