﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.Models
{
    public class Filme
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int Classificacao { get; set; }

    }
}