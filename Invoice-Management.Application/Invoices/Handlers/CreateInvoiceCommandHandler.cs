using Invoice_Management.Application.Common.Interfaces;
using Invoice_Management.Application.Invoices.Commands;
using Invoice_Management.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateInvoiceCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Invoice
            {
                AmountPaid = request.AmountPaid,
                Date = request.Date,
                Discount = request.Discount,
                DueDate = request.DueDate,
                Form = request.Form,
                InvoiceNumber = request.InvoiceNumber,
                Logo = request.Logo,
                PaymentTerms = request.PaymentTerms,
                Tax = request.Tax,
                To = request.To,
                InvoiceItems = request.InvoiceItems.Select(x => new InvoiceItem
                {
                    Item = x.Item,
                    Quantiity = x.Quantiity,
                    Rate = x.Rate,
                }).ToList(),
            };
            _applicationDbContext.Invoices.Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return entity.id;
        }
    }
}
