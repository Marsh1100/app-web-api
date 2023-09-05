

using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;

public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly IncidenciasContext _context;
    public PersonaRepository(IncidenciasContext context) : base(context)
    {
        this._context = context;
    }

    public override async Task<IEnumerable<Persona>> GetAllAsync()
    {
        return await _context.Personas  
            .Include(p => p.Matriculas)
            .Include(p => p.TrainerSalones)
            .ToListAsync();
    }

    public override async Task<Persona> GetByIdAsync(string id)
    {
        return await _context.Personas
            .Include(p=>p.Matriculas)
            .Include(p=>p.TrainerSalones)
            .FirstOrDefaultAsync(p=> p.Id == id);
    }

}
