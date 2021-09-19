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
    public class TrabajadoresNETcs
    {

        ConexionNET cn = new ConexionNET();
        public IEnumerable<Trabajadores> ListaTraba(string sp, SqlParameter[] parametros = null) {

            List<Trabajadores> traba = new List<Trabajadores>();
            using (cn.getcn)

            {
                SqlCommand cmd = new SqlCommand(sp, cn.getcn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                {

                    cmd.Parameters.AddRange(parametros.ToArray());
                }
                cn.getcn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {
                    traba.Add(new Trabajadores()

                    {   
                       
                        TipoDocumento = dr.GetString(0),
                        NroDocumento  = dr.GetString(1),
                        NOMBRES = dr.GetString(2),
                        SEXO = dr.GetString(3),
                        DEPARTAMENTO = dr.GetString(4),
                        PROVINCIA = dr.GetString(5),
                        DISTRITO = dr.GetString(6)

                    });
                }
                dr.Close(); cn.getcn.Close();

            }
            return traba;

        }

        public string CRUD(string sp, SqlParameter[] par = null, int op = 0)
        {
            string mensaje = "";
            using (cn.getcn)
            {

                try
                {
                    SqlCommand cmd = new SqlCommand(sp, cn.getcn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (par != null) cmd.Parameters.AddRange(par.ToArray());

                    cn.getcn.Open();

                    int c = cmd.ExecuteNonQuery();
                    if (op == 1) mensaje = c + " SE AÑADIO UN TRABAJADOR CORRECTAMENTE ";
                    else if (op == 2) mensaje = c + "SE EDITO UN TRABAJADOR CORRECTAMENTE";
                    else if (op == 3) mensaje = c + "SE ELIMINO UN TRABAJADOR CORRECTAMENTE";
                }
                catch (SqlException ex)
                {
                    mensaje = ex.Message;

                }
                finally { cn.getcn.Close(); }


            }


            return mensaje;


        }
       

    }
}