using Pirx.Modules.Expenses.Core.Domain.Issuers;
using Pirx.Modules.Expenses.Core.Domain.Receipts;
using Pirx.Modules.Expenses.Core.Infrastructure.Database;
using Pirx.Shared.Abstractions.Commands;
using Pirx.Shared.Abstractions.Persistence;

namespace Pirx.Modules.Expenses.Core.Application.Receipts.AddReceipt;

internal class AddReceiptCommandHandler : ICommandHandler<AddReceiptCommand>
{
    private readonly IReceiptRepository _receiptRepository;
    private readonly IIssuerRepository _issuerRepository;
    private readonly IUnitOfWork<ExpensesContext> _unitOfWork;

    public AddReceiptCommandHandler(
        IReceiptRepository receiptRepository, 
        IIssuerRepository issuerRepository, 
        IUnitOfWork<ExpensesContext> unitOfWork)
    {
        _receiptRepository = receiptRepository;
        _issuerRepository = issuerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task HandleAsync(AddReceiptCommand command)
    {
        var issuer = await _issuerRepository.GetAsync(command.IssuerId);

        if (issuer is null)
        {
            throw new Exception();
        }

        var receipt = new Receipt(command.IssueDate);
        receipt.AssignIssuer(issuer);
        await _receiptRepository.AddAsync(receipt);
        
        await _unitOfWork.CommitAsync();
    }
}