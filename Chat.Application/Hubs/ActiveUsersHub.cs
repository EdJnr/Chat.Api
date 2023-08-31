using Chat.Application.Interfaces;
using Chat.Application.Interfaces.Hubs;
using Chat.Application.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;


namespace Chat.Application.Hubs
{
    public class ActiveUsersHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActiveUsersHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task OnConnectedAsync()
        {
            // Retrieve data from the database
            var AllActive = await _unitOfWork.ActiveUsers.GetAllAsync();

            await Clients.All.SendAsync("GetActiveUsers", AllActive);
            //return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Retrieve data from the database
            var AllActive = await _unitOfWork.ActiveUsers.GetAllAsync();

            await Clients.All.SendAsync("GetActiveUsers", AllActive);
            //return base.OnDisconnectedAsync(exception);
        }
    }
}
