using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2_part3.Models
{   [Table("players")]
    public class player
    {   [Key]
        
        public int player_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        public decimal? salary { get; set; }
        [StringLength(20)]
        public string position { get; set; }

        public decimal? points_per_game { get; set; }

        public decimal? rebonds_per_game { get; set; }
        [StringLength(50)]
        public string injury { get; set; }

        public int? team_id { get; set; }
        //public virtual team team { get; set; }
    }
}
