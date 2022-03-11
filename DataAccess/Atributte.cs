using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Atributte
    {
        public SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataAdapter dataAdapter;
        protected DataTable table;
    }
}
