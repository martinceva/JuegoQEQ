using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ1.Models
{
    public class Personajes
    {
        private int _IDPersonaje;
        private string _NombrePersonaje;
        


        public int IDPersonaje
        {
            get { return _IDPersonaje; }
            set { _IDPersonaje = value; }
        }
        public string NombrePersonaje
        {
            get { return _NombrePersonaje; }
            set { _NombrePersonaje = value; }
        }
        public Personajes (int IDPersonaje, string NombrePersonaje)
        {
            _IDPersonaje = IDPersonaje;
            _NombrePersonaje = NombrePersonaje;
        }
        public Personajes()
        {
            IDPersonaje = IDPersonaje;
            NombrePersonaje = NombrePersonaje;
        }
    }
}