using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    internal abstract class Figura
    {
        protected int x;
        protected int y;

        public Figura()
        {

        }
        public Figura(int x, int y)
        {
            this.x = x;
            this.x = y;
        }

        public abstract double calcularArea(); // Metodo abstracto 


    }
}
