using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Data.SqlClient;

using System.Configuration;

using TrabajoPruebaCristhian.Models;

namespace TrabajoPruebaCristhian.NET
{
    public class ConexionNET
    {

        private SqlConnection cn = new SqlConnection(

      ConfigurationManager.ConnectionStrings["cn1"].ConnectionString);


        //solo se lee la conexion
        public SqlConnection getcn

        {
            get { return cn; }
        }

    }
}