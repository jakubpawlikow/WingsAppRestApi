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
    class UserProfileService : IUserProfileService
    {
        UserProfileConverter conv = new UserProfileConverter();
        private DALFacade facade;
        public UserProfileService(DALFacade facade)
        {
            this.facade = facade;
        }
        //Create
        public UserProfileBO Create(UserProfileBO user_profile)
        {
            using(var uow = facade.UnitOfWork)
            {
                var newProfile = uow.UserProfileRepository.Create(conv.Convert(user_profile));
                uow.Complete();
                return conv.Convert(newProfile);
            }
        }

        //Read
        public List<UserProfileBO> GetAll()
        {
            using(var uow = facade.UnitOfWork)
            {
                return uow.UserProfileRepository.GetAll().Select(up => conv.Convert(up)).ToList();
            }       
        }


        public UserProfileBO Get(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.UserProfileRepository.Get(Id));
            }
        }

        //Update
        public UserProfileBO Update(UserProfileBO user_profile)        
        {
            using(var uow = facade.UnitOfWork)
            {
                var userProfileFromDb = uow.UserProfileRepository.Get(user_profile.Id);
                if (userProfileFromDb == null)
                {
                    throw new InvalidOperationException("User Profile not found");
                }
                
                userProfileFromDb.FirstName = user_profile.FirstName;
                userProfileFromDb.LastName = user_profile.LastName;
                userProfileFromDb.JoinDate = user_profile.JoinDate;
                uow.Complete();
                return conv.Convert(userProfileFromDb);
            }
        }

        //Delete
        public UserProfileBO Delete(int Id)
        {
            using(var uow = facade.UnitOfWork)
            {
                var deletedProfile = uow.UserProfileRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(deletedProfile);
            }
        }
    }
}
