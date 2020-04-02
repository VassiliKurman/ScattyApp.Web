using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ScattyApp.Web.Services;
using ScattyApp.Web.Models;

namespace ScattyApp.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public EventsController(JsonFileEventService eventService)
        {
            EventService = eventService;
        }

        public JsonFileEventService EventService { get; }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return EventService.GetEvents();
        }

        [Route("Complete")]
        [HttpPost]
        public ActionResult Get([FromQuery] long id)
        {
            EventService.AddCompleted(id);

            return Ok();
        }
    }
}