using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaConLINQ
{
    internal abstract class Vehiculo
    {
        protected int Id { get; set; }
        protected string Marca { get; set; }
        protected string Modelo { get; set; }
        protected int Ruedas { get; set; }
        protected string Color { get; set; }
        protected string Anio { get; set; }

        public Vehiculo() { }

        public Vehiculo(int id, string marca, string modelo, int ruedas, string color, string anio)
        {
            this.Id = id;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ruedas = ruedas;
            this.Color = color;
            this.Anio = anio;
        }



    }
}
