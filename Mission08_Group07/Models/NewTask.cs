using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission08_Group07.Models
{
    public class NewTask
    {
        [Required]
        [Key]
        public int TaskID { get;  set; }

        [Required]
        public string Task { get;  set; }
        public DateTime Due_Date { get; set; }
        [Required]
        public int QuadrantNumber { get ;  set; }
        public bool Completed { get;  set; }

        // Foreign Key
        public int CategoryID { get; set; }
        public Category Category { get;  set; }

    }
}
