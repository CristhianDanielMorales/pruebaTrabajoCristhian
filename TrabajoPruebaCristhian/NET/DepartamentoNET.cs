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
    public class DepartamentoNET
    {

        ConexionNET cn = new ConexionNET();
        public IEnumerable<Departamento> listadoDepar(string sp)
        {
            List<Departamento> temp = new List<Departamento>();

            using (cn.getcn)

            {

                SqlCommand cmd = new SqlCommand(sp, cn.getcn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.getcn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())

                {

                    temp.Add(new Departamento()

                    {

                        ID = dr.GetInt32(0),
                        NombreDepartamento = dr.GetString(1),

                    });

                }
                dr.Close(); cn.getcn.Close();

            }
            return temp;
        }
    } 
        }