using System.Diagnostics.CodeAnalysis;

namespace Practico2Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ControlEmpresasEmpleados ce = new ControlEmpresasEmpleados();

            Console.WriteLine("Promedios por empresas \n**************************");
            ce.promedioSalario();
            Console.WriteLine("");

            Console.WriteLine("Peces Gordos \n**************************");
            Console.WriteLine("CEO");

            Console.WriteLine("");
            Console.WriteLine("Plantilla \n***************************");
            ce.getEmpleadosOrdenados();
            Console.WriteLine("");
            Console.WriteLine("Plantilla ordenada por salario \n***********************");
            ce.getEmpleadosOrdenadosSegun();

            Console.WriteLine("\nIngrese la empresa:(entero 1 a 3)\n1 para IAlpha\n2 para UdelaR\n3 para spaceZ");
            if (!int.TryParse(Console.ReadLine(), out int _Empresa) || _Empresa < 1 || _Empresa > 3)
            {
                Console.WriteLine("Ha introducido un Id erróneo. Debe ingresar un número entero entre 1 y 3.");
                return;
            }


            // imprimir cantidad de empleados de la empresa 1 que tienen el cargo de CEO

            int maxSalario = ce.listaEmpleados.Max(e => e.Salario);

            var empleadosConMaxSalario = ce.listaEmpleados.Where(e => e.Salario == maxSalario);

            Console.WriteLine("\nEmpleados que ganan más:");
            foreach (var empleado in empleadosConMaxSalario)
            {
                Console.WriteLine($"ID: {empleado.Id}, Nombre: {empleado.Nombre}, Salario: {empleado.Salario}");
            }

            // imprimir los empleados que ganan mas de 2200

            var empleadosMasDe2200 = ce.listaEmpleados.Where(s => s.Salario >= 2200 );

            Console.WriteLine("\nEmpleados que ganan más de 2200:");
            foreach (var empleado in empleadosMasDe2200)
            {
                Console.WriteLine($"ID: {empleado.Id}, Nombre: {empleado.Nombre}, Salario: {empleado.Salario}");
            }

            // mostrar el empleado que gana mas por cada cargo


        }
    }
}
