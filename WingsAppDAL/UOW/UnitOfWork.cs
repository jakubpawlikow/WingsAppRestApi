using System;
using WingsAppDAL.Context;
using WingsAppDAL.Repositories;

namespace WingsAppDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserEventRepository UserEventRepository { get; internal set; }
        public IUserProfileRepository UserProfileRepository { get; internal set; }
        private WingsAppContext context;

        public UnitOfWork()
        {
            context = new WingsAppContext();
            UserEventRepository = new UserEventRepository(context);
            UserProfileRepository = new UserProfileRepository(context);
        }

        public int Complete()
        {
            // Number of objects written to the underlying database
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}