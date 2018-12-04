using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_part3.Models
{
    [Table("teams")]
    public class team
    {   
       [Key]
        public int team_id { get; set; }

        [Required]
        
        public string team_name { get; set; }

        [StringLength(20)]
        public string conference { get; set; }

        [StringLength(50)]
        public string owner { get; set; }

        public int? win { get; set; }

        public int? lost { get; set; }

    }
}
