using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QEQ1.Models
{
    public class Categorias
    {
        private int _IDCategoria;
        private string _NombreCategoria;

        public int IDCategoria
        {
            get { return _IDCategoria; }
            set { _IDCategoria = value; }
        }

        public string NombreCategoria
        {
            get { return _NombreCategoria; }
            set { _NombreCategoria = value; }
        }

        public Categorias (int IDCategoria, string NombreCategoria)
        {
            _IDCategoria = IDCategoria;
            _NombreCategoria = NombreCategoria;

        }
        public Categorias()
        {
            IDCategoria = IDCategoria;
            NombreCategoria = NombreCategoria;
        }
    }
}