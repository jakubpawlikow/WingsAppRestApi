using System;
using System.Collections.Generic;
using System.Text;
using WingsAppDAL;
using System.Linq;
using WingsAppDAL.Entities;
using WingsAppBLL.BusinessObjects;
using WingsAppBLL.Converters;

namespace WingsAppBLL.Services
{
    class UserEventService : IUserEventService
    {
        UserEventConverter conv = new UserEventConverter();
        DALFacade facade;
        public UserEventService(DALFacade facade)
        {
            this.facade = facade;
        }
        //Create
        public UserEventBO Create(UserEventBO user_event)
        {
            using(var uow = facade.UnitOfWork)
            {
                var newEvent = uow.UserEventRepository.Create(conv.Convert(user_event));
                uow.Complete();
                return conv.Convert(newEvent);
            }
        }

        //Read
        public List<UserEventBO> GetAll()
        {
            using(var uow = facade.UnitOfWork)
            {
                return uow.UserEventRepository.GetAll().Select(ue => conv.Convert(ue)).ToList();
            }       
        }


        public UserEventBO Get(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.UserEventRepository.Get(Id));
            }
        }

        //Update
        public UserEventBO Update(UserEventBO user_event)        
        {
            using(var uow = facade.UnitOfWork)
            {
                var userEventFromDb = uow.UserEventRepository.Get(user_event.ID);
                if (userEventFromDb == null)
                {
                    throw new InvalidOperationException("User Event not found");
                }
                
                userEventFromDb.Title = user_event.Title;
                userEventFromDb.Description = user_event.Description;
                uow.Complete();
                return conv.Convert(userEventFromDb);
            }
        }

        //Delete
        public UserEventBO Delete(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                var deletedEvent = uow.UserEventRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(deletedEvent);
            }
        }
    }
}
