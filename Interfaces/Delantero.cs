using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Delantero : Futbolista, IDelantero
    {
        public Delantero(int id_jugador, string nombreJugador, string posicion, int edad, string equipo)
            : base(id_jugador, nombreJugador, posicion, edad, equipo)
        {
        
        }
        public void Driblar()
        {
            Console.WriteLine($"Soy {nombreJugador} y estoy driblando al oponente.");
        }

        public void CabecearOfensivamente()
        {
            Console.WriteLine($"Soy {nombreJugador} y cabeceo ofensivamente.");
        }

        public void DisparoAPuerta()
        {
            Console.WriteLine($"Soy {nombreJugador} y disparo a puerta.");
        }

    }
}
