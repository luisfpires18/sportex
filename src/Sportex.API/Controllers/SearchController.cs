namespace Sportex.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sportex.Application.Service;
    using Sportex.Domain.Model;

    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService eventService)
        {
            this.activityService = eventService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var events = this.activityService.GetAll();

            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var e = this.activityService.GetActivityById(id);

            if (e == null)
            {
                return NotFound();
            }

            return Ok(e);
        }

        [HttpPost]
        public IActionResult SearchActivitys([FromBody] string searchQuery)
        {
            IEnumerable<Activity> events = new List<Activity>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                events = this.activityService.SearchActivitys(searchQuery);
            }

            return new JsonResult(events);
        }
    }
}