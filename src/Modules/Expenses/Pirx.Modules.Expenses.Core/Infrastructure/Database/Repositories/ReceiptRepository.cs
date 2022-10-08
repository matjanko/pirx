using Pirx.Modules.Expenses.Core.Domain.Receipts;

namespace Pirx.Modules.Expenses.Core.Infrastructure.Database.Repositories;

internal class ReceiptRepository : IReceiptRepository
{
    private readonly ExpensesContext _context;

    public ReceiptRepository(ExpensesContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Receipt receipt)
    {
        await _context.Receipts.AddAsync(receipt);
    }
}