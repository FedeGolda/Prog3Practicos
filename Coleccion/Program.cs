namespace Coleccion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> valores = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var suma = valores.Sum(); // usando LINQ
            var valoresPares = valores.Where(valor => valor % 2 == 0).ToList(); // usando LINQ
            foreach(var par in valoresPares)
            {
                Console.WriteLine(par);
            }

            List<int> desordenada = new List<int> {3, 6, 2, 9, 7, 4, 1, 5, 8};

            
            
            int total = 0;

            foreach(int valor in valores) 
            {
                if(valor % 2 == 0)
                {
                    total += valor;
                }
            }
            Console.WriteLine(total);


            for (int i = 0; i < desordenada.Count - 1; i++) // 1 complejida
            {
                for (int j = 0; j < desordenada.Count - 1 - i; j++) // 1 + 1 complejidad
                {
                    if (desordenada[j] < desordenada[j + 1])
                    {
                        int temp = desordenada[j];
                        desordenada[j] = desordenada[j + 1];
                        desordenada[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Lista ordenada de mayor a menor:");
            foreach (int valorOrdenado in desordenada) // 1 complejidad
            {
                Console.WriteLine(valorOrdenado);
            }

            // total complejidad = 4


            for (int i = 0; i < desordenada.Count - 1; i++)
            {
                for (int j = 0; j < desordenada.Count - 1 - i; j++)
                {
                    if (desordenada[j] > desordenada[j + 1])
                    {
                        int temp = desordenada[j];
                        desordenada[j] = desordenada[j + 1];
                        desordenada[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Lista ordenada de menor a mayor:");
            foreach (int valorOrdenado in desordenada)
            {
                Console.WriteLine(valorOrdenado);
            }




        }
    }
}
