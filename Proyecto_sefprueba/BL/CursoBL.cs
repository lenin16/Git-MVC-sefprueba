using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Entidad;


namespace BL
{
    public class CursoBL
    {
        CursoDAL oCursoDAL = new CursoDAL();
        public List<CursoE> ListadoCursos()
        {
            return oCursoDAL.ListadoCursos();
        }

        public bool AgregarCurso(CursoE oCurso)
        {
            return oCursoDAL.AgregarCurso(oCurso);
        }

        public bool ActualizarCurso(CursoE oCurso)
        {
            return oCursoDAL.ActualizarCurso(oCurso);
        }

        public CursoE BuscarporId(int IdCurso)
        {
            return oCursoDAL.BuscarporId(IdCurso);
        }

        public bool EliminarCurso(int IdCurso)
        {
            return oCursoDAL.EliminarCurso(IdCurso);
        }
    }    
}
