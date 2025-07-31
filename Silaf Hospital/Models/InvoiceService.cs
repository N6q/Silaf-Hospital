using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Silaf_Hospital.Services
{
    public class InvoiceService : IInvoiceService
    {
        private List<Invoice> invoices;
        private readonly InvoiceFileHandler fileHandler;

        public InvoiceService()
        {
            fileHandler = new InvoiceFileHandler();
            invoices = fileHandler.LoadInvoicesFromTxt();
        }

        public void AddInvoice(InvoiceInputDTO input)
        {
            Invoice invoice = new Invoice(input.PatientId, input.Services, input.Charges, input.AppointmentId);
            if (!invoice.IsValid())
            {
                Console.WriteLine("Mismatch between services and charges.");
                return;
            }

            invoices.Add(invoice);
            fileHandler.SaveInvoicesToTxt(invoices);
            Console.WriteLine("Invoice added successfully.");
        }

        public void DeleteInvoice(string invoiceId)
        {
            Invoice invoice = null;
            foreach (var i in invoices)
            {
                if (i.Id == invoiceId)
                {
                    invoice = i;
                    break;
                }
            }

            if (invoice != null)
            {
                invoices.Remove(invoice);
                fileHandler.SaveInvoicesToTxt(invoices);
                Console.WriteLine("Invoice deleted.");
            }
            else
            {
                Console.WriteLine("Invoice not found.");
            }
        }

        public void UpdateInvoice(string invoiceId, InvoiceInputDTO input)
        {
            foreach (var invoice in invoices)
            {
                if (invoice.Id == invoiceId)
                {
                    if (input.Services.Count != input.Charges.Count)
                    {
                        Console.WriteLine("Mismatch between services and charges.");
                        return;
                    }

                    invoice.PatientId = input.PatientId;
                    invoice.AppointmentId = input.AppointmentId;
                    invoice.Services = input.Services;
                    invoice.Charges = input.Charges;

                    fileHandler.SaveInvoicesToTxt(invoices);
                    Console.WriteLine("Invoice updated.");
                    return;
                }
            }

            Console.WriteLine("Invoice not found.");
        }

        public void MarkInvoiceAsPaid(string invoiceId)
        {
            foreach (var invoice in invoices)
            {
                if (invoice.Id == invoiceId)
                {
                    invoice.MarkAsPaid();
                    fileHandler.SaveInvoicesToTxt(invoices);
                    return;
                }
            }

            Console.WriteLine("Invoice not found.");
        }

        public InvoiceOutputDTO GetInvoiceById(string invoiceId)
        {
            foreach (var invoice in invoices)
            {
                if (invoice.Id == invoiceId)
                {
                    return new InvoiceOutputDTO
                    {
                        Id = invoice.Id,
                        PatientId = invoice.PatientId,
                        AppointmentId = invoice.AppointmentId,
                        IssuedDate = invoice.IssuedDate,
                        Services = invoice.Services,
                        TotalAmount = invoice.TotalAmount,
                        IsPaid = invoice.IsPaid
                    };
                }
            }

            return null;
        }

        public IEnumerable<InvoiceOutputDTO> GetInvoicesByPatientId(string patientId)
        {
            List<InvoiceOutputDTO> result = new List<InvoiceOutputDTO>();
            foreach (var invoice in invoices)
            {
                if (invoice.PatientId == patientId)
                {
                    result.Add(new InvoiceOutputDTO
                    {
                        Id = invoice.Id,
                        PatientId = invoice.PatientId,
                        AppointmentId = invoice.AppointmentId,
                        IssuedDate = invoice.IssuedDate,
                        Services = invoice.Services,
                        TotalAmount = invoice.TotalAmount,
                        IsPaid = invoice.IsPaid
                    });
                }
            }

            return result;
        }

        public IEnumerable<InvoiceOutputDTO> GetAllInvoices()
        {
            List<InvoiceOutputDTO> result = new List<InvoiceOutputDTO>();
            foreach (var invoice in invoices)
            {
                result.Add(new InvoiceOutputDTO
                {
                    Id = invoice.Id,
                    PatientId = invoice.PatientId,
                    AppointmentId = invoice.AppointmentId,
                    IssuedDate = invoice.IssuedDate,
                    Services = invoice.Services,
                    TotalAmount = invoice.TotalAmount,
                    IsPaid = invoice.IsPaid
                });
            }

            return result;
        }

        public void DisplayInvoice(string invoiceId)
        {
            foreach (var invoice in invoices)
            {
                if (invoice.Id == invoiceId)
                {
                    invoice.Display();
                    return;
                }
            }

            Console.WriteLine("Invoice not found.");
        }
    }
}
