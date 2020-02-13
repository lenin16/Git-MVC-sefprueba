using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BL;
using Entidad;


namespace Presentacion.Controllers
{
    public class CursoController : Controller
    {
        CursoBL oCursoBL = new CursoBL();

        // GET: Curso
        public ActionResult ListadoCursos()
        {
            return View(oCursoBL.ListadoCursos());
        }

        public ActionResult InsertarCurso()
        {
            List<ProfesorE> lstProfesor = new List<ProfesorE>();
            ProfesorBL oProfesorBL = new ProfesorBL();
            lstProfesor = oProfesorBL.ListadoProfesores();
            ViewBag.ListadoProfesores = lstProfesor;
            return View();
        }

        public ActionResult AgregarCurso(string txtCurso,int cboProfesor)
        {
            CursoE oCurso = new CursoE();
            oCurso.Curso = txtCurso;
            oCurso.oProfesor.IdProfesor = cboProfesor;

            string mensaje = "";

            if (oCursoBL.AgregarCurso(oCurso) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Curso Agregado..');window.location.href=" +
                            "'/Curso/ListadoCursos';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Error!! curso no agregado..');window.location.href=" +
                            "'/Curso/AgregarCurso';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EditarCurso(int IdCurso)
        {
            List<ProfesorE> lstProfesor = new List<ProfesorE>();
            ProfesorBL oProfesorBL = new ProfesorBL();
            lstProfesor = oProfesorBL.ListadoProfesores();
            ViewBag.ListadoProfesores = lstProfesor;
            return View(oCursoBL.BuscarporId(IdCurso));
        }

        public ActionResult ActualizarCurso(int txtIdCurso, string txtCurso, int cboProfesor)
        {
            CursoE oCurso = new CursoE();
            oCurso.IdCurso = txtIdCurso;
            oCurso.Curso = txtCurso;
            oCurso.oProfesor.IdProfesor = cboProfesor;

            string mensaje = "";

            if (oCursoBL.ActualizarCurso(oCurso) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Curso actualizado..');window.location.href=" +
                            "'/Curso/ListadoCursos';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Error!! curso no actualizdo..');window.location.href=" +
                            "'/Curso/EditarCurso';</script>";
            }

            return Content(mensaje);
        }

        public ActionResult EliminarCurso(int IdCurso)
        {
            string mensaje = "";
            if (oCursoBL.EliminarCurso(IdCurso) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Curso eliminado..');window.location.href=" +
                            "'/Curso/ListadoCursos';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Error!! curso no eliminado..');window.location.href=" +
                            "'/Curso/ListadoCursos';</script>";
            }
            return Content(mensaje);
        }
    }
}