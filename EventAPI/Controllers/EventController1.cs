using EventBusiness.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/{v:ApiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class EventController1 : ControllerBase
    {
        private readonly EventService _eventService;
        public EventController1(EventService eventService) {
            _eventService = eventService;
        }
        [HttpDelete]

        public bool DeleteAll()
        {
            return _eventService.DeleteAll();
        }
    }
}
