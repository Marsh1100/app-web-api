using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

public class TrainerSalon 
{
    public string IdPersonaFK { get; set; }
    public Persona Persona { get; set; }
    public string IdSalonFK {get; set; }
    public Salon Salon { get; set; }

}
