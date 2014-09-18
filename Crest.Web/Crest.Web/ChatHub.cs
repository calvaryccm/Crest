﻿using Microsoft.AspNet.SignalR;

namespace Crest.Web
{
	public class ChatHub : Hub
	{
		public void Send(string name, string message)
		{
			Clients.All.broadcastMessage(name, message);
		}
	}
}