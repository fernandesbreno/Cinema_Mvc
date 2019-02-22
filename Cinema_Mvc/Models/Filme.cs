using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Filme
    {
        public int FilmeId { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int Classificacao { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}