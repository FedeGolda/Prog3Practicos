using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal abstract class Futbolista
    {
        protected int id_jugador { get; set; }
        protected string nombreJugador { get; set; }
        protected string posicion { get; set; }
        protected int edad { get; set; }
        protected string equipo { get; set; }

        public Futbolista()
        {

        }

        public Futbolista(int Id_Jugador, string NombreJugador, string Posicion, int Edad, string Equipo)
        {
            this.id_jugador = Id_Jugador;
            this.nombreJugador = NombreJugador;
            this.posicion = Posicion;
            this.edad = Edad;
            this.equipo = Equipo;
        }

        public virtual void Correr()
        {
            Console.WriteLine($"{nombreJugador} está corriendo.");
        }

        public virtual void PasarPelota()
        {
            Console.WriteLine($"{nombreJugador} pasa la pelota.");
        }

        public virtual void CelebrarGol()
        {
            Console.WriteLine($"{nombreJugador} celebra un gol!");
        }


    }
}
