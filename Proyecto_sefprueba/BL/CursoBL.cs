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
    }
}
