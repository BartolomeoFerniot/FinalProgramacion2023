using FinalProgramacion2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgramacion2023.Datos
{
    public static class ManejadorArchivoSecuencial
    {
        private static string archivo = "Cuadrilateros.txt";
        public static void GuardarEnArchivoSecuencial(List<Cuadrilatero> lista)
        {
            using (var escritor = new StreamWriter(archivo))
            {
                foreach (var cuadrilatero in lista)
                {
                    string linea=ConstruirLinea(cuadrilatero);
                    escritor.WriteLine(linea);
                }
            }
        }

        public static List<Cuadrilatero> LeerArchivoSecuencial()
        {
            List<Cuadrilatero>lista= new List<Cuadrilatero>();
            using (var lector = new StreamReader(archivo))
            {
                while (!lector.EndOfStream)
                {
                    string linea = lector.ReadLine();
                    Cuadrilatero cuad = ConstruirCuadrilatero(linea);
                    lista.Add(cuad);
                }

            }
            return lista;
        }

        private static Cuadrilatero ConstruirCuadrilatero(string linea)
        {
           var campos = linea.Split('|');
            Cuadrilatero cuadrilatero = new Cuadrilatero()
            {
                ladoA = double.Parse(campos[0]),
                ladoB = double.Parse(campos[1]),
                colorRelleno = campos[2],
                formatoBorde = campos[3],
            };
           return cuadrilatero;
        }

        private static string ConstruirLinea(Cuadrilatero cuadrilatero)
        {
            return $"{cuadrilatero.ladoA}|{cuadrilatero.ladoB}|{cuadrilatero.colorRelleno}|{cuadrilatero.formatoBorde}";
        }
    }
}
