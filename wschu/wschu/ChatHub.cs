using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace wschu
{
  public class ChatHub :Hub
  {
    public Task JoinGroup(string groupName)
    {
      return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public Task SendMessageToGroup(string user, string groupName, string message)
    {
      return Clients.Group(groupName).SendCoreAsync("ReceiveGroupMessage", new object[]{ $"{user} : {message} \n"});
    }
  }
}
