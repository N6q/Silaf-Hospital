using System;
using System.Collections.Generic;

namespace Silaf_Hospital.DTOs
{
    public class PatientRecordOutputDTO
    {
        public string Id { get; set; }
        public DateTime VisitDate { get; set; }
        public string DiagnosisSummary { get; set; }
        public List<string> Diagnoses { get; set; }
        public List<PrescriptionOutputDTO> Prescriptions { get; set; }
    }
}
