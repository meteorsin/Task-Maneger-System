using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XinyuLi.TaskManagerSystem.Core.Entities
{
    public class TaskHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TaskId { get; set; }
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? Completed { get; set; }
        public string? Remarks { get; set; }
        public User User { get; set; }
    }
}
