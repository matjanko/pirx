using Microsoft.EntityFrameworkCore;
using Pirx.Shared.Abstractions.Persistence;

namespace Pirx.Shared.Infrastructure.Persistence;

public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
{
    private readonly DbContext _context;

    public UnitOfWork(TContext context)
    {
        _context = context;
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync(cancellationToken);
}