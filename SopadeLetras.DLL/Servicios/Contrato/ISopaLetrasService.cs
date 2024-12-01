using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SopadeLetras.DTO;

namespace SopadeLetras.DLL.Servicios.Contrato
{
    public interface ISopaLetrasService
    {
        SopaLetrasResponse BuscarPalabras(SopaLetrasRequest request);
    }
}
