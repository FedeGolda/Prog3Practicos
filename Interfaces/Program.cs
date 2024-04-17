namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Delantero delantero = new Delantero(1, "Lionel Messi", "Delantero", 36, "Inter Miami CF");
            delantero.Correr();
            delantero.PasarPelota();
            delantero.CelebrarGol();
            delantero.Driblar();
            delantero.CabecearOfensivamente();
            delantero.DisparoAPuerta();

            MedioCampo medioCampo = new MedioCampo(2, "Luka Modrić", "MedioCampo", 38, "Real Madrid CF");
            medioCampo.Correr();
            medioCampo.PasarPelota();
            medioCampo.CelebrarGol();
            medioCampo.DistribuirJuego();
            medioCampo.DarAsistencia();
            medioCampo.RecuperarBalon();

            Defensor defensor = new Defensor(3, "Sergio Ramos", "Defensa", 38, "Sevilla FC");
            defensor.Correr();
            defensor.PasarPelota();
            defensor.CelebrarGol();
            defensor.DespejarBalon();
            defensor.MarcarOponente();
            defensor.Barrida();

            Golero golero = new Golero(4, "Thibaut Courtois", "Portero", 31, "Real Madrid CF");
            golero.AtajarPenal();
            golero.LanzarRapido();
            golero.DespejarConLosPunios();
            golero.Correr();
            golero.PasarPelota();
            golero.CelebrarGol();
        }
    }
}
