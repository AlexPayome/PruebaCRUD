using Business;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using ModelData;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaCrud.Controllers.Servicios
{
    [Route("api/[controller]")]
    [ApiController]
    public class PruebaServiciosController : ControllerBase
    {
        // GET: api/<PruebaServiciosController>
        [HttpGet]
        public List<ClnUsuariosModel> Get()
        {
            DataTable dt = new();
            UsuarioManager usuario = new UsuarioManager();
            dt = usuario.usuario();
            List<ClnUsuariosModel> model = new List<ClnUsuariosModel>();
            foreach (DataRow item in dt.Rows)
            {
                model.Add(new ClnUsuariosModel()
                {
                    ClnId = Convert.ToInt32(item["ClnId"]),
                    ClnNombre = item["ClnNombre"].ToString().Trim(),
                    ClnApellido = item["ClnApellido"].ToString().Trim(),
                    ClnTipo_Documento = Convert.ToInt32(item["ClnTipo_Documento"])
                });
            }
            return model;
        }

        // GET api/<PruebaServiciosController>/5
        

        // POST api/<PruebaServiciosController>
        [HttpPost]
        public string Post(ClnUsuariosInsertModel model) //Insertar
        {//por queryparam
            UsuarioManager user = new();
            string respuesta = user.insertarUsuario(model);
            return respuesta;
        }

        // PUT api/<PruebaServiciosController>/5
        [HttpPut]
        public string Put(ClnUsuariosModel model) //actualizar
        { //llamar un modelo
            UsuarioManager user = new();
            string respuesta = user.actualizarUsuario(model);
            return respuesta;
        }

        // DELETE api/<PruebaServiciosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
