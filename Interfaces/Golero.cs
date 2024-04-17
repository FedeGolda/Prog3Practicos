using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Golero : Futbolista, IGolero
    {
        public Golero(int idJugador, string nombreJugador, string posicion, int edad, string equipo)
       : base(idJugador, nombreJugador, posicion, edad, equipo)
        {
        }

        public void DespejarConLosPunios()
        {
            Console.WriteLine($"Soy {nombreJugador} y despejo el balón con los puños.");
        }

        public void LanzarRapido()
        {
            Console.WriteLine($"Soy {nombreJugador} y lanzo rapido el balon.");
        }

        public void AtajarPenal()
        {
            Console.WriteLine($"Soy {nombreJugador} y estoy atajando un penal");
        }
    }
}
