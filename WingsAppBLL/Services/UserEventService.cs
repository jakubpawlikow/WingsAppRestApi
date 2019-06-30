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
        UserEventConverter uEConv = new UserEventConverter();
        UserProfileConverter uPConv = new UserProfileConverter();
        DALFacade facade;
        public UserEventService(DALFacade facade)
        {
            this.facade = facade;
        }
        //Create
        public UserEventBO Create(UserEventBO userEvent)
        {
            using(var uow = facade.UnitOfWork)
            {
                var newEvent = uow.UserEventRepository.Create(uEConv.Convert(userEvent));
                uow.Complete();
                return uEConv.Convert(newEvent);
            }
        }

        //Read
        public List<UserEventBO> GetAll()
        {
            using(var uow = facade.UnitOfWork)
            {
                return uow.UserEventRepository.GetAll().Select(ue => uEConv.Convert(ue)).ToList();
            }       
        }


        public UserEventBO Get(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                var result = uEConv.Convert(uow.UserEventRepository.Get(Id));
                result.Reporter = uPConv.Convert(uow.UserProfileRepository.Get(result.ReporterId));
                result.Assigners = uow.UserProfileRepository.GetAllById(result.AssignersIds).Select(up => uPConv.Convert(up)).ToList();
                return result;
            }
        }

        //Update
        public UserEventBO Update(UserEventBO userEvent)        
        {
            using(var uow = facade.UnitOfWork)
            {
                var userEventFromDb = uow.UserEventRepository.Get(userEvent.Id);
                if (userEventFromDb == null)
                {
                    throw new InvalidOperationException("User Event not found");
                }
                var userEventUpdated = uEConv.Convert(userEvent);
                userEventFromDb.Title = userEventUpdated.Title;
                userEventFromDb.Description = userEventUpdated.Description;
                userEventFromDb.ReporterId = userEventUpdated.ReporterId;
                uow.Complete();
                userEventFromDb.Reporter = uow.UserProfileRepository.Get(userEventUpdated.ReporterId);
                return uEConv.Convert(userEventFromDb);
            }
        }

        //Delete
        public UserEventBO Delete(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                var deletedEvent = uow.UserEventRepository.Delete(Id);
                uow.Complete();
                return uEConv.Convert(deletedEvent);
            }
        }
    }
}
