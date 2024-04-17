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

                for (int i = 2; i < n; i++) // +1
                {
                    if (n % i == 0) // +1
                    {
                        es = false;
                    }
                }
                return es;
            } // total: +2

            /* Ejercicio 2 
             Escribir una función que calcule la suma de los dígitos de un número entero. 
             La función debe tomar un entero como entrada y devolver la suma de los dígitos. */

            int suma = SumaDigitos(num);
            Console.WriteLine($"\nLa suma de los dígitos de {num} es: {suma}");

            int SumaDigitos(int num)
            {
                int suma = 0;
                num = Math.Abs(num); // Asegura que el número sea positivo // +1

                while (num > 0) // +1
                {
                    suma += num % 10;
                    num /= 10; 
                }
                return suma;
            } // total +2

            /* Ejercicio 3 
             Escribir una función que calcule el factorial de un número entero dado. 
             La función debe tomar un entero como entrada y devolver su factorial. */

            long factorial = Factorial(num);
            Console.WriteLine($"\nEl factorial de {num} es {factorial}");

            static long Factorial(int n)
            {
                if (n < 0) // +1
                {
                    throw new ArgumentException("\nEl factorial no está definido para números negativos");
                }

                long factorial = 1;
                for (int i = 1; i <= n; i++) // +1
                {
                    factorial *= i;
                }
                return factorial;
            } // total +2

            /* Ejercicio 4
                Escribir una función que devuelva el número de palabras en una cadena dada. La función debe tomar una cadena como entrada y devolver un entero que indique el número de palabras.
             */

            Console.WriteLine("\nIngrese una palabra: ");
            string palabra = Console.ReadLine();
            int contar = ContarPalabras(palabra);
            Console.WriteLine($"\nCantidad de palabras: {contar}");


            int ContarPalabras(string cadena)
            {
                if (string.IsNullOrEmpty(cadena)) // +1
                    return 0;

                string[] palabras = cadena.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                return palabras.Length;
            } // total +1


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
                for (int i = 0; i < numeros.Length - 1; i++) // +1
                {
                    int minimoIndice = i;
                    for (int j = i + 1; j < numeros.Length; j++) // +1
                    {
                        if (numeros[j] < numeros[minimoIndice]) // +1
                        {
                            minimoIndice = j;
                        }
                    }
                    if (minimoIndice != i) // +1
                    {
                        int temp = numeros[i];
                        numeros[i] = numeros[minimoIndice];
                        numeros[minimoIndice] = temp;
                    }
                }
            } // total +4



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
                int filas1 = matriz1.GetLength(0); // +1
                int columnas1 = matriz1.GetLength(1); // +1
                int filas2 = matriz2.GetLength(0); // +1
                int columnas2 = matriz2.GetLength(1); // +1
                int[,] resultado = new int[filas1, columnas2];

                for (int i = 0; i < filas1; i++) // +1
                {
                    for (int j = 0; j < columnas2; j++) // +1
                    {
                        resultado[i, j] = 0;
                        for (int k = 0; k < columnas1; k++) // +1
                        {
                            resultado[i, j] += matriz1[i, k] * matriz2[k, j];
                        }
                    }
                }
                return resultado;
            } // total +7


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
                foreach (char c in cadena) // +1
                {
                    if (char.IsLetter(c)) // +1
                    {
                        filtrada += c;
                    }
                }

                // Comprobamos si la cadena filtrada es un palíndromo
                int j = filtrada.Length - 1;
                for (int i = 0; i < j; i++, j--) // +1
                {
                    if (filtrada[i] != filtrada[j]) // +1
                    {
                        return false;
                    }
                }
                return true;
            } // total +4

            /* Ejercicio 8
                Escribir una función que determine si una cadena es un palíndromo. 
                La función debe tomar una cadena como entrada y devolver verdadero si la cadena es un palíndromo (es decir, se lee igual de adelante hacia atrás que de atrás hacia adelante) y falso en caso contrario.
            */

            bool EsPalindromo2(string cadena)
            {
                int izquierda = 0;
                int derecha = cadena.Length - 1;
                while (izquierda < derecha) // +1
                {
                    if (cadena[izquierda] != cadena[derecha]) // +1
                    {
                        return false;
                    }
                    izquierda++;
                    derecha--;
                }
                return true;
            } // total +2

            /*
            Ejercicio 9
                Escribir una función que calcule el número de formas en que se pueden colocar k objetos de n posibles en orden, sin repetición. 
                La función debe tomar dos enteros como entrada y devolver un entero que indique el número de formas posibles.
            */


            int Permutaciones(int n, int k)
            {
                if (n < k) // +1
                {
                    return 0; 
                }
                int resultado = 1;
                for (int i = n; i > n - k; i--) // +1
                {
                    resultado *= i;
                }
                return resultado;
            } // total +2


            /* Ejercicio 10
                Escribir una función que determine si una cadena dada es un anagrama o no. 
                La función debe tomar dos cadenas como entrada y devolver un valor booleano que indique si son anagramas o no.
            */


            string str1 = "amor";
            string str2 = "roma";

            bool resultado2 = EsAnagrama(str1, str2);
            Console.WriteLine($"\n'{str1}' y '{str2}' : {resultado2}");

            bool EsAnagrama(string str1, string str2)
            {
                // Eliminar espacios y convertir a minúsculas para hacer la comparación insensible a mayúsculas y espacios
                str1 = new string(str1.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
                str2 = new string(str2.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();

                // Si las longitudes son diferentes, no pueden ser anagramas
                if (str1.Length != str2.Length) // +1
                    return false;

                var array1 = str1.ToCharArray();
                var array2 = str2.ToCharArray();

                Array.Sort(array1);
                Array.Sort(array2);

                return array1.SequenceEqual(array2);
            } // total +1 


            /* Ejercicio 11
                Escribir una función que calcule el máximo común divisor de dos enteros utilizando el algoritmo de Euclides. 
                La función debe tomar dos enteros como entrada y devolver un entero que indique el máximo común divisor.
            */


            int num1 = 48;
            int num2 = 18;
            int mcd = CalcularMCD(num1, num2);
            Console.WriteLine($"\nEl MCD de {num1} y {num2} es: {mcd}");

            int CalcularMCD(int a, int b)
            {
                // Asegurarse de que ambos números no sean negativos
                a = Math.Abs(a);
                b = Math.Abs(b);

                // Implementación del algoritmo de Euclides
                while (b != 0) // +3 porque se cuenta while y los dos maths
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            } // total +3


            /* Ejercicio 12
                Escribir una función que calcule el enésimo número de Fibonacci. 
                La función debe tomar un entero como entrada y devolver el enésimo número de Fibonacci.
            */

            int Fibonacci(int n)
            {
                if (n <= 1) // +1
                {
                    return n;
                }

                int a = 0;
                int b = 1;

                for (int i = 2; i <= n; i++)// +1
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
                return b;
            } // total +2


            /* Ejercicio 13
                Escribir una función que calcule la n-ésima serie de Fibonacci. 
                La función debe tomar un entero n como entrada y devolver un entero que indique el valor de la n-ésima serie de Fibonacci.
            */

            int Fibonacci2(int n)
            {
                if (n == 0) // +1
                {
                    return n;
                }
                else if (n == 1) // +1
                {
                    return 1;
                }
                else
                {
                    return Fibonacci(n - 1) + Fibonacci(n - 2); // +2
                }

            } // total +4


            /* Ejercicio 14
                 Escribir una función que calcule la suma de los elementos en un arreglo de enteros.
                 La función debe tomar un arreglo de enteros como entrada y devolver un entero que indique la suma de todos los elementos.
            */

            int SumaArreglo(int[] a)
            {
                int resultado = 0;

                foreach (int elemento in a) // +1
                {
                    resultado += elemento;
                }

                return resultado;
            } // +1


            /*  Ejercicio 15
                Escribir una función que calcule el máximo común divisor de dos números enteros dados. 
                La función debe tomar dos enteros como entrada y devolver su máximo común divisor.
            */

            int num3 = 36;
            int num4 = 60;
            Console.WriteLine($"El MCD de {num3} y {num4} es: {MCD(num3, num4)}");


            int MCD(int a, int b)
            {
                if (a == 0) return b; // +1
                if (b == 0) return a; // +1

                while (b != 0) // +1
                {
                    int t = b;
                    b = a % b;
                    a = t;
                }
                return Math.Abs(a); // +1
            } // total +4

            /* Ejercicio 16
                Escribir una función que calcule la suma de los elementos en una matriz de enteros.
                La función debe tomar una matriz de enteros como entrada y devolver un entero que indique la suma total de los elementos en la matriz.
            */



            int[,] matriz = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            Console.WriteLine($"La suma de los elementos de la matriz es: {SumaMatriz(matriz)}");


            int SumaMatriz(int[,] matriz)
            {
                int suma = 0;
                // Iterar sobre cada elemento de la matriz
                for (int i = 0; i < matriz.GetLength(0); i++) // +1
                {
                    for (int j = 0; j < matriz.GetLength(1); j++) // +1
                    {
                        suma += matriz[i, j];
                    }
                }
                return suma;
            } // total +2

            /* Ejercicio 17
                Escribir una función que encuentre el número más grande en un arreglo de enteros. 
                La función debe tomar un arreglo de enteros como entrada y devolver un entero que indique el valor del número más grande.
            */


            int[] arreglo = new int[] { 5, 3, 8, 6, 2, 7, 10, 1 };
            Console.WriteLine($"El número más grande en el arreglo es: {EncontrarMaximo(arreglo)}");


            static int EncontrarMaximo(int[] arreglo)
            {
                int maximo = arreglo[0];

                for (int i = 1; i < arreglo.Length; i++) // +1
                {
                    if (arreglo[i] > maximo) // +1 
                    {
                        maximo = arreglo[i]; 
                    }
                }

                return maximo;
            } // total +2


            /* Ejercicio 18
                Escribir una función que calcule la distancia euclidiana entre dos puntos en un plano cartesiano. 
                La función debe tomar las coordenadas (x,y) de los dos puntos como entrada y devolver un número que indique la distancia entre ellos.
            */

            double distancia = CalcularDistanciaEuclidiana(3, 4, 7, 1);
            Console.WriteLine($"La distancia entre los puntos es: {distancia}");

            static double CalcularDistanciaEuclidiana(double x1, double y1, double x2, double y2)
            {
                double deltaX = x2 - x1;
                double deltaY = y2 - y1;

                double distancia = Math.Sqrt(deltaX * deltaX + deltaY * deltaY); // +1

                return distancia;
            } // total +1



        }
    }
}
