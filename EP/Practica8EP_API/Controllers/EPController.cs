using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica8EP_API.Datos;
using Practica8EP_API.Modelos;
using Practica8EP_API.Modelos.Dto;

namespace Practica8EP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EPController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<EPDto> GetEPDto()
        {
            return EPStore.EPList;
        }

        [HttpGet("Id")]//Retorna un objeto. Hay que diferencial los End Point
        public EPDto GetEPDto(int Id)
        {
            return EPStore.EPList.FirstOrDefault(a => a.Id == Id);
        }
    }
}
