using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    internal class Sucursal
    {
        protected int id;
        protected string ciudad;
        protected int poblacion;

        public Sucursal(int id, string ciudad, int poblacion)
        {
            this.Id = id;
            this.Ciudad = ciudad;
            this.Poblacion = poblacion;
        }

        public int Id { get => id; set => id = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public int Poblacion { get => poblacion; set => poblacion = value; }

        
    }
}
