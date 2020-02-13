using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using Entidad;

namespace BL
{
    public class ProfesorBL
    {
        ProfesorDAL profesorDAL = new ProfesorDAL();
        public List<ProfesorE> ListadoProfesores()
        {
            return profesorDAL.ListadoProfesores();
        }

        public bool AgregarProfesor(ProfesorE objprofesor)
        {
            return profesorDAL.AgregarProfesor(objprofesor);
        }

        public ProfesorE BuscarProfesorporId(int idProfesor)
        {
            return profesorDAL.BuscarProfesorporId(idProfesor);
        }

        public bool ActualizarProfesor(ProfesorE profesor)
        {
            return profesorDAL.ActualizarProfesor(profesor);
        }

        public bool EliminarProfesor(int idProfesor)
        {
            return profesorDAL.EliminarProfesor(idProfesor);
        }

    }
}
