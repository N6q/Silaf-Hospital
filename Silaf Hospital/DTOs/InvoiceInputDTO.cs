using System;
using System.Collections.Generic;

namespace Silaf_Hospital.DTOs
{
    public class InvoiceInputDTO
    {
        public string PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public List<string> Services { get; set; }
        public List<decimal> Charges { get; set; }
    }
}
