using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventEntity;

namespace EventData.Repository
{
    public interface IEventBooking
    {
        bool AddBooking(EventBooking eventBooking);
        bool DeleteBooking(int id);
        bool DeleteAll();
        bool UpdateBooking(EventBooking eventBooking);
        EventBooking GetBooking(int id);
        IList<EventBooking> GetBooking();

        IList<EventBooking> GetBookingsByStatus(string satus);
    }
}
