using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticandoConLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> listaEnteros = new List<int> { 12, 24, 25, 33, 45, 50, 55, 60, 70 };



            // Suma de todos los elementos
            var suma = listaEnteros.Sum();
            Console.WriteLine("La suma de todos los elementos es: " + suma);

            // Obtener el promedio de todos los números mayores a 50
            var promedio = listaEnteros.Where(x => x > 50).Average();
            Console.WriteLine("El promedio de todos los números mayores a 50 es: " + promedio);

            // Contar la cantidad de números pares e impares
            var contarParesEImpares = listaEnteros
                .GroupBy(x => x % 2 == 0 ? "Pares" : "Impares")
                .ToDictionary(g => g.Key, g => g.Count());

            // Mostrando los resultados de pares e impares
            foreach (var grupo in contarParesEImpares)
            {
                Console.WriteLine($"Cantidad de {grupo.Key}: {grupo.Value}");
            }
        }
    }
}
