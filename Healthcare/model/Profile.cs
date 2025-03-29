using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Profile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileID { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        public string? AllergieDetails { get; set; }
        public string? MedicalHistory { get; set; }
        public string? PastVaccinationDetails { get; set; }

        public bool? IsAllergie { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
