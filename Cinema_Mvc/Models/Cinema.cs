using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Cinema
    {
        public int CinemaID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }

    }
}