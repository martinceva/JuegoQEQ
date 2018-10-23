using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ1.Models
{
    public class Usuario
    {
        private int _IDUsuario;

        public int IDUsuario
        {
            get { return _IDUsuario; }
            set { _IDUsuario = value; }
        }

        private string _Email;
        [Required(ErrorMessage = "Ingresa un Email valido")]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }

        }

        private string _Contraseña;
        [Required(ErrorMessage = "Ingrese una contraseña entre 8 y 18 caracteres")]
        [StringLength(18, MinimumLength = 8)]
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
        private string _NomUsuario;

        public string NomUsuario
        {
            get { return _NomUsuario; }
            set { _NomUsuario = value; }
        }
        private string _Rol;

        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        private int _Puntaje;

        public int Puntaje
        {
            get { return _Puntaje; }
            set { _Puntaje = value; }
        }


        public Usuario(int IDUsuario, String Email, String Contraseña, string NomUsuario, string Rol, int Puntaje)
        {
            _IDUsuario = IDUsuario;
            _Email= Email;
            _Contraseña = Contraseña;
            _NomUsuario = NomUsuario;
            _Rol = Rol;
            _Puntaje = Puntaje;

        }
        public Usuario()
        {
            IDUsuario = IDUsuario;
            Email = Email;
            Contraseña = Contraseña;
            NomUsuario = NomUsuario;
            Rol = Rol;
            Puntaje = Puntaje;
        }

    }
}