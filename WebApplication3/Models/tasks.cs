using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Tasks")]
    public class tasks
    {
        public int ID { get; set; }

        [Display(Name = "Assigned Tasks")]
        public string Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //fk on priority table
        public int Priority { get; set; }

        //fk on status table
        public string status { get; set; }

        //fk on user table
        public int AssignedTo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }

        [ForeignKey("Owner")]
        public virtual User TaskOwner { get; set; }
        [ForeignKey("AssignedTo")]
        public virtual User AssignedUser { get; set; }
        [ForeignKey("Priority")]
        public virtual Priority TaskPriority { get; set; }
        [ForeignKey("Status")]
        public virtual Status TaskStatus { get; set; }

    }
}