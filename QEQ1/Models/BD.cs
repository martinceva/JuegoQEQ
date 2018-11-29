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
            int x = 0;
            String y = null;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ObtenerCategorias";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pID", IDCategoria);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {

                x =  Convert.ToInt32(dataReader["IDcategoria"]);
                y = (dataReader["NombreCategoria"].ToString());
            

            }
            Categorias a = new Categorias(x, y);
            desconectar(conexion);
            return a;
        }

        public bool Registrarse(Usuario A)
        {
            bool a = false;
            Usuario x = new Usuario();
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_InsertarUsuarios";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pMail", A.Email);
            consulta.Parameters.AddWithValue("@pContraseña", A.Contraseña);
            consulta.Parameters.AddWithValue("@pNombre", A.NomUsuario);
            consulta.Parameters.AddWithValue("@pRol", 0);
            consulta.Parameters.AddWithValue("@pPuntaje", 0);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }

        public string admin(Usuario a)
        {
            string rolusuario = "";
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_RolUsuario";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pID", a.IDUsuario);
            SqlDataReader Lector = consulta.ExecuteReader();
            Lector.Read();
            rolusuario = Lector["Rol"].ToString();
            desconectar(conexion);
            return rolusuario;
        }

        
  
        public static bool InsertarPregunta(Preguntas p)
        {
            bool a = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_InsertarPreguntas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pTextoPregunta", p.TextoPregunta);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarPregunta(int IDPregunta)
        {
            bool b = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarPreguntas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", IDPregunta);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                b = true;
            }
            return b;
        }
        public static bool ModificarPregunta(Preguntas p)
        {
            bool c = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "Sp_ModificarPreguntas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", p.IDPregunta);
            consulta.Parameters.AddWithValue("@pTextoPregunta", p.TextoPregunta);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                c = true;
            }
            return c;
        }
        public static List<Preguntas> ListarPreguntas()
        {
            List<Preguntas> listaPreguntas = new List<Preguntas>();
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ListarPreguntas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IDPregunta = Convert.ToInt32(dataReader["IDPregunta"]);
                string TextoPregunta = (dataReader["TextoPregunta"].ToString());
                listaPreguntas.Add(new Preguntas(IDPregunta, TextoPregunta));
            }
            desconectar(conexion);
            return listaPreguntas;
        }
        public static Preguntas ObtenerPreguntas(int IDPregunta)
        {
            int x = 0;
            String y = null;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ObtenerPreguntas";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pID", IDPregunta);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {

                x = Convert.ToInt32(dataReader["IDpregunta"]);
                y = (dataReader["TextoPregunta"].ToString());


            }
            Preguntas a = new Preguntas(x, y);
            desconectar(conexion);
            return a;
        }
        
         public static bool InsertarPersonajes(Personajes pe)
        {
            bool a = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_InsertarPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pNombrePersonaje", p.NombrePersonaje);
            // ver como hacer lo de la foto
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                a = true;
            }
            return a;
        }
        public static bool EliminarPersonaje(int IDPersonaje)
        {
            bool b = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_EliminarPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", IDPersonaje);
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                b = true;
            }
            return b;
        }
        public static bool ModificarPersonaje(Personajes pe)
        {
            bool c = false;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "Sp_ModificarPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pId", p.IDPersonaje);
            consulta.Parameters.AddWithValue("@pNombre", p.NombrePersonaje);
            // ver como hacer lo de la foto
            int regsAfectados = consulta.ExecuteNonQuery();
            desconectar(conexion);
            if (regsAfectados == 1)
            {
                c = true;
            }
            return c;
        }
        public static List<Personajes> ListarPersonajes()
        {
            List<Personajes> listaPersonajes = new List<Personajes>();
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ListarPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {
                int IDPersonaje = Convert.ToInt32(dataReader["IDpersonaje"]);
                string NombrePersonaje = (dataReader["Nombre"].ToString());
                //ver como hacer lo de la foto
                listaPersonajes.Add(new Personajes(IDPersonaje, NombrePersonaje));
            }
            desconectar(conexion);
            return listaPersonajes;
        }
        public static Personajes ObtenerPersonajes (int IDPersonaje)
        {
            int x = 0;
            String y = null;
            SqlConnection conexion = conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "sp_ObtenerPersonajes";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@pIDpersonaje", IDPersonaje);
            SqlDataReader dataReader = consulta.ExecuteReader();
            while (dataReader.Read())
            {

                x = Convert.ToInt32(dataReader["IDpersonaje"]);
                y = (dataReader["TextoNombre"].ToString());


            }
            Personajes a = new Personajes(x, y);
            desconectar(conexion);
            return a;
        }
         
    }
}