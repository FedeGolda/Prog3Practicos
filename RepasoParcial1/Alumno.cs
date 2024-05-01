using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepasoParcial1
{
    internal class Alumno
    {
        public string Nombre { set; get; }
        public int Edad { set; get; }
        public int Nota { set; get; }

        public Alumno(string nombre, int edad, int nota)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Nota = nota;
        }
    }
}
