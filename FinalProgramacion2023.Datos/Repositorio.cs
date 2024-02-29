using FinalProgramacion2023.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgramacion2023.Datos
{
    public class Repositorio
    {
        private List<Cuadrilatero> listaCuadrilateros;
        private bool hayCambios=false;
        public Repositorio()
        {
            listaCuadrilateros = new List<Cuadrilatero>();
            listaCuadrilateros=ManejadorArchivoSecuencial.LeerArchivoSecuencial();

        }

        public void Agregar(Cuadrilatero clista)
        {
            hayCambios = true;
            listaCuadrilateros.Add(clista);
        }

        public int GetCantidad()
        {
            return listaCuadrilateros.Count;
        }

        public List<Cuadrilatero> GetLista()
        {
            return listaCuadrilateros;
        }

        public void Borrar(Cuadrilatero cuad)
        {
            hayCambios=true;
            listaCuadrilateros.Remove(cuad);
        }

        public void Editar (Cuadrilatero cuad)
        {
            hayCambios = true;
        }
    }
}
