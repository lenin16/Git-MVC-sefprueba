using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CursoE
    {
        public int IdCurso { get; set; }
        public string Curso { get; set; }
        public ProfesorE oProfesor = new ProfesorE();
        
    }
}
