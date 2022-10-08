using Pirx.Shared.Abstractions.Kernel;

namespace Pirx.Modules.Expenses.Core.Domain.Issuers;

internal class Issuer : Entity
{
    private IssuerName _name;
    private int _categoryId;

    private Issuer() {}
    
    public Issuer(string name, int categoryId)
    {
        _name = new IssuerName(name);
        _categoryId = categoryId;
    }
}