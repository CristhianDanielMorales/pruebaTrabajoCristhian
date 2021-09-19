using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TrabajoPruebaCristhian.NET;
using System.Configuration;
using System.Data;
using TrabajoPruebaCristhian.Models;
namespace TrabajoPruebaCristhian.NET
{
    public class ProvinciaNET
    {


        ConexionNET cn = new ConexionNET();
        public IEnumerable<Provincia> listadoProvi(string sp)
        {
            List<Provincia> temp = new List<Provincia>();

            using (cn.getcn)

            {

                SqlCommand cmd = new SqlCommand(sp, cn.getcn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.getcn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    temp.Add(new Provincia()

                    {

                        ID = dr.GetInt32(0),
                        NombreProvincia = dr.GetString(1),

                    });

                }
                dr.Close(); cn.getcn.Close();

            }
            return temp;
        }
    }
}