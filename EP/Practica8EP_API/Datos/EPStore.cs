using Practica8EP_API.Modelos.Dto;

namespace Practica8EP_API.Datos
{
    public class EPStore
    {
        public static List<EPDto> EPList = new List<EPDto>
        {
            new EPDto{Id=1,Nombre="Vista a la Pisina"},
            new EPDto{ Id = 2, Nombre = "Vista a la Playa" }
        };
    }
}
