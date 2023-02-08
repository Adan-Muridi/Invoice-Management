using Invoice_Management.Api.Controllers.Base;
using Invoice_Management.Application.Common.Interfaces;
using Invoice_Management.Application.Invoices.Commands;
using Invoice_Management.Application.Invoices.DTOs;
using Invoice_Management.Application.Invoices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InvoicesController : BaseApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public InvoicesController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateInvoice(CreateInvoiceCommand command)
        {

            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<IList<InvoiceDTO>> GetInvoices()
        {

            return await Mediator.Send(new GetUserInvoicesQuerie { User = _currentUserService.UserId });
        }
    }
}
