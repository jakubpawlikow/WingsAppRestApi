using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WingsAppDAL.Context;
using WingsAppDAL.Entities;

namespace WingsAppDAL.Repositories
{
    class EventTypeRepository : IEventTypeRepository
    {
        WingsAppContext  _context;

        public EventTypeRepository(WingsAppContext context)
        {
            _context = context;
        }
        //Create
        public EventType Create(EventType eventType)
        {
            _context.EventTypes.Add(eventType);
            return eventType;
        }

        //Read
        public List<EventType> GetAll()
        {
            return _context.EventTypes.ToList();
        }
        public EventType Get(int Id)
        {
            return _context.EventTypes.FirstOrDefault(obj => obj.Id == Id);
        }

        //Delete
        public EventType Delete(int Id)
        {
            var eventType = Get(Id);
            _context.EventTypes.Remove(eventType);
            return eventType;
        }
    }
}
