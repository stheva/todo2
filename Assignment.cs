using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}