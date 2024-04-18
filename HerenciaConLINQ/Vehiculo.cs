using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaConLINQ
{
    internal abstract class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ruedas { get; set; }
        public string Color { get; set; }
        public string Anio { get; set; }

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



        // 3- realizar un metodo que retorne todo los vehiculos segun un campo tipo que recibe por parametro(moto, auto o camion)
        public static void MostrarVehiculos(List<Vehiculo> vehiculos)
        {
            foreach (var vehiculo in vehiculos)
            {
                Console.WriteLine($"Tipo: {vehiculo.Marca}, Modelo: {vehiculo.Modelo}");
            }
        }

        // 4- realizar un metodo que muestre en pantalla cuantos vehiculos hay en total, cuantos son autos, cuantos son motos y cuantos son camiones.
        public static void totalVehiculos(List<Vehiculo> vehiculos)
        {
            int totalAutos = 0;
            int totalMotos = 0;
            int totalCamiones = 0;

            foreach (var vehiculo in vehiculos)
            {
                if (vehiculo is Auto)
                {
                    totalAutos++;
                }
                else if (vehiculo is Moto)
                {
                    totalMotos++;
                }
                else if (vehiculo is Camion)
                {
                    totalCamiones++;
                }
            }

            Console.WriteLine($"\nTotal de Vehículos: {vehiculos.Count}");
            Console.WriteLine($"Total de Autos: {totalAutos}");
            Console.WriteLine($"Total de Motos: {totalMotos}");
            Console.WriteLine($"Total de Camiones: {totalCamiones}");
        }



    }
}
