using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SopadeLetras.DTO
{
    public class SopaLetrasRequest
    {
        public List<string> Palabra { get; set; }
        public string Caractere { get; set; }
    }
}
