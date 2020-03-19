using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDMRtrapageProjet.Models
{
    public class Salle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalleID { get; set; }

        [Required]
        [Display(Name = "Nom de la salle")]
        public string NomSalle { get; set; }

        //[Required]
        //[Display(Name ="Tarif")]
        //[DataType(DataType.Currency)]
        //public double tarif { get; set; }
        //public int ResrvationId { get; set; }
        //public virtual Reservation reservation { get; set; }

        public IEnumerable<Reservation> reservation { get; set; }
    }
}