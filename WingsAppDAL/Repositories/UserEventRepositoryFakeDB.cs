using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WingsAppDAL.Entities;

namespace WingsAppDAL.Repositories
{
    class UserEventRepositoryFakeDB : IUserEventRepository
    {
        private static int Id = 1;
        private static List<UserEvent> UserEvents = new List<UserEvent>();

        //Create
        public UserEvent Create(UserEvent user_event)
        {
             UserEvent newEvent;
             UserEvents.Add(newEvent = new UserEvent()
             {
                 ID = Id++,
                 Title = user_event.Title,
                 Description = user_event.Description,
             });
             return newEvent;
        }

        //Read
        public List<UserEvent> GetAll()
        {
            return new List<UserEvent>(UserEvents);
        }
        public UserEvent Get(int Id)
        {
            return UserEvents.FirstOrDefault(obj => obj.ID == Id);
        }

        //Delete
        public UserEvent Delete(int Id)
        {
            var user_event = Get(Id);
            UserEvents.Remove(user_event);
            return user_event;
        }
    }
}
