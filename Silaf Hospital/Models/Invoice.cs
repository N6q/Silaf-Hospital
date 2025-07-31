using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Models
{
    public class Invoice
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PatientId { get; set; }
        public string? AppointmentId { get; set; }
        public DateTime IssuedDate { get; set; } = DateTime.Now;

        public List<string> Services { get; set; } = new List<string>();
        public List<decimal> Charges { get; set; } = new List<decimal>();

        public bool IsPaid { get; set; } = false;

        public decimal TotalAmount
        {
            get
            {
                decimal total = 0;
                foreach (decimal charge in Charges)
                {
                    total += charge;
                }
                return total;
            }
        }

        public Invoice() { }

        public Invoice(string patientId, List<string> services, List<decimal> charges, string appointmentId = null)
        {
            Id = Guid.NewGuid().ToString();
            PatientId = patientId;
            AppointmentId = appointmentId;
            IssuedDate = DateTime.Now;
            Services = services;
            Charges = charges;
        }

        public void MarkAsPaid()
        {
            IsPaid = true;
            Console.WriteLine($"Invoice {Id} marked as paid.");
        }

        public bool IsValid()
        {
            return Services.Count == Charges.Count;
        }

        public void Display()
        {
            Console.WriteLine($" Invoice ID: {Id} | Patient: {PatientId} | Date: {IssuedDate}");
            Console.WriteLine("Services:");
            for (int i = 0; i < Services.Count; i++)
            {
                Console.WriteLine($"  - {Services[i],-20} {Charges[i],8:C}");
            }
            Console.WriteLine($" Total: {TotalAmount:C} | Status: {(IsPaid ? " Paid" : " Unpaid")}");
        }
    }
}
