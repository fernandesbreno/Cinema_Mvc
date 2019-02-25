using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Filme
    {
        public int FilmeId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

        
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Genero { get; set; }

        [Required]
        [Range(60, 350)]
        public int Duracao { get; set; }

        [Required]
        [Range(0, 18)]
        public int Classificacao { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}