using Microsoft.AspNetCore.Mvc;
using MovieApi.Domain;
using MovieApi.Repositories;
using System.Collections.Generic;

namespace MovieApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _repository;

        public FilmsController(IFilmRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Film>> GetAll()
        {
            return Ok(_repository.GetAllFilms());
        }

        [HttpGet("{id}")]
        public ActionResult<Film> GetById(int id)
        {
            var film = _repository.GetFilmById(id);
            if (film == null)
                return NotFound();
            return Ok(film);
        }

        [HttpPost]
        public ActionResult<Film> Create([FromBody] Film film)
        {
            _repository.AddFilm(film);
            return CreatedAtAction(nameof(GetById), new { id = film.Id }, film);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Film film)
        {
            if (film.Id != id)
                return BadRequest();

            _repository.UpdateFilm(film);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeleteFilm(id);
            return NoContent();
        }
    }
}