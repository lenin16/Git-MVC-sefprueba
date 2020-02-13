using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidad;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL
{
    public class CursoDAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd;

        public List<CursoE> ListadoCursos()
        {
            List<CursoE> Listado = new List<CursoE>();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Curso_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CursoE oCurso = new CursoE();
                    oCurso.IdCurso = Convert.ToInt32(dr["ID"]);
                    oCurso.Curso = dr["CURSO"].ToString();
                    oCurso.oProfesor.Nombres = dr["PROFESOR"].ToString();
                    Listado.Add(oCurso);
                }

            }
            catch (Exception ep)
            {
                throw;
            }
            return Listado;
        }

    }
}
