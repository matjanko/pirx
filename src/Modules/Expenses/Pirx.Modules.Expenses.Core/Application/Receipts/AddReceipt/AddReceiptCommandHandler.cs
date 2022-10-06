using Pirx.Shared.Abstractions.Commands;

namespace Pirx.Modules.Expenses.Core.Application.Receipts.AddReceipt;

public class AddReceiptCommandHandler : ICommandHandler<AddReceiptCommand>
{
    public Task HandleAsync(AddReceiptCommand command)
    {
        throw new NotImplementedException();
    }
}