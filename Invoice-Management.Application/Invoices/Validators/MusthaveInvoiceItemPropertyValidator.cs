using FluentValidation;
using FluentValidation.Validators;
using Invoice_Management.Application.Invoices.Commands;
using Invoice_Management.Application.Invoices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Management.Application.Invoices.Validators
{
    internal class MusthaveInvoiceItemPropertyValidator : PropertyValidator<CreateInvoiceCommand, List<InvoiceItemDTO>>
    {

        public override string Name => "Must have InvoiceItem Property Validator.";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "A value for {PropertyName} is required and should not be an empty list";

        public override bool IsValid(ValidationContext<CreateInvoiceCommand> context, List<InvoiceItemDTO> value)
        {
            return value.Count > 0 &&value.Any();
        }
    }
}
