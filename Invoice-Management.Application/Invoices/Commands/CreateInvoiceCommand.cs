using Invoice_Management.Application.Invoices.DTOs;
using Invoice_Management.Domain.Entities;
using Invoice_Management.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Invoices.Commands
{
    public class CreateInvoiceCommand : IRequest<int>
    {
        public CreateInvoiceCommand()
        {
            this.InvoiceItems = new List<InvoiceItemDTO>();
        }

        public int InvoiceNumber { get; set; }
        public string? Logo { get; set; }
        public string? Form { get; set; }
        public string? To { get; set; }
        public DateTime Date { get; set; }
        public string? PaymentTerms { get; set; }
        public DateTime? DueDate { get; set; }
        public double Discount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double Tax { get; set; }
        public TaxType TaxType { get; set; }
        public double AmountPaid { get; set; }
        public List<InvoiceItemDTO> InvoiceItems { get; set; }

    }
}
