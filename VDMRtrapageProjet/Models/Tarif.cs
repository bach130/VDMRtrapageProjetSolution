using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDMRtrapageProjet.Models
{
    public class Tarif
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TarifID { get; set; }

        //[Required]
        //[Display(Name = "Nom de la salle")]
        //public string NomSalle { get; set; }

        [Required]
        [Display(Name = "Tarif")]
        [DataType(DataType.Currency)]
        public double tarif { get; set; }
        public IEnumerable<Reservation> reservation { get; set; }
    }
}