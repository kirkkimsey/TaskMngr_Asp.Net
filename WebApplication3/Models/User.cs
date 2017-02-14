using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [Table("Users")]
    public class User
    {
        public int ID { get; set;}

        [Display(Name = "Assigned User")]
        public string fName {get; set;}
        public string lName { get; set;}
        public string email { get; set;}
        public string pNumber { get; set;}
        public DateTime DOB { get; set;}

    }
}