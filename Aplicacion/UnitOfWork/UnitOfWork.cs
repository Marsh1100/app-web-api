
using Aplicacion.Repository;
using Dominio.Interfaces;

namespace Persistencia.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IncidenciasContext _context;

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

   private DepartamentoRepository _dep;

    public IDepartamento Departamentos
    {
        get{
            if(_dep == null){
                _dep = new DepartamentoRepository(_context);
            }
            return _dep;
        }
    }

    private CiudadRepository _ciudad;
    public ICiudad Ciudades
    {
        get{
            if(_ciudad == null){
                _ciudad = new CiudadRepository(_context);
            }
            return _ciudad;
        }
    }

    private PersonaRepository _persona;

    public IPersona Personas
    {
        get{
            if(_persona == null)
            {
                _persona = new PersonaRepository(_context);
            }
            return _persona;
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
