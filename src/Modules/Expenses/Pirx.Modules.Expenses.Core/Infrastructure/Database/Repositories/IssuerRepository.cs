using Microsoft.EntityFrameworkCore;
using Pirx.Modules.Expenses.Core.Domain.Issuers;

namespace Pirx.Modules.Expenses.Core.Infrastructure.Database.Repositories;

internal class IssuerRepository : IIssuerRepository
{
    private readonly ExpensesContext _context;

    public IssuerRepository(ExpensesContext context)
    {
        _context = context;
    }

    public async Task<Issuer?> GetAsync(int id)
    {
        return await _context.Issuers.SingleOrDefaultAsync(x => x.Id == id);
    }
}