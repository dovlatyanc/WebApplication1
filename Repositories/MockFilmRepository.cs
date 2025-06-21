using MovieApi.Domain;

namespace MovieApi.Repositories
{
    public class MockFilmRepository : IFilmRepository
    {
        private static List<Film> _films = new List<Film>
        {
            new Film { Id = 1, Title = "Матрица"},
            new Film { Id = 2, Title = "Гладиатор"},
            new Film { Id = 3, Title = "Зеленая миля"},
            new Film { Id = 4, Title = "5 элемент"}

        };

        public IEnumerable<Film> GetAllFilms() => _films;
        public Film GetFilmById(int id) => _films.FirstOrDefault(f => f.Id == id);

        public void AddFilm(Film film)
        {
            film.Id = _films.Max(f => f.Id) + 1;
            _films.Add(film);
        }

        public void UpdateFilm(Film film)
        {
            var existing = _films.FirstOrDefault(f => f.Id == film.Id);
            if (existing != null)
            {
                existing.Title = film.Title;
                existing.Director = film.Director;
                existing.Style = film.Style;
                existing.Description = film.Description;
                existing.Sessions = film.Sessions;
            }
        }

        public void DeleteFilm(int id)
        {
            var film = _films.FirstOrDefault(f => f.Id == id);
            if (film != null)
            {
                _films.Remove(film);
            }
        }
    }
}
