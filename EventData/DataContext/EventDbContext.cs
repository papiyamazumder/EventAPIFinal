using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventEntity;
using Microsoft.EntityFrameworkCore;

namespace EventData.DataContext
{
    public class EventDbContext:DbContext 
    {
        //Connection Establishment
        //DbSet configure
        public EventDbContext(DbContextOptions<EventDbContext> options):base(options) 
        { 
            //connection Establishment
        }
        public DbSet<EventModel> EventModel { get; set; } // property type is DbSet(table)
        public DbSet<UserModel> UserModel { get; set; } 
        public DbSet<EventBooking> EventBooking { get; set; }
        //if we want to change anything we have to do it in .net .. if we did anychange in db it wont reflect
        //adding data,delete,insert
    }
}
