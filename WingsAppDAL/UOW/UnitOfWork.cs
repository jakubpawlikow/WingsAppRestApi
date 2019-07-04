using System;
using WingsAppDAL.Context;
using WingsAppDAL.Repositories;

namespace WingsAppDAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserEventRepository UserEventRepository { get; internal set; }
        public IUserProfileRepository UserProfileRepository { get; internal set; }
        private WingsAppContext _context;

        public UnitOfWork()
        {
            _context = new WingsAppContext();
            _context.Database.EnsureCreated();
            UserEventRepository = new UserEventRepository(_context);
            UserProfileRepository = new UserProfileRepository(_context);
        }

        public int Complete()
        {
            // Number of objects written to the underlying database
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}