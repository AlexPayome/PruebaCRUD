using Business;
using Microsoft.AspNetCore.Mvc;
using ModelData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaCrud.Controllers.Servicios
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioUsuarioIdController : ControllerBase
    {
        [HttpGet]
        public ClnUsuariosModel Get(int id)
        {
            
            UsuarioManager user = new();
            ClnUsuariosModel model = new();
            model = user.usuarioId((id));

            
            return model;
        }       
    }
}
