using Invoice_Management.Domain.Common;
using Invoice_Management.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Domain.Entities
{
    public class Invoice :AuditableEntity
    {
        public Invoice()
        {
            this.InvoiceItems = new List<InvoiceItem>();
        }

        public int id { get; set; }
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
        public List<InvoiceItem> InvoiceItems { get; set; }

    }
}
