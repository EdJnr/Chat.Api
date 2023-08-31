using Chat.Application.Interfaces.Repositories;
using Chat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<ActiveUser> ActiveUsers { get; }

        void Dispose();
    }
}
