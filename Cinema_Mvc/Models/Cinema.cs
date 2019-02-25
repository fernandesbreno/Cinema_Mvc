using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Cinema
    {
        public int CinemaID { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 7)]
        public string Endereco { get; set; }

        public virtual ICollection<Sessao> Sessoes { get; set; }

    }
}