using Cinema_Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema_Mvc.DAL
{
    public class CinemaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CinemaContext>
    {
        protected override void Seed(CinemaContext context)
        {
            var filmes = new List<Filme>
            {
            new Filme{FilmeId = 0, Nome = "Avengers", Genero = "Ação", Duracao = 120, Classificacao = 14},
            new Filme{FilmeId = 1, Nome = "Black Panther", Genero = "Ação", Duracao = 240, Classificacao = 14},
            new Filme{FilmeId = 2, Nome = "Spider-Man", Genero = "Ação", Duracao = 110, Classificacao = 10},
            new Filme{FilmeId = 3, Nome = "Bohemian Rhapsody", Genero = "Drama", Duracao = 100, Classificacao = 18},
            new Filme{FilmeId = 4, Nome = "Roma", Genero = "Suspense", Duracao = 120, Classificacao = 16},
            new Filme{FilmeId = 5, Nome = "Coco", Genero = "Comedia", Duracao = 140, Classificacao = 10},
            new Filme{FilmeId = 6, Nome = "Happy Death Day", Genero = "Comedia/Terror", Duracao = 120, Classificacao = 14},
            new Filme{FilmeId = 7, Nome = "Guardians of the Galaxy", Genero = "Ação", Duracao = 130, Classificacao = 10},
            new Filme{FilmeId = 8, Nome = "Inception", Genero = "Suspense/Terror", Duracao = 200, Classificacao = 18}
            };

            filmes.ForEach(s => context.Filmes.Add(s));
            context.SaveChanges();

            var cinemas = new List<Cinema>
            {
            new Cinema{CinemaID = 0, Nome = "Cinepolis", Endereco = "Rua Sabia, 850"},
            new Cinema{CinemaID = 1, Nome = "Cinemark", Endereco = "Rua Arara, 851"},
            new Cinema{CinemaID = 2, Nome = "Cinesia", Endereco = "Rua Tucano, 852"},
            new Cinema{CinemaID = 3, Nome = "SpCine", Endereco = "Rua Avestruz, 853"},
            new Cinema{CinemaID = 4, Nome = "CINUSP", Endereco = "Rua Tucunara, 854"},
            new Cinema{CinemaID = 5, Nome = "Kinoplex", Endereco = "Rua Falcao, 855"},
            new Cinema{CinemaID = 6, Nome = "Cinemark", Endereco = "Rua Beija-Flor, 856"},
            new Cinema{CinemaID = 7, Nome = "Cinelive", Endereco = "Rua Pica-pau, 857"},
            new Cinema{CinemaID = 8, Nome = "CINE", Endereco = "Rua Aguia de rapina, 858"}
            };

            cinemas.ForEach(s => context.Cinemas.Add(s));
            context.SaveChanges();
            var sessoes = new List<Sessao>
            {
            new Sessao{SessaoID=0,CinemaID=0,FilmeID=0,Horario=TimeSpan.Parse("19:00:00")},
            new Sessao{SessaoID=1,CinemaID=1,FilmeID=1,Horario=TimeSpan.Parse("20:00:00")},
            new Sessao{SessaoID=2,CinemaID=2,FilmeID=2,Horario=TimeSpan.Parse("21:00:00")},
            new Sessao{SessaoID=3,CinemaID=3,FilmeID=3,Horario=TimeSpan.Parse("22:00:00")},
            new Sessao{SessaoID=4,CinemaID=4,FilmeID=4,Horario=TimeSpan.Parse("23:00:00")},
            new Sessao{SessaoID=5,CinemaID=5,FilmeID=5,Horario=TimeSpan.Parse("00:00:00")},
            new Sessao{SessaoID=6,CinemaID=6,FilmeID=6,Horario=TimeSpan.Parse("01:00:00")},
            new Sessao{SessaoID=7,CinemaID=7,FilmeID=7,Horario=TimeSpan.Parse("02:00:00")},
            new Sessao{SessaoID=8,CinemaID=8,FilmeID=8,Horario=TimeSpan.Parse("03:00:00")},
            
            };
            sessoes.ForEach(s => context.Sessoes.Add(s));
            context.SaveChanges();
        }
    }
}