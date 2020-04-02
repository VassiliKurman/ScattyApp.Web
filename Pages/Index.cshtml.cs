using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ScattyApp.Web.Services;
using ScattyApp.Web.Models;

namespace ScattyApp.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileEventService EventService;
        public IEnumerable<Event> Events { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileEventService eventService)
        {
            _logger = logger;
            EventService = eventService;
        }

        public void OnGet()
        {
            Events = EventService.GetEvents();
        }
    }
}
