using Microsoft.AspNetCore.Mvc;
using sem_2_k_2.Application.Services;
using sem_2_k_2.Domain.Entities;

namespace sem_2_k_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly TournamentService _service;
        public TournamentsController(TournamentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Tournament>> Get() => await _service.GetTournamentsAsync();

        [HttpPost]
        public async Task<ActionResult<Tournament>> Post(Tournament t)
        {
            await _service.AddTournamentAsync(t);
            return CreatedAtAction(nameof(Post), new { id = t.Id }, t);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTournamentAsync(id);
            return NoContent();
        }
    }
}
