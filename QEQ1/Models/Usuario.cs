using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ1.Models
{
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
    }
}