using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchedulingApp.Models
{
    public class MasterSchedule
    {
        [Key]
        public virtual string UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual string RoleId { get; set; }
    }
}