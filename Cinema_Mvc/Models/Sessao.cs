using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Sessao
    {
        public int SessaoID { get; set; }
        public int CinemaID { get; set; }
        public int FilmeID { get; set; }
        public TimeSpan Horario { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        

        
    }
}