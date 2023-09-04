
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class CiudadRepository: GenericRepository<Ciudad>, ICiudad
{
    private readonly IncidenciasContext _context;

    public CiudadRepository(IncidenciasContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades
            .Include(p=>p.Personas)
            .ToListAsync();
    }

    public override async Task<Ciudad> GetByIdAsync(string id)
    {
        return await _context.Ciudades
            .Include(p=>p.Personas)
            .FirstOrDefaultAsync(p=> p.Id == id);
    }
}
