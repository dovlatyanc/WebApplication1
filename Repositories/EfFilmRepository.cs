using Microsoft.EntityFrameworkCore;
using MovieApi.Domain;
using MovieApi.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MovieApi.Repositories
{
    public class EfFilmRepository : IFilmRepository
    {
        private readonly AppDbContext context;

        public EfFilmRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return context.Films
                .Include(f => f.Sessions)
                .ToList();
        }

        public Film GetFilmById(int id)
        {
            return context.Films
                .Include(f => f.Sessions)
                .FirstOrDefault(f => f.Id == id);
        }

        public void AddFilm(Film film)
        {
            context.Films.Add(film);
            context.SaveChanges();
        }

        public void UpdateFilm(Film film)
        {
            context.Entry(film).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteFilm(int id)
        {
            var film = context.Films.Find(id);
            if (film != null)
            {
                context.Films.Remove(film);
                context.SaveChanges();
            }
        }

        public IEnumerable<Film> Search(string query)
        {
            var lowerQuery = query.ToLower();

            return context.Films
                .Include(f => f.Sessions)
                .Where(f =>
                    f.Title.ToLower().Contains(lowerQuery) ||
                    f.Director.ToLower().Contains(lowerQuery) ||
                    f.Style.ToLower().Contains(lowerQuery) ||
                    f.Description.ToLower().Contains(lowerQuery) ||
                    f.Sessions.Any(s => s.Time.ToString().Contains(query))
                ).ToList();
        }

        public IEnumerable<Session> GetAllSessions()
        {
            return context.Sessions
                .Include(s => s.Film)
                .ToList();
        }
    }
}