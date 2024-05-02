using System.Drawing;

namespace EjercicioComplejidadCognitivaYLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var valores = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // var sumaPar = 0;
            // var sumaImpar = 0;
            // var suma = 0;

            var sumaPar = valores.Where(v => v % 2 == 0).Sum();
            var sumaImpar = valores.Where(v => v % 2 != 0).Sum();
            var sumaTotal = valores.Sum();
            var promedio = valores.Average();

            /*
            foreach (var valor in valores) +1
            {
                if (valor % 2 == 0) 1 + 1
                {
                    sumaPar += valor;
                }

                if (valor % 2 != 0) +1
                {
                    sumaImpar += valor;
                }
                suma += valor;
            }

            var promedio = 0;
            if (suma > 0) +1
            {
                promedio = suma / valores.Count;
            } 
            Total Complejidad: 5
            */ 

            Console.WriteLine(promedio);
            Console.WriteLine(sumaPar);
            Console.WriteLine(sumaImpar);
        }
    }
}
