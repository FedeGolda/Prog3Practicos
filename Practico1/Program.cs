using System.Net;
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

            Console.WriteLine("Es Primo? " + EsPrimo(num));


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


            /* Ejercicio 5
                Escribir una función que ordene un arreglo de enteros utilizando el algoritmo de selección. La función debe tomar un arreglo de enteros como entrada y ordenarlo en orden ascendente.
            */

            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.WriteLine("\nArreglo SIN ordenar:");
            foreach (int i in arr)
                Console.Write(i + " ");

            OrdenarSeleccion(arr);
            Console.WriteLine("\nArreglo ordenado:");
            foreach (int i in arr)
                Console.Write(i + " ");


            void OrdenarSeleccion(int[] numeros)
            {
                for (int i = 0; i < numeros.Length - 1; i++)
                {
                    int minimoIndice = i;
                    for (int j = i + 1; j < numeros.Length; j++)
                    {
                        if (numeros[j] < numeros[minimoIndice])
                        {
                            minimoIndice = j;
                        }
                    }
                    if (minimoIndice != i)
                    {
                        int temp = numeros[i];
                        numeros[i] = numeros[minimoIndice];
                        numeros[minimoIndice] = temp;
                    }
                }
            }



            /* Ejercicio 6
                Escribir una función que calcule el producto de dos matrices. 
                La función debe tomar dos matrices como entrada y devolver una matriz que indique el resultado de la multiplicación.
            */



            // Definimos dos matrices
            int[,] matriz1 = new int[,]
            {
            {1, 2, 3},
            {4, 5, 6}
            };

            int[,] matriz2 = new int[,]
            {
            {7, 8},
            {9, 10},
            {11, 12}
            };


            // Mostrar matriz1
            Console.WriteLine("\n\nMatriz 1:");
            for (int i = 0; i < matriz1.GetLength(0); i++)
            {
                for (int j = 0; j < matriz1.GetLength(1); j++)
                {
                    Console.Write(matriz1[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Mostrar matriz2
            Console.WriteLine("\nMatriz 2:");
            for (int i = 0; i < matriz2.GetLength(0); i++)
            {
                for (int j = 0; j < matriz2.GetLength(1); j++)
                {
                    Console.Write(matriz2[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Multiplicamos las matrices
            int[,] resultado = MultiplicarMatrices(matriz1, matriz2);

            // Imprimimos el resultado
            Console.WriteLine("\nResultado de la multiplicación de matrices:");
            for (int i = 0; i < resultado.GetLength(0); i++)
            {
                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    Console.Write(resultado[i, j] + " ");
                }
                Console.WriteLine();
            }



            int[,] MultiplicarMatrices(int[,] matriz1, int[,] matriz2)
            {
                int filas1 = matriz1.GetLength(0);
                int columnas1 = matriz1.GetLength(1);
                int filas2 = matriz2.GetLength(0);
                int columnas2 = matriz2.GetLength(1);

                if (columnas1 != filas2)
                {
                    throw new ArgumentException("Las matrices no se pueden multiplicar debido a dimensiones incompatibles.");
                }

                int[,] resultado = new int[filas1, columnas2];

                for (int i = 0; i < filas1; i++)
                {
                    for (int j = 0; j < columnas2; j++)
                    {
                        resultado[i, j] = 0;
                        for (int k = 0; k < columnas1; k++)
                        {
                            resultado[i, j] += matriz1[i, k] * matriz2[k, j];
                        }
                    }
                }
                return resultado;
            }


            /* Ejercicio 7
                Escribir una función que determine si una cadena dada es un palíndromo o no. 
                La función debe tomar una cadena como entrada y devolver un valor booleano que indique si la cadena es un palíndromo o no
            */

            Console.WriteLine("\nEs 'anana' un palíndromo? " + EsPalindromo("anana").ToString());
            Console.WriteLine("Es 'Ana' un palíndromo? " + EsPalindromo("Ana").ToString());
            Console.WriteLine("Es 'Hola' un palíndromo? " + EsPalindromo("Hola").ToString());
            Console.WriteLine("\nEs 'anana' un palíndromo? " + EsPalindromo2("anana").ToString());
            Console.WriteLine("Es 'Ana' un palíndromo? " + EsPalindromo2("Ana").ToString());
            Console.WriteLine("Es 'Hola' un palíndromo? " + EsPalindromo2("Hola").ToString());

            bool EsPalindromo(string cadena)
            {
                // Convertimos a minúsculas para ignorar diferencias de mayúsculas/minúsculas
                cadena = cadena.ToLower();

                // Eliminamos espacios y caracteres no alfabéticos
                string filtrada = "";
                foreach (char c in cadena)
                {
                    if (char.IsLetter(c))
                    {
                        filtrada += c;
                    }
                }

                // Comprobamos si la cadena filtrada es un palíndromo
                int j = filtrada.Length - 1;
                for (int i = 0; i < j; i++, j--)
                {
                    if (filtrada[i] != filtrada[j])
                    {
                        return false;
                    }
                }
                return true;
            }

            /* Ejercicio 8
                Escribir una función que determine si una cadena es un palíndromo. 
                La función debe tomar una cadena como entrada y devolver verdadero si la cadena es un palíndromo (es decir, se lee igual de adelante hacia atrás que de atrás hacia adelante) y falso en caso contrario.
            */

            bool EsPalindromo2(string cadena)
            {
                int izquierda = 0;
                int derecha = cadena.Length - 1;
                while (izquierda < derecha)
                {
                    if (cadena[izquierda] != cadena[derecha])
                    {
                        return false;
                    }
                    izquierda++;
                    derecha--;
                }
                return true;
            }

            /*
            Ejercicio 9
                Escribir una función que calcule el número de formas en que se pueden colocar k objetos de n posibles en orden, sin repetición. 
                La función debe tomar dos enteros como entrada y devolver un entero que indique el número de formas posibles.
            */


            int Permutaciones(int n, int k)
            {
                if (n < k)
                {
                    return 0; // No hay suficientes elementos para tomar k de ellos
                }
                int resultado = 1;
                for (int i = n; i > n - k; i--)
                {
                    resultado *= i;
                }
                return resultado;
            }



        }
    }
}
