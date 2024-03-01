using EventBusiness.Services;
using EventEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;
        public BookingController(BookingService bookingService)
        { 
          _bookingService = bookingService;
        }

        [HttpPost]
        public bool AddBooking(EventBooking booking)
        {
            return _bookingService.AddBooking(booking);
        }
        [HttpDelete("DeleteById")]
        public bool DeleteBooking(int id)
        {
            return _bookingService.RemoveBooking(id);
        }
        [HttpPut]
        public bool PutBooking(EventBooking booking)
        {
            return _bookingService.AddBooking(booking);
        }
        [HttpGet("getAll")]
        public IList<EventBooking> GetBooking()
        {
            return _bookingService.GetEvents();
        }
        [HttpGet("getbookById")]
        public EventBooking GetBookings(int id)
        {
            return _bookingService.GetBooking(id);
        }
        [HttpDelete("DeleteAll")]
        public bool DeleteAll()
        {
            return _bookingService.DeleteAll();
        }
    }
}
