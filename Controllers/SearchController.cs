using Microsoft.AspNetCore.Mvc;
using MovieApi.Domain;
using MovieApi.Repositories;

namespace MovieApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly IFilmRepository _repository;

    public SearchController(IFilmRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("films")]
    public ActionResult<IEnumerable<Film>> SearchFilms([FromQuery] string query)
    {
        var results = _repository.Search(query);
        return Ok(results);
    }

    [HttpGet("sessions")]
    public ActionResult<IEnumerable<Session>> GetAllSessions()
    {
        var sessions = _repository.GetAllSessions();
        return Ok(sessions);
    }
}
