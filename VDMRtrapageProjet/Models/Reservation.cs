using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VDMRtrapageProjet.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResrvationId { get; set; }

        [Required]
        [Display(Name = "Date de reservation")]
        [DataType(DataType.Date)]
        public DateTime DateDeReservation { get; set; }

        [Required]
        [Display(Name = "Tarif")]
        [DataType(DataType.Currency)]
        public double tarif { get; set; }

        //public IEnumerable<Personne> personne { get; set; }

        //public IEnumerable<Salle> salle { get; set; }
        public int PersonneID { get; set; }
        public int SalleID { get; set; }
        public int ThemeID { get; set; }
        
        public virtual Personne personne { get; set; }
        public virtual Salle salle { get; set; }
        public virtual Theme theme { get; set; }

        
    }
}