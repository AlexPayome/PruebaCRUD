using Business;
using Microsoft.AspNetCore.Mvc;
using ModelData;
using PruebaCrud.Models;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<System.Web.Mvc.SelectListItem> lista;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ClnUsuariosModel> model = new List<ClnUsuariosModel>();
            UsuarioManager usuario = new UsuarioManager();
            DataTable dt = new();
            dt = usuario.usuario();
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
            return View(model);
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            ViewBag.documentos = ObtenerDocumentos(0).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            });
            ClnUsuariosModel model = new();
            UsuarioManager user = new();
            model = user.usuarioId(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Editar(ClnUsuariosModel model)
        {
            UsuarioManager user = new();
            user.actualizarUsuario(model);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Insertar()
        {
            ViewBag.documentos = ObtenerDocumentos(0).Select(x => new SelectListItem
            {
                Text = x.Text,
                Value = x.Value
            });
            return View();
        }
        [HttpPost]
        public IActionResult Insertar(IFormCollection frm)
        {
            UsuarioManager user = new();
            ClnUsuariosInsertModel model = new()
            {
                ClnNombre = frm["nombre"].ToString().Trim(),
                ClnApellido = frm["apellido"].ToString().Trim(),
                ClnTipo_Documento = Convert.ToInt32(frm["tipoD"])
            };
            user.insertarUsuario(model);
            return RedirectToAction("Index", "Home");
        }
        public List<System.Web.Mvc.SelectListItem> ObtenerDocumentos(int id)
        {
            lista = new List<System.Web.Mvc.SelectListItem>();
            UsuarioManager user = new UsuarioManager();
            lista = user.getTipoDocumento(0);
            return lista;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}