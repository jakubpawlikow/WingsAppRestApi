using System;
using System.Collections.Generic;
using System.Text;

namespace WingsAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserEventRepository UserEventRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }

        int Complete();

    }
}
