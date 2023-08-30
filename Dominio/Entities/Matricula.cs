
namespace Dominio.Entities;

public class Matricula : BaseEntity
{
    public string IdPersonaFK { get; set; }
    public Persona Persona { get; set; }
    public string IdSalonFK { get; set; }
    public Salon Salon { get; set; }
}
