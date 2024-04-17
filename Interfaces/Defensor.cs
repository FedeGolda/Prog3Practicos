using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class Defensor : Futbolista, IDefensor
    {
        public Defensor(int idJugador, string nombreJugador, string posicion, int edad, string equipo)
        : base(idJugador, nombreJugador, posicion, edad, equipo)
        {

        }

        public void Barrida()
        {
            Console.WriteLine($"Soy {nombreJugador} y estoy haciendo una barrida");
        }

        public void MarcarOponente()
        {
            Console.WriteLine($"Soy {nombreJugador} y estoy marcando oponente");
        }

        public void DespejarBalon()
        {
            Console.WriteLine($"Soy {nombreJugador} y estoy despejando el balon");
        }
    }
}
