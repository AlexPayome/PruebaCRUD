using ModelData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UsuarioData : CRUD
    {
        public DataTable getUsuario()
        {
            string query = "EXEC sp_getUsuario";
            string result = this.connectionDataBase();
            if (result != "ok")
            {
                return table;
            }
            result = this.execStoredprocedure(query);
            if (result != "ok")
            {
                return table;
            }
            return this.extractData();
        }
        public DataTable getUsuarioId(int id)
        {
            string query = "EXEC getUsuariId @ClnId";
            string result = this.connectionDataBase();
            if (result != "ok")
            {
                return table;
            }
            result = this.execStoredprocedure(query);
            if (result != "ok")
            {
                return table;
            }
            result = this.parameters("@ClnId", id.ToString());
            return this.extractData();
        }
        //public string updateUsuario(string id, string nombre, string apellido, string tipo_documento)
        public string updateUsuario(ClnUsuariosModel user)
        {
            string query = "EXEC updateUsuario @ClnId,@ClnNombre,@ClnApellido,@ClnTipo_Documento";
            string result = this.connectionDataBase();
            if (result != "ok")
            {
                return "Error";
            }
            result = this.execStoredprocedure(query);
            if (result != "ok")
            {
                return "Error";
            }
            result = this.parameters("@ClnId", user.ClnId.ToString().Trim());
            result = this.parameters("@ClnNombre", user.ClnNombre).Trim();
            result = this.parameters("@ClnApellido", user.ClnApellido).Trim();
            result = this.parameters("@ClnTipo_Documento", user.ClnTipo_Documento.ToString().Trim());
            return this.executeSQL();
        }
        public string insertUsuario(ClnUsuariosInsertModel user)
        {
            string query = "EXEC sp_insertUsuario @ClnNombre,@ClnApellido,@ClnTipo_Documento";
            string result = this.connectionDataBase();
            if (result != "ok")
            {
                return "Error";
            }
            result = this.execStoredprocedure(query);
            if (result != "ok")
            {
                return "Error";
            }
            result = this.parameters("@ClnNombre", user.ClnNombre).Trim();
            result = this.parameters("@ClnApellido", user.ClnApellido).Trim();
            result = this.parameters("@ClnTipo_Documento", user.ClnTipo_Documento.ToString().Trim());
            return this.executeSQL();
        }
        public DataTable obtenerTipoDocumento(int id)
        {
            string query = "EXEC getTipoDocumento @id";
            string result = this.connectionDataBase();
            if(result != "ok")
            {
                return table;
            }
            result = this.execStoredprocedure(query);
            if (result != "ok")
            {
                return table;
            }
            result = this.parameters("@id", id.ToString().Trim());
            return this.extractData();
        }
    }
}
