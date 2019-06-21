using WingsAppDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using WingsAppDAL.UOW;

namespace WingsAppDAL
{
    public class DALFacade
    {
         public IUnitOfWork UnitOfWork
        { 
            get 
            { 
                return new UnitOfWork(); 
            } 
        }
    }
}