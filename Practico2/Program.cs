namespace Practico2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>
           {
               new Persona {Nombre = "Pepe", Edad = 35, Ciudad = "Montevideo"},
               new Persona { Nombre = "Jose", Edad = 32, Ciudad = "Buenos Aires" },
               new Persona { Nombre = "Agustina", Edad = 45, Ciudad = "Madrid" },
               new Persona { Nombre = "Jose", Edad = 14, Ciudad = "San Juan" },
               new Persona { Nombre = "Pedro", Edad = 58, Ciudad = "Bogota" }
           };

            // Ej 1 i Mostrar el nombre de todas las personas que tengan una edad mayor a 30 y vivan en Bogotá.
            foreach (var persona in personas.Where(p => p.Edad > 30 && p.Ciudad == "Bogota"))
            {
                Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}, Ciudad: {persona.Ciudad}");
            }

            // ii. Mostrar el nombre de todas las personas que tengan una edad entre 25 y 35 años, ordenadas por edad de forma ascendente.
            foreach (var persona in personas.Where(p => p.Edad >= 25 && p.Edad <= 35).OrderBy(p => p.Edad))
            {
                Console.WriteLine($"Nombre: {persona.Nombre}, Edad: {persona.Edad}");
            }


        }

        internal class Persona
        {
            public int Edad { get; set; }
            public string Nombre { get; set; }
            public string Ciudad { get; set;}
        }
    }
}
