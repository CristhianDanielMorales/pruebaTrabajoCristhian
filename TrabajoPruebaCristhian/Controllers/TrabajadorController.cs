using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using System.Data.SqlClient;

using System.Configuration;
using TrabajoPruebaCristhian.NET;
using TrabajoPruebaCristhian.Models;

namespace TrabajoPruebaCristhian.Controllers
{

  

    public class TrabajadorController : Controller
    {
        // GET: Trabajador
        TrabajadoresNETcs trabajadores = new TrabajadoresNETcs();
        DepartamentoNET departamento = new DepartamentoNET();
        ProvinciaNET provincia = new ProvinciaNET();
        DistritoNET distrito = new DistritoNET();
        public ActionResult Index()
        {
            return View(trabajadores.ListaTraba("LISTA_TRABAJADORESS"));
        }

       public ActionResult Create()
        {
            //ENVIO LISTA DE DEPARTAMENTO ; PARA EL DROPDOWN

        //    ViewBag.Departamento = new SelectList(departamento.listadoDepar("SP_LISTA_DEPARTAMENTO"), "ID", "NombreDepartamento");
         //   ViewBag.Provincia = new SelectList(provincia.listadoProvi("SP_LISTA_PROVINCIAS"), "ID", "NombreProvincia");
          //  ViewBag.Distrito = new SelectList(distrito.listadoDistr("SP_LISTA_DISTRITO"), "ID", "NombreDistrito");
            //ENVIO EL DEPARTAMENTO

            return View(new Trabajadores());

        }
        [HttpPost]
        public ActionResult Create(Trabajadores tra)
        {

            SqlParameter[] pars = {
                
                new SqlParameter(){ ParameterName="@TIPO" ,Value = tra.TipoDocumento} ,
                new SqlParameter(){ ParameterName="@DOCUMENTO" ,Value = tra.NroDocumento} ,
                new SqlParameter(){ ParameterName="@NOMBRES" ,Value = tra.NOMBRES} ,
                new SqlParameter(){ ParameterName="@SEXO" ,Value = tra.SEXO} ,
                new SqlParameter(){ ParameterName="@DEPARTAMENTO" ,Value = tra.DEPARTAMENTO} ,
                new SqlParameter(){ ParameterName="@PROVINCIA" ,Value = tra.PROVINCIA},
                new SqlParameter(){ ParameterName="@DISTRITO" ,Value = tra.DISTRITO} 
             
            };

            ViewBag.mensaje = trabajadores.CRUD("AGREGA_TRABAJADORES", pars, 1);

            //REFRESCAR LA PAGINA CON LOS VALORES DE INICIO 
          //  ViewBag.Departamento = new SelectList(departamento.listadoDepar("SP_LISTA_DEPARTAMENTO"), "ID", "NombreDepartamento", tra.DEPARTAMENTO);
          //  ViewBag.Provincia = new SelectList(provincia.listadoProvi("SP_LISTA_PROVINCIAS"), "ID", "NombreProvincia", tra.PROVINCIA);
          //  ViewBag.Distrito = new SelectList(distrito.listadoDistr("SP_LISTA_DISTRITO"), "ID", "NombreDistrito" ,tra.DISTRITO);
            return View(tra);
        }

        public ActionResult Edit(string id = "")
        {

            //BUSCAR AL CLIENTE POR SU ID 
       /*  Trabajadores tra = trabajadores.Buscar(id);
            if (tra == null) return RedirectToAction("Index");

            //DEFINIR UN VIEWBAG DE TRABAJADORES PARA SELECCIONAR AL PAIS E INDICAR PAIS SELECCIONADO.

       /*     ViewBag.paises = new SelectList(paises.listado("usp_pais_listado"),
                "idpais", "nombrepais", reg.idpais);
       */
            return View(id);
        }

        [HttpPost]
        public ActionResult Edit(Trabajadores tra)
        {
            SqlParameter[] pars =

     {
                
                new SqlParameter(){ ParameterName="@TIPO" ,Value = tra.TipoDocumento} ,
                new SqlParameter(){ ParameterName="@DOCUMENTO" ,Value = tra.NroDocumento} ,
                new SqlParameter(){ ParameterName="@NOMBRES" ,Value = tra.NOMBRES} ,
                new SqlParameter(){ ParameterName="@SEXO" ,Value = tra.SEXO} ,
                new SqlParameter(){ ParameterName="@DEPARTAMENTO" ,Value = tra.DEPARTAMENTO} ,
                new SqlParameter(){ ParameterName="@PROVINCIA" ,Value = tra.PROVINCIA},
                new SqlParameter(){ ParameterName="@DISTRITO" ,Value = tra.DISTRITO}
      };
            ViewBag.mensaje = trabajadores.CRUD("SP_TRABAJADOR_EDITAR", pars, 2);
           // ViewBag.paises = new SelectList(paises.listado("usp_pais_listado"), "idpais", "nombrepais", reg.idpais);
            return View(tra);
        }

     /*   public ActionResult Eliminar(string tra) {


            // traemos el listado de todos los cursos
            var listado = trabajadores.ListaTraba(tra);
            // encontrar un curso en base al id enviado
            Trabajadores objcur = listado.First(c => c.NroDocumento == id);
            //
            return View(objcur);
        }
     */
    }
}
