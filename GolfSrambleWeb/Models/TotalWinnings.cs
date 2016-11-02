using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GolfSrambleWeb.Models
{
    public class TotalWinnings:Winnings
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Level Required")]
        public string Level { get; set; }

        [Required(ErrorMessage = "Winnings Required")]
        public string Total { get; set; }
    }
}