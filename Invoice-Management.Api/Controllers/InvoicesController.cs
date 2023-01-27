using Invoice_Management.Api.Controllers.Base;
using Invoice_Management.Application.Invoices.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoice_Management.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //[Authorize]
    public class InvoicesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<int>> CreateInvoice(CreateInvoiceCommand command)
        {

            return await Mediator.Send(command);
        }
    }
}
