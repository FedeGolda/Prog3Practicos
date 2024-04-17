using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal class MedioCampo : Futbolista, IMedioCampo
    {
        public MedioCampo(int id_jugador, string nombreJugador, string posicion, int edad, string equipo) 
            : base(id_jugador, nombreJugador, posicion, edad, equipo)
        {

        }
        public void DistribuirJuego()
        {
            Console.WriteLine($"Soy {nombreJugador} y hago distribuir juego.");
        }

        public void RecuperarBalon()
        {
            Console.WriteLine($"Soy {nombreJugador} y recupero el balon."); 
        }

        public void DarAsistencia()
        {
            Console.WriteLine($"Soy {nombreJugador} y hago asistencia.");
        }

    }
}
