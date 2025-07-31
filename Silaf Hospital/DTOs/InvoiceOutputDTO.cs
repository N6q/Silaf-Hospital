using System;
using System.Collections.Generic;

namespace Silaf_Hospital.DTOs
{
    public class InvoiceOutputDTO
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string AppointmentId { get; set; }
        public DateTime IssuedDate { get; set; }
        public List<string> Services { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsPaid { get; set; }
    }
}
