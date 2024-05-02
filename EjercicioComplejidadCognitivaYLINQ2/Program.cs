using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioComplejidadCognitivaYLINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> valores = new List<int>() { 3, 6, 9, 7, 4, 1, 2, 5, 8 };

            var valoresOrdenados = valores.OrderByDescending(x => x).ToList();
            var valorMaximo = valoresOrdenados.First();

            for (var indice = 0; indice < valores.Count - 1; indice++) // +1
            {
                if (valores[indice] > valores[indice + 1]) // 1 + 1
                {
                    var valorTemporal = valores[indice];
                    valores[indice] = valores[indice + 1];
                    valores[indice + 1] = valorTemporal;
                    indice = -1;
                }
            }

            Console.WriteLine("Valores ordenados manualmente:");
            foreach (var valorOrdenado in valores) // +1
            {
                Console.WriteLine(valorOrdenado);
            }

            Console.WriteLine("\nValores ordenados con LINQ:");
            foreach (var valorOrdenadoLinq in valoresOrdenados) // +1
            {
                Console.WriteLine(valorOrdenadoLinq);
            }

            var mayor = 0;
            foreach (var valor in valores) // +1
            {
                if (valor > mayor) // +1
                {
                    mayor = valor;
                }
            }

            Console.WriteLine("\nEl valor más grande es (sin LINQ): " + mayor);
            Console.WriteLine("El valor más grande es (con LINQ): " + valorMaximo);
        }
    }
}
