using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WingsAppDAL.Context;
using WingsAppDAL.Entities;

namespace WingsAppDAL.Repositories
{
    class UserEventRepositoryEFMemory : IUserEventRepository
    {
        WingsAppContext  _context;

        public UserEventRepositoryEFMemory(WingsAppContext context)
        {
            _context = context;
        }
        //Create
        public UserEvent Create(UserEvent user_event)
        {
            if (user_event.Reporter != null)
            {
                _context.Entry(user_event.Reporter).State = EntityState.Unchanged;
            }
            _context.UserEvents.Add(user_event);
            return user_event;
        }

        //Read
        public List<UserEvent> GetAll()
        {
            return _context.UserEvents.Include(ue => ue.Reporter).ToList();
        }
        public UserEvent Get(int Id)
        {
            return _context.UserEvents.FirstOrDefault(obj => obj.ID == Id);
        }

        //Delete
        public UserEvent Delete(int Id)
        {
            var user_event = Get(Id);
            _context.UserEvents.Remove(user_event);
            return user_event;
        }
    }
}
