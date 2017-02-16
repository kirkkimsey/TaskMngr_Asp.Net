using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Tasks")]
    public class Tasks
    {
        public int ID { get; set; }

        [Display(Name = "Assigned Tasks")]
        public int OwnerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //fk on priority table
        public int PriorityID { get; set; }

        //fk on status table
        public int StatusID { get; set; }

        //fk on user table
        public int? AssignedToID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompleteDate { get; set; }

        [ForeignKey("OwnerID")]
        public virtual User TaskOwner { get; set; }
        [ForeignKey("AssignedToID")]
        public virtual User AssignedUser { get; set; }
        [ForeignKey("PriorityID")]
        public virtual Priority TaskPriority { get; set; }
        [ForeignKey("StatusID")]
        public virtual Status TaskStatus { get; set; }

    }
}