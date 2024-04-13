namespace Practico2Ej6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // i. Calcular la complejidad cognitiva del bloque.

            Console.WriteLine("Ingrese una letra minùscula (desde a hasta f) para saber cual es la siguiente letra del abecedario!!");
            string letra = Console.ReadLine();

            if (letra == "a") // +1
            {
                Console.WriteLine("La siguiente letra del abecedario es B !!");
            }
            if (letra == "b")  // +1
            {
                Console.WriteLine("La siguiente letra del abecedario es C !!");
            }
            if (letra == "c") // +1
            {
                Console.WriteLine("La siguiente letra del abecedario es D !!");
            }
            if (letra == "d") // +1
            {
                Console.WriteLine("La siguiente letra del abecedario es E !!");
            }
            if (letra == "e") // +1
            {
                Console.WriteLine("La siguiente letra del abecedario es F !!");
            }
            if (letra == "f") // +1
            {

                Console.WriteLine("La siguiente letra del abecedario es G !!");
            }

            // Total complejidad cognitiva = +6


            // ii.Disminuir la complejidad cognitiva del método sin usar LinQ.

            switch (letra) // +1
            {
                case "a":
                    Console.WriteLine("La siguiente letra del abecedario es B !!");
                    break;

                case "b":
                    Console.WriteLine("La siguiente letra del abecedario es C !!");
                    break;

                case "c":
                    Console.WriteLine("La siguiente letra del abecedario es D !!");
                    break;

                case "d":
                    Console.WriteLine("La siguiente letra del abecedario es E !!");
                    break;

                case "e":
                    Console.WriteLine("La siguiente letra del abecedario es F !!");
                    break;

                case "f":
                    Console.WriteLine("La siguiente letra del abecedario es G !!");
                    break;

                default:
                    Console.WriteLine("INCORRECTO: Ingrese una letra entre a y f.");
                    break;
            }

            // Total complejidad cognitiva = +1





        }
    }
}
