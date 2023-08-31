using AutoMapper;
using Chat.Application.Dtos.ActiveUser;
using Chat.Application.Hubs;
using Chat.Application.Interfaces;
using Chat.Application.Interfaces.Hubs;
using Chat.Application.Interfaces.Services;
using Chat.Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Services
{
    public class ActiveUserServices : IActiveUserServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ActiveUserServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateActiveUser(CreateActiveUserDto dto)
        {
            var model = _mapper.Map<ActiveUser>(dto);

            await _unitOfWork.ActiveUsers.CreateAsync(model);

            return true;
        }

        public async Task<GetActiveUserDto> GetActiveUserById(string id)
        {
            var _id = ObjectId.Parse(id);
            var fromDb = await _unitOfWork.ActiveUsers.GetByIdAsync(_id);

            var result = _mapper.Map<GetActiveUserDto>(fromDb);
            return result;
        }

        public async Task<IReadOnlyList<GetActiveUserDto>> GetAllActiveUsers()
        {
            var fromDb = await _unitOfWork.ActiveUsers.GetAllAsync();

            var results = _mapper.Map<IReadOnlyList<GetActiveUserDto>>(fromDb);
            return results;
        }

        public async Task<bool> RemoveActiveUser(string id)
        {
            var _id = ObjectId.Parse(id);

            var result = await _unitOfWork.ActiveUsers.DeleteAsync(_id);
            return result;
        }
    }
}
