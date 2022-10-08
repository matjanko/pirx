namespace Pirx.Modules.Expenses.Core.Domain.Issuers;

internal interface IIssuerRepository
{
    Task<Issuer?> GetAsync(int id);
}