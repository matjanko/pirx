using Microsoft.AspNetCore.Mvc;
using Pirx.Modules.Expenses.Core.Application.Receipts.AddReceipt;
using Pirx.Shared.Abstractions.Dispatchers;

namespace Pirx.Modules.Expenses.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceiptsController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public ReceiptsController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody] AddReceiptCommand command)
    {
        await _dispatcher.SendAsync(command);
        return Ok();
    }
}