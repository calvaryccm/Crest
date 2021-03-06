﻿//using Crest.Client.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crest.Client
{
    public class CrestLogger
    {
        IHubProxy errorLogHubProxy;

        public CrestLogger()
        {
            var hubConnection = new HubConnection("http://www.contoso.com/");
            errorLogHubProxy = hubConnection.CreateHubProxy("ErrorLogHub");
            //errorLogHubProxy.On<Error>("LogError", error => { });
            hubConnection.Start().Wait();
        }

        public void LogError(Exception e) 
        {
            int thins = 9;
            errorLogHubProxy.Invoke("LogError", e);
        }

        public void LogWebError(Exception e, HttpClientException f)
        {
            errorLogHubProxy.Invoke("LogWebError", e);
        }
    }
}
