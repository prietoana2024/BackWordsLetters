using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SopadeLetras.DLL.Servicios.Contrato;
using SopadeLetras.DTO;

namespace SopadeLetras.DLL.Servicios
{
    public class SopaLetrasService:ISopaLetrasService
    {
        private const int MATRIX_SIZE = 14;

        public SopaLetrasResponse BuscarPalabras(SopaLetrasRequest request)
        {
            var matriz = CrearMatriz(request.Caractere);
            var response = new SopaLetrasResponse
            {
                PalabrasEncontradas = new List<string>(),
                PalabrasNoEncontradas = new List<string>()
            };

            foreach (var palabra in request.Palabra)
            {
                if (BuscarPalabra(matriz, palabra))
                {
                    response.PalabrasEncontradas.Add(palabra);
                }
                else
                {
                    response.PalabrasNoEncontradas.Add(palabra);
                }
            }
            return response;
        }

        private string[,] CrearMatriz(string matrizStr)
        {
            var filas = matrizStr.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            if (filas.Length != MATRIX_SIZE)
            {
                throw new ArgumentException($"La matriz debe tener exactamente {MATRIX_SIZE} filas");
            }

            var matriz = new string[MATRIX_SIZE, MATRIX_SIZE];
            for (int i = 0; i < filas.Length; i++)
            {
                var caracteres = filas[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                if (caracteres.Length != MATRIX_SIZE)
                {
                    throw new ArgumentException($"Cada fila debe tener exactamente {MATRIX_SIZE} caracteres");
                }

                for (int j = 0; j < caracteres.Length; j++)
                {
                    matriz[i, j] = caracteres[j].Trim().ToUpper();
                }
            }
            return matriz;
        }

        private bool BuscarPalabra(string[,] matriz, string palabra)
        {
            palabra = palabra.ToUpper();
            // Definir las 8 direcciones posibles de búsqueda
            var direcciones = new (int dx, int dy)[]
            {
            (-1, -1), // Diagonal superior izquierda
            (-1, 0),  // Arriba
            (-1, 1),  // Diagonal superior derecha
            (0, -1),  // Izquierda
            (0, 1),   // Derecha
            (1, -1),  // Diagonal inferior izquierda
            (1, 0),   // Abajo
            (1, 1)    // Diagonal inferior derecha
            };

            // Buscar en cada posición de la matriz
            for (int i = 0; i < MATRIX_SIZE; i++)
            {
                for (int j = 0; j < MATRIX_SIZE; j++)
                {
                    // Probar cada dirección desde la posición actual
                    foreach (var (dx, dy) in direcciones)
                    {
                        if (BuscarPalabraEnDireccion(matriz, palabra, i, j, dx, dy))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool BuscarPalabraEnDireccion(string[,] matriz, string palabra, int fila, int columna, int dx, int dy)
        {
            // Verificar si la palabra cabe en la dirección especificada
            if (!PalabraCabeEnDireccion(fila, columna, dx, dy, palabra.Length))
            {
                return false;
            }

            // Comparar cada letra de la palabra
            for (int k = 0; k < palabra.Length; k++)
            {
                if (matriz[fila + k * dx, columna + k * dy] != palabra[k].ToString())
                {
                    return false;
                }
            }
            return true;
        }

        private bool PalabraCabeEnDireccion(int fila, int columna, int dx, int dy, int longitud)
        {
            int filaFinal = fila + (longitud - 1) * dx;
            int columnaFinal = columna + (longitud - 1) * dy;

            return filaFinal >= 0 && filaFinal < MATRIX_SIZE &&
                   columnaFinal >= 0 && columnaFinal < MATRIX_SIZE;
        }
    }

}
