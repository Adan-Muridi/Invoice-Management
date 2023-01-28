using FluentValidation;
using Invoice_Management.Application.Invoices.Commands;
using Invoice_Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Invoices.Validators
{
    public class CreateInvoiceCommandValidators : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidators()
        {
            RuleFor(x=>x.AmountPaid).NotNull();
            RuleFor(x=>x.Date).NotNull();
            RuleFor(x=>x.Form).NotEmpty().MinimumLength(3);
            RuleFor(x=>x.To).NotEmpty().MinimumLength(3);
            RuleFor(x => x.InvoiceItems).SetValidator(new MusthaveInvoiceItemPropertyValidator());
            //RuleFor(x => x.InvoiceItems).NotNull();  Remove if custom validator works !!
        }
    }
}
