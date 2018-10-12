using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QEQ1.Models
{
    public String connectionstring = ""
    public class Usuario
    {
        private string _Email;
        [Required(ErrorMessage = "Ingresa un Email valido")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }

        }

        private string _Contraseña;
        [Required(ErrorMessage = "Contraseña incorrecta")]
        [StringLength(18, MinimumLength = 8)]
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }

        private Boolean Login(String User, String Pass)
        {
            SqlConnection conexion = AbrirConexion();

            CerrarConexion(conexion);
        }

        private static SqlConnection AbrirConexion()
        {
            SqlConnection conexion = new SqlConnection(connectionstring);
            conexion.Open();

            return conexion;
        }

        private static SqlConnection CerrarConexion(SqlConnection conexion)
        {
            conexion.Close();

            return conexion;
        }
    }
}