using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities;

public class TrainerSalon : BaseEntity
{
    public string IdPersonaFK { get; set; }
    public string IdSalonFK {get; set; }
}
