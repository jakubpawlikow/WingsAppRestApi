using System;
using WingsAppDAL.Context;
using WingsAppDAL.Repositories;

namespace WingsAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IUserEventRepository UserEventRepository { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            UserEventRepository = new UserEventRepositoryEFMemory(context);
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