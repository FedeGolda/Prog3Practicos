using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaConLINQ
{
    internal class Camion : Vehiculo
    {
        private int Toneladas { get; set; }

        public Camion (int id, string marca, string modelo, int ruedas, string anio, string color, int toneladas) 
            : base(id, marca, modelo, ruedas, anio, color)
        {
            Toneladas = toneladas;
        }
    }
}
