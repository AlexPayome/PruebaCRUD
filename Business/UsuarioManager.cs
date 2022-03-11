using DataAccess;
using ModelData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Business
{
    public class UsuarioManager
    {
        public DataTable usuario()
        {
            DataTable dt = new();
            UsuarioData usuario = new UsuarioData();
            dt = usuario.getUsuario();
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
            return dt;
        }
        public ClnUsuariosModel usuarioId(int id)
        {
            DataTable dt = new();
            UsuarioData usuario = new UsuarioData();
            dt = usuario.getUsuarioId(id);
            ClnUsuariosModel model = new() { 
                ClnId = Convert.ToInt32(dt.Rows[0]["ClnId"]),
                ClnNombre = dt.Rows[0]["ClnNombre"].ToString().Trim(),
                ClnApellido = dt.Rows[0]["ClnApellido"].ToString().Trim(),
                ClnTipo_Documento = Convert.ToInt32(dt.Rows[0]["ClnTipo_Documento"])
            };
            return model;
        }
        public string actualizarUsuario(ClnUsuariosModel model)
        {
            UsuarioData usuario = new UsuarioData();
            string responde = usuario.updateUsuario(model);
            if (responde.Equals("ok"))
            {
                return "ok";
            }
            else
            {
                return "No se pudo actualizar el usuario";
            }
        }
        public string insertarUsuario(ClnUsuariosInsertModel model)
        {
            UsuarioData usuario = new UsuarioData();
            string responde = usuario.insertUsuario(model);
            if (responde.Equals("ok"))
            {
                return "ok";
            }
            else
            {
                return "No se pudo crear el usuario";
            }
        }
        public List<SelectListItem> getTipoDocumento(int id)
        {
            UsuarioData user = new();
            List<SelectListItem> model = new List<SelectListItem>();
            DataTable dt = user.obtenerTipoDocumento(id);
            foreach (DataRow item in dt.Rows)
            {
                model.Add(new SelectListItem()
                {
                    Text = item["ClnDtTipo_Documento"].ToString().Trim(),
                    Value = item["ClnDtId_Tipo_Documento"].ToString().Trim()
                });
            }
            return model;
        }
    }
}
