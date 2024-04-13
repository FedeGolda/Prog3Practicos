namespace Practico2Ej5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> valores = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            int sumaTotalValoresParesMayoresAOcho = 0;
            int sumaTotalValoresParesMenoresAOcho = 0;

            foreach(var valor in valores) // +1
            {
                if(valor % 2 == 0) // +2
                {
                    if(valor > 8) // +3
                    {
                        sumaTotalValoresParesMayoresAOcho += valor;
                    }
                }
                else // +1
                {
                    sumaTotalValoresParesMenoresAOcho += valor;
                }
            }

            Console.WriteLine($"La suma total de los valores pares mayores a ocho es: {sumaTotalValoresParesMayoresAOcho}");
            Console.WriteLine($"La suma total de los valores pares menores a ocho es: {sumaTotalValoresParesMenoresAOcho}");

            // i.Disminuir la complejidad cognitiva del método sin utilizar LinQ.

            foreach (var valor in valores)
            {
                if (valor % 2 == 0)
                {
                    if (valor > 8)
                    {
                        sumaTotalValoresParesMayoresAOcho += valor;
                    }
                    else if (valor <= 8)
                    {
                        sumaTotalValoresParesMenoresAOcho += valor;
                    }
                }
            }

            Console.WriteLine($"La suma total de los valores pares mayores a ocho es: {sumaTotalValoresParesMayoresAOcho}");
            Console.WriteLine($"La suma total de los valores pares menores o iguales a ocho es: {sumaTotalValoresParesMenoresAOcho}");




            // ii. Crear una función que utilice LinQ y muestre en pantalla el mismo resultado.

            int sumaTotalValoresParesMayoresAOcho2 = valores.Where(v => v % 2 == 0 && v > 8).Sum();

            int sumaTotalValoresParesMenoresAOcho2 = valores.Where(v => v % 2 == 0 && v <= 8).Sum();

            Console.WriteLine($"La suma total de los valores pares mayores a ocho es: {sumaTotalValoresParesMayoresAOcho2}");
            Console.WriteLine($"La suma total de los valores pares menores o iguales a ocho es: {sumaTotalValoresParesMenoresAOcho2}");

        }
    }
}
