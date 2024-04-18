using System.ComponentModel;

namespace HerenciaConLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 2- creen una lista de vehiculos
            List<Vehiculo> vehiculos = new List<Vehiculo>
            {
                new Auto(1, "Toyota", "Corolla", 4, "2020", "Rojo", 5),
                new Moto(2, "Harley", "Davidson", 2, "2021", 1200, "Negro"),
                new Camion(3, "Freightliner", "Cascadia", 6, "2019", "Blanco", 20),
                new Auto(4, "Honda", "Civic", 4, "2022", "Azul", 5),
                new Moto(5, "Yamaha", "YZF", 2, "2020", 999, "Verde")
            };


            Vehiculo.MostrarVehiculos(vehiculos);

            Vehiculo.totalVehiculos(vehiculos);

            // 5- crear un auto mas y 2 motos mas

            // Creación de un nuevo auto
            Auto nuevoAuto = new Auto(
                id: 6, // Asumiendo que continuamos la secuencia de ID
                marca: "Ford",
                modelo: "Mustang",
                ruedas: 4,
                anio: "2022",
                color: "Rojo",
                cantPasajeros: 4
            );

            // Creación de dos nuevas motos
            Moto nuevaMoto1 = new Moto(
                id: 7,
                marca: "Ducati",
                modelo: "Panigale",
                ruedas: 2,
                anio: "2023",
                cilindradas: 1100,
                color: "Blanco"
            );

            Moto nuevaMoto2 = new Moto(
                id: 8,
                marca: "BMW",
                modelo: "S1000RR",
                ruedas: 2,
                anio: "2022",
                cilindradas: 999,
                color: "Azul"
            );

            vehiculos.Add(nuevoAuto);
            vehiculos.Add(nuevaMoto1);
            vehiculos.Add(nuevaMoto2);


            // 6- llamar nuevamente al metodo del punto 4

            Vehiculo.totalVehiculos(vehiculos);


            // 7- Prueben si se puede hacer filtros where en la lista de vehiculos por el campo cilindradas para que ver funciona herencia y linq juntos

            var filtrarMotosPorCilindradas = vehiculos.OfType<Moto>()
                                                       .Where(m => m.Cilindradas > 1000)
                                                       .ToList();

            foreach (Moto moto in filtrarMotosPorCilindradas)
            {
                Console.WriteLine($"Marca: {moto.Marca}, Modelo: {moto.Modelo}, Cilindradas: {moto.Cilindradas}");
            }


        }
    }
}
