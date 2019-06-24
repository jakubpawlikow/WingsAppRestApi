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
    class EventTypeService : IEventTypeService
    {
        EventTypeConverter conv = new EventTypeConverter();
        DALFacade facade;
        public EventTypeService(DALFacade facade)
        {
            this.facade = facade;
        }
        //Create
        public EventTypeBO Create(EventTypeBO eventType)
        {
            using(var uow = facade.UnitOfWork)
            {
                var newEventType = uow.EventTypeRepository.Create(conv.Convert(eventType));
                uow.Complete();
                return conv.Convert(newEventType);
            }
        }

        //Read
        public List<EventTypeBO> GetAll()
        {
            using(var uow = facade.UnitOfWork)
            {
                return uow.EventTypeRepository.GetAll().Select(et => conv.Convert(et)).ToList();
            }       
        }


        public EventTypeBO Get(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                var eventType = uow.EventTypeRepository.Get(Id);
                return conv.Convert(eventType);
            }
        }

        //Update
        public EventTypeBO Update(EventTypeBO eventType)        
        {
            using(var uow = facade.UnitOfWork)
            {
                var eventTypeFromDb = uow.EventTypeRepository.Get(eventType.Id);
                if (eventTypeFromDb == null)
                {
                    throw new InvalidOperationException("Event Type not found");
                }
                
                eventTypeFromDb.Name = eventType.Name;
                uow.Complete();
                return conv.Convert(eventTypeFromDb);
            }
        }

        //Delete
        public EventTypeBO Delete(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                var deletedEventType = uow.EventTypeRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(deletedEventType);
            }
        }
    }
}
