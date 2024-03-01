using System.Net.NetworkInformation;
using EventBusiness.Services;
using EventData.Repository;
using EventEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace EventAPI.Controllers
{
    /* 
     * REST API methods
     * HTTPGET,HTTPPOST,HTTPPUT,HTTTPDELET,HTTPPATCH
     */
    //Local host:5007 -upto this much is route
    //Local host:5007/api/Event
    [Authorize]
    [Route("api/[controller]")]//--class attribute,
    [ApiController]//--class attribute,supports REST API 
    //[ApiVersion("2.0")]
    public class EventController : ControllerBase
    {
       
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }
        [HttpPost]//-Method attribute, if we r not putting any attribute by default is HTTTPGET
        public IActionResult AddEvent(EventModel eventdata)// IActionResult-will accept any return type ex:list,object,etc
        {
            //log file

            _logger.Info("AddEvent Enetered..");

            var obj = new { status = "Inserted" };
            bool status = _eventService.AddEvent(eventdata);

            _logger.Info("AddEvent service method called..");
            _logger.Info("AddEvent service response:" + status);
            if (status)
            {
                _logger.Info("Add event methid response: OK");
                return Ok(obj);
            }
            else
            {
                _logger.Error("Addevent method response: BadReq");
                return BadRequest();

            }
           
        }

        [HttpGet("GetEvents")]
        public IActionResult GetEvent()
        {
            _logger.Info("AddEvent service enterd:");

            var Getsatus = _eventService.GetAll();
            _logger.Info("AddEvent service response:");

            return Ok(Getsatus);
        }
        [HttpGet("GetEventById")]
        public IActionResult GetEvent(int id)
        {
            var GetIdsatus = _eventService.GetEvent(id);
            return Ok(GetIdsatus);
        }
        [HttpPut("UpdateEvent")]
        public IActionResult UpdateEvent(EventModel eventdata) 
        { 
           bool Updatestatus =_eventService.UpdateEvent(eventdata);
            if (Updatestatus)
                return Ok(new { satus = "Updated" });
            else
                return BadRequest();
        }
        [HttpDelete("DeleteEvent")]
        public IActionResult DeleteEvent(int id)
        {
            bool Deletesatus = _eventService.DeleteEvent(id);
            if (Deletesatus)
                return Ok(new { satus = "Deleted" });
            else
                return BadRequest();
            
        }
    }
}
