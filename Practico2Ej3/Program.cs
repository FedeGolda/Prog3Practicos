namespace Practico2Ej3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i. Calcular la complejidad cognitiva del bloque.

            List<int> valores = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int indice = 0; indice < valores.Count - 1; indice++) // +1 por el bucle for
            {
                if (valores[indice] > valores[indice + 1]) // +2 (una por el if y otra por la complejidad añadida de reiniciar el índice)
                {
                    var valorTemporal = valores[indice];

                    valores[indice] = valores[indice + 1];
                    valores[indice + 1] = valorTemporal;

                    indice = -1;
                }

            }
                foreach (int valorOrdenado in valores) // +1 por el bucle foreach
                {
                    Console.WriteLine(valorOrdenado);
                }


            // ii. Crear una función que utilice LinQ y muestre en pantalla el mismo resultado.

            var listaOrdenada = valores.OrderBy(x => x).ToList();

            foreach (int valorOrdenado in listaOrdenada)
            {
                Console.WriteLine(valorOrdenado);
            }



        }
    }
}
