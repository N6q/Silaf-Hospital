using System;
using System.Collections.Generic;
using System.IO;
using Silaf_Hospital.Models;

namespace Silaf_Hospital.FilesHandling
{
    public class InvoiceFileHandler
    {
        private readonly string filePath = "Data/invoices.txt";

        public List<Invoice> LoadInvoicesFromTxt()
        {
            var invoices = new List<Invoice>();

            if (!File.Exists(filePath))
                return invoices;

            var lines = File.ReadAllLines(filePath);
            Invoice invoice = null;

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                if (line.StartsWith("InvoiceId:"))
                {
                    if (invoice != null)
                        invoices.Add(invoice);

                    invoice = new Invoice
                    {
                        Id = line.Split(':')[1].Trim()
                    };
                }
                else if (line.StartsWith("PatientId:"))
                {
                    invoice.PatientId = line.Split(':')[1].Trim();
                }
                else if (line.StartsWith("AppointmentId:"))
                {
                    invoice.AppointmentId = line.Split(':')[1].Trim();
                }
                else if (line.StartsWith("IssuedDate:"))
                {
                    invoice.IssuedDate = DateTime.Parse(line.Split(':')[1].Trim());
                }
                else if (line.StartsWith("IsPaid:"))
                {
                    invoice.IsPaid = bool.Parse(line.Split(':')[1].Trim());
                }
                else if (line.StartsWith("Service:"))
                {
                    invoice.Services.Add(line.Split(':')[1].Trim());
                }
                else if (line.StartsWith("Charge:"))
                {
                    invoice.Charges.Add(decimal.Parse(line.Split(':')[1].Trim()));
                }
            }

            if (invoice != null)
                invoices.Add(invoice);

            return invoices;
        }

        public void SaveInvoicesToTxt(List<Invoice> invoices)
        {
            var lines = new List<string>();

            foreach (var inv in invoices)
            {
                lines.Add($"InvoiceId: {inv.Id}");
                lines.Add($"PatientId: {inv.PatientId}");
                lines.Add($"AppointmentId: {inv.AppointmentId}");
                lines.Add($"IssuedDate: {inv.IssuedDate}");
                lines.Add($"IsPaid: {inv.IsPaid}");

                for (int i = 0; i < inv.Services.Count; i++)
                {
                    lines.Add($"Service: {inv.Services[i]}");
                    lines.Add($"Charge: {inv.Charges[i]}");
                }

                lines.Add(""); // Empty line between invoices
            }

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllLines(filePath, lines);
        }
    }
}
