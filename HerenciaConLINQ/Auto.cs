using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaConLINQ
{
    internal class Auto : Vehiculo
    {
        private int CantPasajeros { get; set; }

        public Auto(int id, string marca, string modelo, int ruedas, string anio, string color, int cantPasajeros)
            : base(id, marca, modelo, ruedas, anio, color)
        {
            CantPasajeros = cantPasajeros;
        }
    }
}
