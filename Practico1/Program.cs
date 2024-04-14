using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practico1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Ejercicio 1 
                Escribir una función que determine si un número entero dado es primo o no. 
                La función debe tomar un entero como entrada y devolver un valor booleano que indique si el número es primo o no. */

            Console.WriteLine("Escribe un numero: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine(EsPrimo(num));


            bool EsPrimo(int n)
            {
                bool es = true;

                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        es = false;
                    }
                }
                return es;
            }

            /* Ejercicio 2 
             Escribir una función que calcule la suma de los dígitos de un número entero. 
             La función debe tomar un entero como entrada y devolver la suma de los dígitos. */

            int suma = SumaDigitos(num);
            Console.WriteLine($"\nLa suma de los dígitos de {num} es: {suma}");

            int SumaDigitos(int num)
            {
                int suma = 0;
                num = Math.Abs(num); // Asegura que el número sea positivo

                while (num > 0)
                {
                    suma += num % 10; // Obtiene el último dígito y lo suma
                    num /= 10; // Remueve el último dígito
                }
                return suma;
            }

            /* Ejercicio 3 
             Escribir una función que calcule el factorial de un número entero dado. 
             La función debe tomar un entero como entrada y devolver su factorial. */

            long factorial = Factorial(num);
            Console.WriteLine($"\nEl factorial de {num} es {factorial}");

            static long Factorial(int n)
            {
                if (n < 0)
                {
                    throw new ArgumentException("\nEl factorial no está definido para números negativos");
                }

                long factorial = 1;
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;
                }
                return factorial;
            }

            /* Ejercicio 4
                Escribir una función que devuelva el número de palabras en una cadena dada. La función debe tomar una cadena como entrada y devolver un entero que indique el número de palabras.
             */

            Console.WriteLine("\nIngrese una palabra: ");
            string palabra = Console.ReadLine();
            int contar = ContarPalabras(palabra);
            Console.WriteLine($"\nCantidad de palabras: {contar}");


            int ContarPalabras(string cadena)
            {
                if (string.IsNullOrEmpty(cadena))
                    return 0;

                string[] palabras = cadena.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                return palabras.Length;
            }




        }
    }
}
