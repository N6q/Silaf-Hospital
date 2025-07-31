using Silaf_Hospital.DTOs;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IInvoiceService
    {
        void AddInvoice(InvoiceInputDTO input);
        void DeleteInvoice(string invoiceId);
        void UpdateInvoice(string invoiceId, InvoiceInputDTO input);
        void MarkInvoiceAsPaid(string invoiceId);
        InvoiceOutputDTO GetInvoiceById(string invoiceId);
        IEnumerable<InvoiceOutputDTO> GetInvoicesByPatientId(string patientId);
        IEnumerable<InvoiceOutputDTO> GetAllInvoices();
        void DisplayInvoice(string invoiceId);
    }
}
