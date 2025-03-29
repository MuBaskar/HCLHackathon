using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class PatientVaccinationDetail
    {
        [Key]
        int PatientVaccinationId { get; set; }
        int VaccineId { get; set; }
        int UserId { get; set; }

        [Required]
        DateTime VaccinationDate { get; set; }
        int StatusId { get; set; }
        string RequestedBy { get; set; }
        DateTime RequestedOn { get; set; }
        string ApprovedBy { get; set; }
        DateTime ApprovedOn { get; set; }
    }
}
