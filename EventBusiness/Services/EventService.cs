using EventData.Repository;
using EventEntity;

namespace EventBusiness.Services
{
    public class EventService
    {

        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public bool AddEvent(EventModel eventdata)
        {
            bool status = _eventRepository.AddEvent(eventdata);
            return status;
        }
        public bool DeleteEvent(int id)
        {
            bool staus = _eventRepository.DeleteEvent(id);
            return staus;
        }
        public bool UpdateEvent(EventModel eventdata)
        {
            bool satus = _eventRepository.UpdateEvent(eventdata);
            return satus;
        }
        public IList<EventModel> GetAll()
        {
            return _eventRepository.GetEvents();
        }
        public EventModel GetEvent(int id)
        {
            return _eventRepository.GetEventModel(id);
        }
        public bool DeleteAll()
        {
            return _eventRepository.DeleteAll();
        }

    }
}
