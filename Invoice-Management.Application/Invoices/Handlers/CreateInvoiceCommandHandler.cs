using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IApplicationDbContext applicationDbContext,IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Invoice>(request);

            _applicationDbContext.Invoices.Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return entity.id;
        }
    }
}
