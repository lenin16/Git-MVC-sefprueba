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
    }
}