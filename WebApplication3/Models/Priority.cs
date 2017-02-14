using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Priority")]
    public class Priority
    {
        public int ID { get; set; }

        [Display(Name = "Priority")]
        public string Description { get; set; }
    }
}