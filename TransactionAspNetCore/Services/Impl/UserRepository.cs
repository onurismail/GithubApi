using System;
using System.IO;
using System.Net;

namespace TransactionAspNetCore.Services
{

    public class UserRepository : IUserRepository
    {
        private string apiLink = "https://api.github.com/";
        private const string query = "{0}search/users?q=location:{1}&sort={2}&order={3}";

        public string GetGithubSearchUsersEndpoint(string location, string sort, string order)
        {
            return string.Format(query, apiLink, location, sort, order);
        }

        public string GetMostContributedUsers(string url)
        {
            HttpWebRequest request = InitializeRequest(url);
            
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, System.Text.Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();
                }
            }
            return String.Empty;
        }

        private static HttpWebRequest InitializeRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Headers.Add("user-agent", "C#");
            return request;
        }
    }
}
