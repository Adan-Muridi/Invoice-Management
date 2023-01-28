using Invoice_Management.Application.Common.Interfaces;
using Invoice_Management.Application.Invoices.DTOs;
using Invoice_Management.Application.Invoices.Queries;
using Invoice_Management.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Invoices.Handlers
{
    public class GetUserInvoicesQuerieHandler : IRequestHandler<GetUserInvoicesQuerie, IList<InvoiceDTO>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetUserInvoicesQuerieHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IList<InvoiceDTO>> Handle(GetUserInvoicesQuerie request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceDTO>();
            var invoices = await _applicationDbContext.Invoices.Include(i=>i.InvoiceItems)
                .Where(i=>i.CreatedBy==request.User).ToListAsync();
            if(invoices !=null) 
            {
                result = invoices.Select(i=> new InvoiceDTO
                {

                    id=i.id,
                    InvoiceNumber=i.InvoiceNumber,
                    Logo=i.Logo,
                    Form=i.Form,
                    To=i.To,
                    Date=i.Date,
                    PaymentTerms=i.PaymentTerms,
                    DueDate=i.DueDate,
                    Discount=i.Discount,
                    DiscountType=i.DiscountType,
                    Tax=i.Tax,
                    TaxType=i.TaxType,
                    AmountPaid=i.AmountPaid,
                    Created=i.Created,
                    InvoiceItems=i.InvoiceItems.Select(item=>new InvoiceItemDTO
                    {
                        Id=item.Id,
                        Item=item.Item,
                        Quantiity=item.Quantiity,
                        Rate=item.Rate,
                    }).ToList()
                }).ToList();
            }

            return result;
        }
    }
}