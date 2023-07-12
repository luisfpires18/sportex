namespace Sportex.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sportex.Application.Service;
    using Sportex.Domain.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService eventService)
        {
            this.playerService = eventService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var events = this.playerService.GetAll();

            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var e = this.playerService.GetPlayerById(id);

            if (e == null)
            {
                return NotFound();
            }

            return Ok(e);
        }

        [HttpPost]
        public IActionResult SearchPlayers([FromBody] string searchQuery)
        {
            IEnumerable<Player> events = new List<Player>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                events = this.playerService.SearchPlayers(searchQuery);
            }

            return new JsonResult(events);
        }
    }
}