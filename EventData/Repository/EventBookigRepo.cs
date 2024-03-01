using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventData.DataContext;
using EventEntity;

namespace EventData.Repository
{
    public class EventBookigRepo:IEventBooking
    {
        private readonly EventDbContext _eventDbContext;
        public EventBookigRepo(EventDbContext eventDbContext)
        {
            _eventDbContext=eventDbContext;
        }
        public bool AddBooking(EventBooking eventBooking)
        {
            
            _eventDbContext.Add(eventBooking);
            _eventDbContext.SaveChanges();
            return true;
        }

        public bool DeleteBooking(int id)
        {
            EventBooking result = _eventDbContext.EventBooking.Find(id);
            _eventDbContext.Remove(result);
            _eventDbContext.SaveChanges();
            return (true);
        }
        
        public bool DeleteAll()
        {
          _eventDbContext.EventBooking.RemoveRange(_eventDbContext.EventBooking.ToList());
          return true;
         }

        public EventBooking GetBooking(int id)
        {
            EventBooking res = _eventDbContext.EventBooking.Find(id);
            return res;
        }

        public IList<EventBooking> GetBooking()
        {
            IList<EventBooking> list = _eventDbContext.EventBooking.ToList();
            return list;
        }

        public bool UpdateBooking(EventBooking eventBooking)
        {
            _eventDbContext.Entry(eventBooking).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _eventDbContext.SaveChanges();
            return true;

        }
        public IList<EventBooking> GetBookingsByStatus(string status)
        {
            IList<EventBooking> list = _eventDbContext.EventBooking.Where(obj => obj.satus == status).ToList();
            _eventDbContext.SaveChanges();
            return list;
        }
    }
}
