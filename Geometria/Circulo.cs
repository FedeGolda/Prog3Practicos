using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal class Circulo : Figura, Girable, Dibujable
    {
        private int radio;

        public Circulo() 
        {
            
        }

        public Circulo(int x, int y, int radio) : base(x, y)
        {
            this.x = x;
            this.y = y;
            this.radio = radio;
        }

        public override double calcularArea()
        {
            double areaCirculo = Math.PI * (radio * radio);

            return areaCirculo;
        }

        public void dibujar()
        {
            Console.WriteLine("Dibujo un circulo");
        }

        public void girar()
        {
            Console.WriteLine("Giro un circulo");
        }



    }
}
