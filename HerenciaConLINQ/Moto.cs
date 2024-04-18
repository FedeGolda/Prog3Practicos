using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaConLINQ
{
    internal class Moto : Vehiculo
    {
        private int Cilindradas { get; set; }

        public Moto(int id, string marca, string modelo, int ruedas, string anio, int cilindradas, string color)
            : base(id, marca, modelo, ruedas, anio, color)
        {
            Cilindradas = cilindradas;
        }
    }
}
