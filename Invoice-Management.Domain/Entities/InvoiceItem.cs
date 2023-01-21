using Invoice_Management.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Domain.Entities
{
    public class InvoiceItem : AuditableEntity
    {
        public int Id { get; set; }
        public int  InvoiceId { get; set; }
        public string? Item { get; set; }
        public Double Quantiity { get; set; }
        public double Rate { get; set; }
        public Invoice invoice { get; set; }
    }
}
