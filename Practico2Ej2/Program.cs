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

            ce.getEmpleadosEmpresa(_Empresa);

            // imprimir cantidad de empleados de la empresa 1 que tienen el cargo de CEO

            int count = ce.listaEmpleados.Count(empleado => empleado.Cargo == "CEO" && empleado.EmpresaId == _Empresa);
            Console.WriteLine($"\nCantidad de empleados con el cargo de CEO en la empresa {_Empresa}: {count}");

            // mostrar los datos del empleado que gana mas


        }
    }
}
