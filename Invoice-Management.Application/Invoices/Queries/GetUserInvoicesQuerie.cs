using Invoice_Management.Application.Invoices.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Invoices.Queries
{
    public class GetUserInvoicesQuerie : IRequest<IList<InvoiceDTO>>
    {
        public String User { get; set; }
    }
}
