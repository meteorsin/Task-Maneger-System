﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XinyuLi.TaskManagerSystem.Core.Models.Response
{
    public class TaskResponseModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Priority { get; set; }
        public string? Remarks { get; set; }
    }
}
