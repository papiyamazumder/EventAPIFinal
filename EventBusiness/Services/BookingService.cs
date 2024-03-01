using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventData.Repository;
using EventEntity;

namespace EventBusiness.Services
{
    public class BookingService
    {
        private readonly IEventBooking _eventBooking1;
        public BookingService(IEventBooking eventBooking) {
            _eventBooking1 = eventBooking;
        
        }
        public bool AddBooking(EventBooking eventBooking)
        {
            return _eventBooking1.AddBooking(eventBooking); 
        }
        public bool RemoveBooking(int id)
        {
            return _eventBooking1.DeleteBooking(id);
        }
        public EventBooking GetBooking(int id)
        {
            return _eventBooking1.GetBooking(id);   
        }
        public IList<EventBooking> GetEvents()
        {
            return _eventBooking1.GetBooking();
        }
        public bool DeleteAll()
        {
            _eventBooking1.DeleteAll();
            return true;
        }
    }
}
