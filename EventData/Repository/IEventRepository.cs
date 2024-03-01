using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventEntity;

namespace EventData.Repository  // project name.foldername
{
    public interface IEventRepository // make this interface public 
    {
        bool AddEvent(EventModel eventdata); // object type
        bool UpdateEvent(EventModel eventdata);
        bool DeleteEvent(int id);

        EventModel GetEventModel(int id); // the event model is created in the entity layer but we are accesing in this project by unables project referece
        IList<EventModel> GetEvents();

        bool DeleteAll();

    }
}
