using Crest.Web.Models;
using Microsoft.AspNet.SignalR;
using Dapper;
using System.Data.SqlClient;
using System.Configuration;

namespace Crest.Web
{
	public class ErrorLogHub : Hub
	{
		public void LogError(Error errorToLog)
		{
            Error result = null;

			//save info to DB
            using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CrestDB"].ConnectionString))
            {
               result = connection.Insert<Error>(errorToLog);
            }

            Clients.All.broadcastMessage(result);
		}
	}
}