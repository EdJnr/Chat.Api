using Chat.Application.Interfaces;
using Chat.Application.Interfaces.Repositories;
using Chat.Domain.Entities;
using Chat.Infrastructure.Persistence.Repositories;

namespace Chat.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository<ActiveUser> ActiveUsers => new BaseRepository<ActiveUser>("ActiveUsers");

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
