using Crest.Web.Models;
using Nancy;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Crest.Web.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                IEnumerable<Error> result = null;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CrestDB"].ConnectionString))
                {
                    result = connection.GetList<Error>("SELECT TOP 20 * FROM Errors");
                }

                return View["index", result];
            };
        }
    }
}