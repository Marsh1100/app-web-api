
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PaisRepository: GenericRepository<Pais>, IPais
{
    private readonly IncidenciasContext _context;

    public PaisRepository(IncidenciasContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises
            .Include(p=>p.Departamentos)
            .ToListAsync();
    }

    public override async Task<Pais> GetByIdAsync(string id)
    {
        return await _context.Paises
            .Include(p=>p.Departamentos)
            .FirstOrDefaultAsync(p=> p.Id == id);
    }
}
