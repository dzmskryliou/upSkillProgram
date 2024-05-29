using Business.Data;
using Core;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;


namespace Business.Services
{
    public class UserServices : logger
    {
        private readonly RestClient client = new("https://jsonplaceholder.typicode.com");

        public RestResponse GetUsers(string source)
        {
            Log.Info("Create and send Get request" );
            var request = new RestRequest(source, Method.Get);
            var response = client.Get(request);
            Log.Info("HttpStatusCode: " + response.StatusCode);

            return response;
        }

        public RestResponse AddUser(string source)
        {

            Log.Info("Create and send Post request");
            var request = new RestRequest(source, Method.Post);
            request.AddJsonBody(new { name = "John Doe", username = "JohnDoe" });

            var response = client.Post(request);
            var userData = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine("User data: " + userData?.ToString());
            Console.WriteLine("HttpStatusCode: " + response.StatusCode);

            return response;
        }
    }
}