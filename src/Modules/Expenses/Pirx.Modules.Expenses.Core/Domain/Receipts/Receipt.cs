using Pirx.Modules.Expenses.Core.Domain.Issuers;
using Pirx.Shared.Abstractions.Kernel;

namespace Pirx.Modules.Expenses.Core.Domain.Receipts;

internal class Receipt : AggregateRoot
{
    private DateTime _issueDate;
    private int _issuerId;
    
    private Receipt() {}

    public Receipt(DateTime issueDate)
    {
        _issueDate = issueDate;
    }

    public void AssignIssuer(Issuer issuer)
    {
        _issuerId = issuer.Id;
    }
}