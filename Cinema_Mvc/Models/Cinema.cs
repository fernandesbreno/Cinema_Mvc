using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Cinema
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public ICollection<Sessao> SessoesFilme { get; set; }

    }
}