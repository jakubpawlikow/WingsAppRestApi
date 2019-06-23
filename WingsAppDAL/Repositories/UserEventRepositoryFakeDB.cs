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
        public UserEvent Create(UserEvent userEvent)
        {
             UserEvent newEvent;
             UserEvents.Add(newEvent = new UserEvent()
             {
                 Id = Id++,
                 Title = userEvent.Title,
                 Description = userEvent.Description,
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
            return UserEvents.FirstOrDefault(obj => obj.Id == Id);
        }

        //Delete
        public UserEvent Delete(int Id)
        {
            var userEvent = Get(Id);
            UserEvents.Remove(userEvent);
            return userEvent;
        }
    }
}
