using Chat.Application.Dtos.ActiveUser;
using Chat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Interfaces.Services
{
    public interface IActiveUserServices
    {
        Task<IReadOnlyList<GetActiveUserDto>> GetAllActiveUsers();

        Task<GetActiveUserDto> GetActiveUserById(string id);

        Task<bool> CreateActiveUser(CreateActiveUserDto dto);

        Task<bool> RemoveActiveUser(string Id);
    }
}
