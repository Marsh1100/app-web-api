using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class CiudadDto
    {
        public string Id { get; set; }
        public string IdDepFK { get; set; }
        public string NombreCiu { get; set; }
    }
}