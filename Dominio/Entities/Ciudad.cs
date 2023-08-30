

namespace Dominio.Entities;

public class Ciudad: BaseEntity
{
    public string NombreCiu { get; set; }
    public string IdDepFK { get; set; }
    public Departamento Departamento { get; set; }

    public ICollection<Persona> Personas {get; set;}


}