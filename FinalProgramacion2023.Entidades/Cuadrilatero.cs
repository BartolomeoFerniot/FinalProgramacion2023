using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProgramacion2023.Entidades
{
    public class Cuadrilatero
    {
        public double ladoA { get; set; }
        public double ladoB { get; set; }
        public string colorRelleno { get; set; }
        public string formatoBorde { get; set; }


        public Cuadrilatero()
        {

        }

        public bool ValidarCuadrilatero()
        {
            if (ladoA>0 && ladoB>0)
            {
                return true;
            }
            else 
            { 
                return false;
            }
        }

        public string TipoDeCuadrilatero()
        {
            if (ladoA == ladoB)
            {
                return "Cuadrado";
            }
            else
            {
                return "Rectangulo";
            }
        }

        public double GetPerimetro()
        {
            return 2 * ladoA + 2 * ladoB;
        }

        public double GetArea()
        {
            return ladoA * ladoB;
        }


    }
}
