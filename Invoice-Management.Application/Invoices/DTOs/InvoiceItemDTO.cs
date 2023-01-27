using Invoice_Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Invoice_Management.Application.Invoices.DTOs
{
    public class InvoiceItemDTO
    {
        public int Id { get; set; }
        public string? Item { get; set; }
        public Double Quantiity { get; set; }
        public double Rate { get; set; }
        public Invoice invoice { get; set; }

        public double Amount
        {
            get
            { 
                return Quantiity*Rate; 
            }
        }

    }
}
