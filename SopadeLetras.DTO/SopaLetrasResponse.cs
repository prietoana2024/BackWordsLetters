using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopadeLetras.DTO
{
    public class SopaLetrasResponse
    {
        public List<string> PalabrasEncontradas { get; set; } = new();
        public List<string> PalabrasNoEncontradas { get; set; } = new();
    }
}
