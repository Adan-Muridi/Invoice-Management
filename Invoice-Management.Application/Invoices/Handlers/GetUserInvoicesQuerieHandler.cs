using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetUserInvoicesQuerieHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<IList<InvoiceDTO>> Handle(GetUserInvoicesQuerie request, CancellationToken cancellationToken)
        {
            var result = new List<InvoiceDTO>();
            var invoices = await _applicationDbContext.Invoices.Include(i=>i.InvoiceItems)
                .Where(i=>i.CreatedBy==request.User).ToListAsync();
            if(invoices !=null) 
            {
                result = _mapper.Map<List<InvoiceDTO>>(invoices); 
            }

            return result;
        }
    }
}