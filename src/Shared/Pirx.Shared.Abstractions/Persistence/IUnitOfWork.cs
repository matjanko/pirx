using Microsoft.EntityFrameworkCore;

namespace Pirx.Shared.Abstractions.Persistence;

public interface IUnitOfWork<TContext> where TContext : DbContext
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}