using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Sessao
    {
        public int SessaoID { get; set; }
        [Required]
        public int CinemaID { get; set; }
        [Required]
        public int FilmeID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan Horario { get; set; }

        public virtual Cinema Cinema { get; set; }
        public virtual Filme Filme { get; set; }
        

        
    }
}