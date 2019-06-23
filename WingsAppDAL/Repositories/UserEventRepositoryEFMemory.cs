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
        public UserEvent Create(UserEvent userEvent)
        {
            if (userEvent.Reporter != null)
            {
                _context.Entry(userEvent.Reporter).State = EntityState.Unchanged;
            }
            _context.UserEvents.Add(userEvent);
            return userEvent;
        }

        //Read
        public List<UserEvent> GetAll()
        {
            return _context.UserEvents.ToList();
        }
        public UserEvent Get(int Id)
        {
            return _context.UserEvents.FirstOrDefault(obj => obj.Id == Id);
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
