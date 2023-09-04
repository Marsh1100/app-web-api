
using Aplicacion.Repository;
using Dominio.Interfaces;

namespace Persistencia.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IncidenciasContext _context;
   private DepartamentoRepository _dep;

    public UnitOfWork(IncidenciasContext context)
    {
        this._context = context;
    }

    private PaisRepository _paises;

    public IPais Paises
    {
        get{
            if(_paises == null){
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }


    public IDepartamento Departamentos
    {
        get{
            if(_dep == null){
                _dep = new DepartamentoRepository(_context);
            }
            return _dep;
        }
    }

    public void Dispose()
    {
        _context.Dispose();    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();

    }

   
}
