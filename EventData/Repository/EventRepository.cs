using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventData.DataContext;
using EventEntity;
using Microsoft.EntityFrameworkCore;


namespace EventData.Repository
{
    public class EventRepository : IEventRepository // click on the interface name and Ctrl+. 
    {
        private readonly EventDbContext _eventDbContext;
        public EventRepository(EventDbContext eventDbContext) 
        {
            _eventDbContext = eventDbContext;
        }
        
        public bool AddEvent(EventModel eventdata)
        {
            //insert into eventmodel values('','','')
            _eventDbContext.EventModel.Add(eventdata);
            //execute sql satement
            _eventDbContext.SaveChanges();
            return true;    
        }

        public bool DeleteEvent(int id)
        {
            EventModel eventmodel=_eventDbContext.EventModel.Find(id);//find is Select
            _eventDbContext.EventModel.Remove(eventmodel);//remove is delete
            _eventDbContext.SaveChanges() ; // this will there after any modification - madatory
            return true;

        }

        public EventModel GetEventModel(int id)
        {
            EventModel eventmodel = _eventDbContext.EventModel.Find(id);
            return eventmodel;
        }

        public IList<EventModel> GetEvents()
        {
            //select * from eventmodel
           IList<EventModel> list = _eventDbContext.EventModel.ToList();
           
            return list;
        }
        public bool UpdateEvent(EventModel eventdata)
        {

            //update eventmodel set name=evenetData.Name,type=eventdat.Type where id=evenetdata.id
            _eventDbContext.Entry(eventdata).State = EntityState.Modified;//or Microsoft.EntityFrameworkCore.EntityState.Modified;
            _eventDbContext.SaveChanges();//commit
            return true;

        }
        public bool DeleteAll()
        {
            _eventDbContext.EventModel.RemoveRange(_eventDbContext.EventModel.ToList());
            return true;
        }
    }
}
