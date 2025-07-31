using System.Collections.Generic;

namespace Silaf_Hospital.DTOs
{
    public class PatientRecordInputDTO
    {
        public string PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public string DiagnosisSummary { get; set; }
        public List<PrescriptionInputDTO> Prescriptions { get; set; }
        public List<string> Diagnoses { get; set; }   // names of diagnosis terms
    }
}
