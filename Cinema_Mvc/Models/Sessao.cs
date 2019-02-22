using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Sessao
    {
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
        public TimeSpan Horario { get; set; }
    }
}