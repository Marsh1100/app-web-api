using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DepxCiudadesDto
    {
        public string Id { get; set; }
        public string NombreDep { get; set;}
        public List<CiudadDto> ciudades { get; set; }
    }
}