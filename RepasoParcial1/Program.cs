using System;
using System.Collections.Generic;

namespace RepasoParcial1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> alumnos = new List<Alumno>()
            {
                new Alumno("Eva", 20, 6),
                new Alumno("Ana", 18, 7),
                new Alumno("Rosa", 22, 5),
                new Alumno("Ricardo", 30, 9),
                new Alumno("Felipe", 45, 2),
                new Alumno("Pepe", 19, 3),
                new Alumno("Laia", 26, 10),
                new Alumno("Stephanie", 33, 6),
                new Alumno("Agustin", 50, 7),
                new Alumno("Mauricio", 31, 12)
            };

           // var alumnosExonerados = new List<Alumno>();

            // Usando LINQ para filtrar y ordenar la lista de alumnos
            var alumnosExonerados = alumnos
                .Where(alumno => alumno.Nota > 6 && alumno.Nombre.Length > 4)
                .OrderBy(alumno => alumno.Edad)
                .ToList();


            foreach (var alumno in alumnos)
            {
                if (alumno.Nota > 6 && alumno.Nombre.Length > 4)
                {
                    alumnosExonerados.Add(alumno);
                }
            }

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Ordenamiento burbuja simplificado
            bool huboCambio;
            do
            {
                huboCambio = false;
                for (int i = 0; i < alumnosExonerados.Count - 1; i++)
                {
                    if (alumnosExonerados[i].Edad > alumnosExonerados[i + 1].Edad)
                    {
                        var temp = alumnosExonerados[i];
                        alumnosExonerados[i] = alumnosExonerados[i + 1];
                        alumnosExonerados[i + 1] = temp;
                        huboCambio = true;
                    }
                }
            } while (huboCambio);

            foreach (var alumno in alumnosExonerados)
            {
                Console.WriteLine($"Nombre: {alumno.Nombre} - Edad: {alumno.Edad} - Nota: {alumno.Nota}");
            }


        }
    }
}