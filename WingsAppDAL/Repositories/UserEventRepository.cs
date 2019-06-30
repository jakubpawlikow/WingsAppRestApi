using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using WingsAppDAL.Context;
using WingsAppDAL.Entities;

namespace WingsAppDAL.Repositories
{
    class UserEventRepository : IUserEventRepository
    {
        WingsAppContext  _context;

        public UserEventRepository(WingsAppContext context)
        {
            _context = context;
        }
        //Create
        public UserEvent Create(UserEvent userEvent)
        {
            _context.UserEvents.Add(userEvent);
            return userEvent;
        }

        //Read
        public List<UserEvent> GetAll()
        {
            return _context.UserEvents
                    .Include(ue => ue.Assigners)
                    .ToList();
        }
        public UserEvent Get(int Id)
        {
            return _context.UserEvents.Include(ue => ue.Assigners).FirstOrDefault(obj => obj.Id == Id);
        }

        //Delete
        public UserEvent Delete(int Id)
        {
            var userEvent = Get(Id);
            _context.UserEvents.Remove(userEvent);
            return userEvent;
        }
    }
}
