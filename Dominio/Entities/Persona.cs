

namespace Dominio.Entities;

public class Persona: BaseEntity
{
    
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Genero { get; set; }
    public string IdCiudadFK { get; set; }
    public string IdTipoPersona { get; set; }
}