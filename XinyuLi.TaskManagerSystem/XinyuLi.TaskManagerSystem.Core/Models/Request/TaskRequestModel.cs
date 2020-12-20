using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using XinyuLi.TaskManagerSystem.Core.Entities;

namespace XinyuLi.TaskManagerSystem.Core.Models.Request
{
    public class TaskRequestModel
    {
        [Required]
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Remarks { get; set; }
    }
}
