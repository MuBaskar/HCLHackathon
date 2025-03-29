using System.ComponentModel.DataAnnotations;

namespace model
{
    public class VaccineMaster
    {
        [Key]
        int VaccineId { get; set; }

        [Required]
        string VaccineName { get; set; }
        string VaccineDescription { get; set; }
        DateTime CreatedOn { get; set; }
    }
}
