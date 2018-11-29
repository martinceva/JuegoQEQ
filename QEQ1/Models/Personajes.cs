using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ1.Models
{
    public class Personajes
    {
        private int _IDPersonaje;
        private string _NombrePersonaje;
        private string _UrlDataFoto;

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
        public string UrlDataFoto
        {
            get { return _UrlDataFoto; }
            set { _UrlDataFoto = value; }
        }
        public Personajes (int IDPersonaje, string NombrePersonaje, string UrlDataFoto)
        {
            _IDPersonaje = IDPersonaje;
            _NombrePersonaje = NombrePersonaje;
            _UrlDataFoto = UrlDataFoto;
        }
        public Personajes()
        {
            IDPersonaje = IDPersonaje;
            NombrePersonaje = NombrePersonaje;
            UrlDataFoto = UrlDataFoto;
        }
    }
}