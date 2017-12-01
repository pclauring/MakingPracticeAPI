using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPILab.Models;

namespace WebAPILab.Controllers
{
    public class MovieDBController : ApiController
    {

        [HttpGet]
        public List<Movy> GetMovies()
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

            return ORM.Movies.ToList();
        }

        [HttpGet]
        public List<Movy> GetMoviesByCategory(string Category)
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

            return ORM.Movies.Where(x => x.Category == Category).ToList();
        }

        [HttpGet]
        public Movy GetRandomMovie()
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

            Random random = new Random();

            List<Movy> movieList = ORM.Movies.ToList();

            Movy Choice = movieList[random.Next(movieList.Count)];

            return Choice;
        }

        [HttpGet]
        public Movy GetRandomMoviesFromCategory(string Category)
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

            Random random = new Random();

            List<Movy> movieList = ORM.Movies.Where(x => x.Category == Category).ToList();

            Movy Choice = movieList[random.Next(movieList.Count)];

            return Choice;

        }

        [HttpGet]
        public List<Movy> GetRandomMovieList(int Length)
        {
            MovieAppDBEntities ORM = new MovieAppDBEntities();

            Random random = new Random();

            List<Movy> movieList = ORM.Movies.ToList();
            List<Movy> randomList = new List<Movy>();
            int index = 0;
            while (Length > index)
            {
                randomList.Add(movieList[random.Next(movieList.Count)]);
                index++;
            }
            return randomList;

        }
    }
}
