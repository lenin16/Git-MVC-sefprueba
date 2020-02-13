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
    public class ProfesorDAL
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        SqlCommand cmd ;

        public List<ProfesorE> ListadoProfesores()
        {
            List<ProfesorE> listado = new List<ProfesorE>();
            try {
                cn.Open();
                cmd = new SqlCommand("sp_Profesor_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProfesorE profesor = new ProfesorE();
                    profesor.IdProfesor = Convert.ToInt32(dr["ID"]);
                    profesor.Nombres = dr["NOMBRES"].ToString();
                    profesor.ApellidoP = dr["APELLIDO PATERNO"].ToString();
                    profesor.ApellidoM = dr["APELLIDO MATERNO"].ToString();

                    listado.Add(profesor);
                }

            }
            catch (Exception ep)
            {
                throw;
            }
            return listado;
        }

        public bool AgregarProfesor(ProfesorE profesor)
        {
            bool respuesta = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Profesor_Agregar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pNombres = new SqlParameter();
                pNombres.ParameterName = "@Nombres";
                pNombres.SqlDbType = SqlDbType.VarChar;
                pNombres.Size = 40;
                pNombres.Value = profesor.Nombres;

                SqlParameter pApellidoP = new SqlParameter();
                pApellidoP.ParameterName = "@ApellidoP";
                pApellidoP.SqlDbType = SqlDbType.VarChar;
                pApellidoP.Size = 25;
                pApellidoP.Value = profesor.ApellidoP;

                SqlParameter pApellidoM = new SqlParameter();
                pApellidoM.ParameterName = "@ApellidoM";
                pApellidoM.SqlDbType = SqlDbType.VarChar;
                pApellidoM.Size = 25;
                pApellidoM.Value = profesor.ApellidoM;

                cmd.Parameters.Add(pNombres);
                cmd.Parameters.Add(pApellidoP);
                cmd.Parameters.Add(pApellidoM);

                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception ep)
            {
                throw;
            }
            return respuesta;
        }

        public ProfesorE BuscarProfesorporId(int idProfesor)
        {
            ProfesorE oProfesor = new ProfesorE();
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Profesor_BuscarxId", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pIdProfesor = new SqlParameter();
                pIdProfesor.ParameterName = "@IdProfesor";
                pIdProfesor.SqlDbType = SqlDbType.Int;
                pIdProfesor.Value = idProfesor;
                cmd.Parameters.Add(pIdProfesor);

                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    oProfesor.IdProfesor = Convert.ToInt32(dr["ID"]);
                    oProfesor.Nombres = dr["NOMBRES"].ToString();
                    oProfesor.ApellidoP = dr["APELLIDO PATERNO"].ToString();
                    oProfesor.ApellidoM = dr["APELLIDO MATERNO"].ToString();
                }

            }
            catch (Exception ep)
            {
                throw;
            }
            return oProfesor;
        }

        public bool ActualizarProfesor(ProfesorE profesor)
        {
            bool respuesta = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Profesor_Actualizar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pIdProfesor = new SqlParameter();
                pIdProfesor.ParameterName = "@IdProfesor";
                pIdProfesor.SqlDbType = SqlDbType.Int;
                pIdProfesor.Value = profesor.IdProfesor;
                //cmd.Parameters.Add(pIdProfesor);

                SqlParameter pNombres = new SqlParameter();
                pNombres.ParameterName = "@Nombres";
                pNombres.SqlDbType = SqlDbType.VarChar;
                pNombres.Size = 40;
                pNombres.Value = profesor.Nombres;

                SqlParameter pApellidoP = new SqlParameter();
                pApellidoP.ParameterName = "@Apellido_paterno";
                pApellidoP.SqlDbType = SqlDbType.VarChar;
                pApellidoP.Size = 25;
                pApellidoP.Value = profesor.ApellidoP;

                SqlParameter pApellidoM = new SqlParameter();
                pApellidoM.ParameterName = "@Apellido_materno";
                pApellidoM.SqlDbType = SqlDbType.VarChar;
                pApellidoM.Size = 25;
                pApellidoM.Value = profesor.ApellidoM;

                cmd.Parameters.Add(pIdProfesor);
                cmd.Parameters.Add(pNombres);
                cmd.Parameters.Add(pApellidoP);
                cmd.Parameters.Add(pApellidoM);

                cmd.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception ep)
            {
                throw;
            }
            return respuesta;
        }

        public bool EliminarProfesor(int idProfesor)
        {
            bool eliminar = false;
            try
            {
                cn.Open();
                cmd = new SqlCommand("sp_Profesor_Eliminar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter pIdProfesor = new SqlParameter();
                pIdProfesor.ParameterName = "@IdProfesor";
                pIdProfesor.SqlDbType = SqlDbType.Int;
                pIdProfesor.Value = idProfesor;

                cmd.Parameters.Add(pIdProfesor);
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
