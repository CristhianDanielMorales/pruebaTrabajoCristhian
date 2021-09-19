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
    public class DistritoNET
    {

        ConexionNET cn = new ConexionNET();
        public IEnumerable<Distrito> listadoDistr(string sp)
        {
            List<Distrito> temp = new List<Distrito>();

            using (cn.getcn)

            {

                SqlCommand cmd = new SqlCommand(sp, cn.getcn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.getcn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    temp.Add(new Distrito()

                    {

                        ID = dr.GetInt32(0),
                        NombreDistrito = dr.GetString(1),

                    });

                }
                dr.Close(); cn.getcn.Close();

            }
            return temp;
        }
    }
}