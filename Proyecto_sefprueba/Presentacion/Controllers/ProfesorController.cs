using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BL;
using Entidad;

namespace Presentacion.Controllers
{
    public class ProfesorController : Controller
    {
        ProfesorBL profesorBL = new ProfesorBL();
        // GET: Profesor
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult ListadoProfesores()
        {
            return View(profesorBL.ListadoProfesores());
        }

        public ActionResult AgregarProfesor()
        {
            return View();
        }

        public ActionResult InsertarProfesor(string txtNombres,string txtApellidoP,string txtApellidoM)
        {
            ProfesorE oPrefesor = new ProfesorE();
            oPrefesor.Nombres = txtNombres;
            oPrefesor.ApellidoP = txtApellidoP;
            oPrefesor.ApellidoM = txtApellidoM;

            string mensaje = "";

            if (profesorBL.AgregarProfesor(oPrefesor) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Profesor Agregado..');window.location.href=" +
                            "'/Profesor/ListadoProfesores';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Error!! Profesor no agregado..');window.location.href=" +
                            "'/Profesor/AgregarProfesor';</script>";
            }
            return Content(mensaje);
        }

        public ActionResult EditarProfesor(int idProfesor  )
        {
            return View(profesorBL.BuscarProfesorporId(idProfesor));
        }

        public ActionResult ActualizarProfesor(int txtIdProfesor,string txtNombres, string txtApellidoP, string txtApellidoM)
        {
            ProfesorE oPrefesor = new ProfesorE();
            oPrefesor.IdProfesor = txtIdProfesor;
            oPrefesor.Nombres = txtNombres;
            oPrefesor.ApellidoP = txtApellidoP;
            oPrefesor.ApellidoM = txtApellidoM;

            string mensaje = "";

            if (profesorBL.ActualizarProfesor(oPrefesor) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Profesor Actualizado..');window.location.href=" +
                            "'/Profesor/ListadoProfesores';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Error!! Profesor no actualizado..');window.location.href=" +
                            "'/Profesor/EditarProfesor';</script>";
            }
            return Content(mensaje);
        }

        public ActionResult EliminarProfesor(int IdProfesor)
        {
            string mensaje = "";
            if (profesorBL.EliminarProfesor(IdProfesor) == true)
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Profesor eliminado..');window.location.href=" +
                            "'/Profesor/ListadoProfesores';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                            "alert('..Error!! Profesor no eliminado..');window.location.href=" +
                            "'/Profesor/EditarProfesor';</script>";
            }
            return Content(mensaje);
        }
    }
}