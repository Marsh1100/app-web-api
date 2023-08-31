

namespace Dominio.Entities;

public class Persona: BaseEntity
{
    
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; set; }
    public string Genero { get; set; }
    public string IdCiudadFK { get; set; }
    public Ciudad Ciudad { get; set; }
    public string IdTipoPersonaFK { get; set; }
    public TipoPersona TipoPersona { get; set; }

    public ICollection<TrainerSalon> TrainerSalones {get; set;}
    public ICollection<Matricula> Matriculas {get; set;}


}