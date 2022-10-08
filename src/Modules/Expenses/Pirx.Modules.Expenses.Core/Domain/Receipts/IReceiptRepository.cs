namespace Pirx.Modules.Expenses.Core.Domain.Receipts;

internal interface IReceiptRepository
{
    Task AddAsync(Receipt receipt);
}