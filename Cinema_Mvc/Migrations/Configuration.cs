namespace Cinema_Mvc.Migrations
{
    using Cinema_Mvc.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cinema_Mvc.DAL.CinemaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Cinema_Mvc.DAL.CinemaContext context)
        {
            var filmes = new List<Filme>
            {
            new Filme{Nome = "Avengers", Genero = "Ação", Duracao = 120, Classificacao = 14},
            new Filme{Nome = "Black Panther", Genero = "Ação", Duracao = 240, Classificacao = 14},
            new Filme{Nome = "Spider-Man", Genero = "Ação", Duracao = 110, Classificacao = 10},
            new Filme{Nome = "Bohemian Rhapsody", Genero = "Drama", Duracao = 100, Classificacao = 18},
            new Filme{Nome = "Roma", Genero = "Suspense", Duracao = 120, Classificacao = 16},
            new Filme{Nome = "Coco", Genero = "Comedia", Duracao = 140, Classificacao = 10},
            new Filme{Nome = "Happy Death Day", Genero = "Comedia/Terror", Duracao = 120, Classificacao = 14},
            new Filme{Nome = "Guardians of the Galaxy", Genero = "Ação", Duracao = 130, Classificacao = 10},
            new Filme{Nome = "Inception", Genero = "Suspense/Terror", Duracao = 200, Classificacao = 18}
            };

            filmes.ForEach(s => context.Filmes.Add(s));
            context.SaveChanges();

            var cinemas = new List<Cinema>
            {
            new Cinema{Nome = "Cinepolis", Endereco = "Rua Sabia, 850"},
            new Cinema{Nome = "Cinemark", Endereco = "Rua Arara, 851"},
            new Cinema{Nome = "Cinesia", Endereco = "Rua Tucano, 852"},
            new Cinema{Nome = "SpCine", Endereco = "Rua Avestruz, 853"},
            new Cinema{Nome = "CINUSP", Endereco = "Rua Tucunara, 854"},
            new Cinema{Nome = "Kinoplex", Endereco = "Rua Falcao, 855"},
            new Cinema{Nome = "Cinemark", Endereco = "Rua Beija-Flor, 856"},
            new Cinema{Nome = "Cinelive", Endereco = "Rua Pica-pau, 857"},
            new Cinema{Nome = "CINE", Endereco = "Rua Aguia de rapina, 858"}
            };

            cinemas.ForEach(s => context.Cinemas.Add(s));
            context.SaveChanges();

            var sessoes = new List<Sessao>
            {
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "CINE").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Bohemian Rhapsody").FilmeId,
                    Horario = TimeSpan.Parse("19:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "Cinepolis").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Guardians of the Galaxy").FilmeId,
                    Horario = TimeSpan.Parse("20:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "Cinepolis").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Avengers").FilmeId,
                    Horario = TimeSpan.Parse("21:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "SpCine").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Black Panther").FilmeId,
                    Horario = TimeSpan.Parse("22:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "Cinelive").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Black Panther").FilmeId,
                    Horario = TimeSpan.Parse("23:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "SpCine").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Roma").FilmeId,
                    Horario = TimeSpan.Parse("00:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "Kinoplex").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Happy Death Day").FilmeId,
                    Horario = TimeSpan.Parse("01:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "Kinoplex").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Coco").FilmeId,
                    Horario = TimeSpan.Parse("02:00")
                },
                new Sessao
                {
                    CinemaID = cinemas.Single(c => c.Nome == "Kinoplex").CinemaID,
                    FilmeID = filmes.Single(f => f.Nome == "Spider-Man").FilmeId,
                    Horario = TimeSpan.Parse("03:00")
                }

            };

            sessoes.ForEach(s => context.Sessoes.Add(s));
            context.SaveChanges();

        }
    }
}
