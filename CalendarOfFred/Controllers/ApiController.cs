using CalendarOfFred.Models;
using CalendarOfFred.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalendarOfFred.Controllers
{
    [Route("api/dates")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public IEventRepository eventRepository { get; private set; }

        public ApiController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        // GET: api/dates
        [HttpGet]
        public IEnumerable<Event> Get([FromQuery] DateTime? start = null, [FromQuery] DateTime? end = null)
        {
            return this.eventRepository.GetEvents(start, end);
        }
    }
}
