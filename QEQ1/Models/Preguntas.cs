using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QEQ1.Models
{
    public class Preguntas
    {
        private int _IDPregunta;
        private string _TextoPregunta;
        

        public int IDPregunta
        {
            get { return _IDPregunta; }
            set { _IDPregunta = value; }
        }
        public string TextoPregunta
        {
            get { return _TextoPregunta; }
            set { _TextoPregunta = value; }
        }
        public Preguntas (int IDPregunta, string NombrePregunta)
        {
            _IDPregunta = IDPregunta;
            _TextoPregunta = NombrePregunta;
        }
        public Preguntas()
        {
            IDPregunta = IDPregunta;
            TextoPregunta = TextoPregunta;
        }
    }
}