using WingsAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WingsAppDAL.UOW;

namespace WingsAppDAL
{
    public class DALFacade
    {
        public IUserEventRepository UserEventRepository
        { 
            get 
            { 
                return new UserEventRepositoryEFMemory(
                    new Context.InMemoryContext()
                ); 
            } 
        }

         public IUnitOfWork UnitOfWork
        { 
            get 
            { 
                return new UnitOfWorkMem(); 
            } 
        }
    }
}