namespace Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sucursal sucursal1 = new Sucursal(1, "Maldonado", 200000);
            Sucursal sucursal2 = new Sucursal(2, "Melo", 568732);
            Sucursal sucursal3 = new Sucursal(3, "Rocha", 3546321);
            Sucursal sucursal4 = new Sucursal(4, "Montevideo", 655647);
            Sucursal sucursal5 = new Sucursal(5, "Maldonado", 200000);



            List<Sucursal> Sucursales = new List<Sucursal> { sucursal1, sucursal2, sucursal3, sucursal4, sucursal5 };

            Sucursales.OrderBy(x => x.Poblacion).ToList().ForEach(x => Console.WriteLine(x.Ciudad));
            
                          



        }
    }
}
