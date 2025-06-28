using MovieApi.Domain;

namespace MovieApi.Repositories
{
    public interface IFilmRepository
    {
        IEnumerable<Film> GetAllFilms();
        Film GetFilmById(int id);
        void AddFilm(Film film);
        void UpdateFilm(Film film);
        void DeleteFilm(int id);

        // Методы поиска
        IEnumerable<Film> Search(string query);
        IEnumerable<Session> GetAllSessions();
    }
}
