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
            string _Id = Console.ReadLine();
            try
            {
                int _Empresa = int.Parse(_Id);
                ce.getEmpleadosEmpresa(_Empresa);
            }
            catch
            {
                Console.WriteLine("Ha introducido un Id erroneo. Debe ingresar un numero entero");
            }

            // imprimir cantidad de empleados de la empresa 1 que tienen el cargo de CEO

            ce.getEmpleadosEmpresa(_Empresa);

            // Imprimir cantidad de empleados con el cargo de CEO en la empresa especificada
            string cargo = "CEO";
            int count = ce.listaEmpleados.Count(empleado => empleado.Cargo == cargo && empleado.EmpresaId == _Empresa);
            Console.WriteLine($"Cantidad de empleados con el cargo de {cargo} en la empresa {_Empresa}: {count}");


        }
    }
}
