namespace Practico2Ej4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i. Crear una función que utilice LinQ y muestre en pantalla el mismo resultado.
            // a)

            List<int> valores = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int sumaTotal = 0;

            foreach (var valor in valores) 
            {
                sumaTotal += valor;
            }
            Console.WriteLine($"La suma total es: { sumaTotal}");


            var total = valores.Sum(); // Funcion con LinQ
            Console.WriteLine($"La suma total es: {total}");


            // b)

            int sumaTotalValoresPares = 0;

            foreach (var valor in valores)
            {
                if(valor % 2 == 0)
                {
                    sumaTotalValoresPares += valor;
                }
            }
            Console.WriteLine($"La suma total de los valores pares es: {sumaTotalValoresPares}");

            // Usando LINQ para calcular la suma de los valores pares
            var totalPares = valores.Where(valor => valor % 2 == 0).Sum();
            Console.WriteLine($"La suma total de los valores pares es: {totalPares}");

        }
    }
}
