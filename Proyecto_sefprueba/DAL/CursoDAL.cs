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

        public bool AgregarCurso(CursoE oCurso)
        {
            bool agregar = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Curso_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pCurso = new SqlParameter();
                pCurso.ParameterName = "@Curso";
                pCurso.SqlDbType = SqlDbType.VarChar;
                pCurso.Size = 45;
                pCurso.Value = oCurso.Curso;

                SqlParameter pIdProfesor = new SqlParameter();
                pIdProfesor.SqlDbType = SqlDbType.Int;                
                pIdProfesor.ParameterName = "@IdProfesor";
                pIdProfesor.Value = oCurso.oProfesor.IdProfesor;

                cmd.Parameters.Add(pCurso);
                cmd.Parameters.Add(pIdProfesor);

                cmd.ExecuteNonQuery();
                agregar = true;

            }
            catch (Exception ep)
            {
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();

            }
            return agregar;
        }

        public bool ActualizarCurso(CursoE oCurso)
        {
            bool actualizar = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Curso_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pIdCurso = new SqlParameter();
                pIdCurso.ParameterName = "@IdCurso";
                pIdCurso.SqlDbType = SqlDbType.Int;                
                pIdCurso.Value = oCurso.IdCurso;

                SqlParameter pCurso = new SqlParameter();
                pCurso.ParameterName = "@Curso";
                pCurso.SqlDbType = SqlDbType.VarChar;
                pCurso.Size = 45;
                pCurso.Value = oCurso.Curso;

                SqlParameter pIdProfesor = new SqlParameter();
                pIdProfesor.SqlDbType = SqlDbType.Int;
                pIdProfesor.ParameterName = "@IdProfesor";
                pIdProfesor.Value = oCurso.oProfesor.IdProfesor;

                cmd.Parameters.Add(pIdCurso);
                cmd.Parameters.Add(pCurso);
                cmd.Parameters.Add(pIdProfesor);

                cmd.ExecuteNonQuery();
                actualizar = true;

            }
            catch (Exception ep)
            {
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open) cn.Close();

            }
            return actualizar;
        }

        public CursoE BuscarporId(int IdCurso)
        {
            CursoE oCurso = new CursoE();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Curso_BuscarxId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pIdCurso = new SqlParameter();
                pIdCurso.ParameterName = "@IdCurso";
                pIdCurso.SqlDbType = SqlDbType.Int;
                pIdCurso.Value = IdCurso;

                cmd.Parameters.Add(pIdCurso);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    oCurso.IdCurso = Convert.ToInt32(dr["ID"]);
                    oCurso.Curso = dr["CURSO"].ToString();
                    oCurso.oProfesor.Nombres = dr["PROFESOR"].ToString();
                }

            }
            catch (Exception ep)
            {
                throw;
            }
            return oCurso;
        }

        public bool EliminarCurso(int IdCurso)
        {
            bool eliminar = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Curso_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pIdCurso = new SqlParameter();
                pIdCurso.ParameterName = "@IdCurso";
                pIdCurso.SqlDbType = SqlDbType.Int;
                pIdCurso.Value = IdCurso;

                cmd.Parameters.Add(pIdCurso);
                cmd.ExecuteNonQuery();

                eliminar = true;
            }
            catch (Exception ep)
            {
                throw;
            }
            return eliminar;
        }

    }
}
