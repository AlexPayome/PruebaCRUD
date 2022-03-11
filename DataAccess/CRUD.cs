using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CRUD : Atributte
    {
        private string connectionChain;
        public string connectionDataBase()
        {
            connectionChain = @"Data Source=JARVIS\SQLEXPRESS;Initial Catalog=PruebaTecnica;Integrated Security=true";
            try
            {
                connection = new SqlConnection(connectionChain);
                connection.Open();
                return "ok";
            }
            catch (Exception e)
            {

                return "ok" + e.Message;
            }
        }
        public string execStoredprocedure(String query)
        {
            try
            {
                command = new SqlCommand(query, connection);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string parameters(string parameter, string content)
        {
            try
            {
                command.Parameters.AddWithValue(parameter, content);
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string executeSQL()
        {
            try
            {
                command.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public DataTable extractData()
        {
            try
            {
                dataAdapter = new SqlDataAdapter(command);
                table = new DataTable();
                dataAdapter.Fill(table);
                return table;
            }
            catch
            {
                return table;
            }
        }
    }
}
