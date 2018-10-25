using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QEQ1.Models
{
    public class BD
    {
        public static string connectionString = "Server=10.128.8.16;Database=QEQB01;User ID=QEQB01;Password=QEQB01";
        private static SqlConnection conectar()
        {
            SqlConnection sqlConectar = new SqlConnection(connectionString);
            sqlConectar.Open();
            return sqlConectar;
        }
        private static void desconectar(SqlConnection desconexion)
        {
            desconexion.Close();
        }

        public static Usuario  Login (Usuario A)
        {
            Usuario x = new Usuario();
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "Sp_login";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pMail", A.Email);
            consulta.Parameters.AddWithValue("@pContraseña", A.Contraseña);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                
                    x.IDUsuario = Convert.ToInt32(dataReader["IDusuario"]);
                    x.NomUsuario = (dataReader["NombreUsuario"].ToString());
                    x.Puntaje = Convert.ToInt32(dataReader["Puntaje"]);
                    x.Rol = (dataReader["Rol"].ToString());
                    x.Contraseña = (dataReader["Contraseña"].ToString());
                    x.Email = (dataReader["Email"].ToString());
                
            }
            desconectar(conexion);
            return x;
        }
        
        public static bool InsertarCategoria(Categorias t)
        {
            bool a = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_InsertarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pNombreCategoria", t.NombreCategoria);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarCategoria(int IDCategoria)
        {
            bool b = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", IDCategoria);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                b = true;
            }
            return b;
        }
        public static bool ModificarCategoria(Categorias f)
        {
            bool c = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ModificarCategoria";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", f.IDCategoria);
            consulta.Parameters.AddWithValue("@pNombreCategoria", f.NombreCategoria);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                c = true;
            }
            return c;
        }
        public static List<Categorias> ListarCategorias()
        {
            List<Categorias> listaCategorias = new List<Categorias>();
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ListarCategorias";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IDCategoria = Convert.ToInt32(dataReader["IDCategoria"]);
                string NombreCategoria = (dataReader["NombreCategoria"].ToString());
                listaCategorias.Add(new Categorias(IDCategoria, NombreCategoria));
            }
            desconectar(conexion);
            return listaCategorias;
        }
        public static Categorias ObtenerCategorias(int IDCategoria)
        {

            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ObtenerCategorias";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pID", IDCategoria);
            SqlDataReader dataReader = consulta.ExecuteReader();
            int ID = Convert.ToInt32(dataReader["IDcategoria"]);
            string NombreC = (dataReader["NombreCategoria"].ToString());
            Categorias Obtener = new Categorias(ID, NombreC);
            desconectar(conexion);
            return Obtener;
        }
        
    }
}