using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDMRtrapageProjet.Models
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThemeID { get; set; }

        [Required]
        [Display(Name = "Theme")]
        public string NomTheme { get; set; }
        public IEnumerable<Reservation> reservation { get; set; }
    }
}