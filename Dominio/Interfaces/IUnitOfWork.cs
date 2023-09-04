
namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IPais Paises { get; }
    IDepartamento Departamentos { get; }
    Task<int> SaveAsync();
}
