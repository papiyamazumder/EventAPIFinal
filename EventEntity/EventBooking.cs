using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;//while using foreinkey,uniquekey etc
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventEntity
{
    public class EventBooking
    {
        //create table t1(id int,eventid int refereces eventmodel(id),
        public int Id { get; set; }//Pk

//-------------------------------------------------------------------------------------------------------
  //foreignKey setup
        [ForeignKey("eventModel")]
        public int EventId { get; set; }//FK
        public EventModel? eventModel { get; set; }//reference table for foreignkey EventId

        //?-meaning is i can be nullable column we can pass null value,nullable type

//-------------------------------------------------------------------------------------------------------
        [ForeignKey("usermodel")]
        public int UserId { get; set; }//FK
        public UserModel? usermodel { get; set; }//reference table for foreignkey UserID
//------------------------------------------------------------------------------------------------------

        public string EventDate {  get; set; }
        public string satus {  get; set; }

    }
}
