using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Cuadrado : Figura, Dibujable
    {
        private int lado;

        public Cuadrado()
        {

        }
        public Cuadrado(int x, int y, int lado) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.lado = lado;
        }

        public override double calcularArea()
        {
            double resultado = lado * lado;
            return resultado;
        }

        public void dibujar()
        {
            Console.WriteLine("Dibujo un cuadrado");
        }

    }
}
