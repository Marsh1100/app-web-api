

using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class IncidenciasContext : DbContext
    {
        public IncidenciasContext(DbContextOptions<IncidenciasContext> options) : base(options)
        {
        }
    }
}