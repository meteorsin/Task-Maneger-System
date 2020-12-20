using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XinyuLi.TaskManagerSystem.Core.Models.Request
{
    public class LoginRequestModel
    {
        [Required]        
        public int Id { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
