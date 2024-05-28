using Core;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;


namespace Business.Services
{
    public class UserServices : BaseTest
    {
        private readonly RestClient client = new("https://jsonplaceholder.typicode.com");

        public RestResponse GetUsers(string source)
        {
            Log.Info("Create and send Get request");
            var request = new RestRequest(source, Method.Get);
            var response = client.Get(request);

            return response;
        }

        public RestResponse AddUser(string source)
        {

            Log.Info("Create and send request");
            var request = new RestRequest(source, Method.Post);
            request.AddJsonBody(new { name = "John Doe", username = "JohnDoe" });

            var response = client.Post(request);
            var userData = JsonConvert.DeserializeObject<dynamic>(response.Content);
            Console.WriteLine("User data: " + userData?.ToString());
            Console.WriteLine("HttpStatusCode: " + response.StatusCode);

            return response;
        }

        public static void ValidateOkResponse(RestResponse response)
        {
            Log.Info("Validate the HTTP response code equals to OK");
            Console.WriteLine("HttpStatusCode: " + response.StatusCode);
        }

        public static void FindContentTypeHeader(RestResponse response)
        {

            Log.Info("Find the Content-Type header");
            Console.WriteLine("Response Headers:");
            foreach (var header in response.ContentHeaders)
            {
                Console.WriteLine($"{header.Name}: {header.Value}");
            }

            Parameter? contentTypeHeader = null;
            foreach (var header in response.ContentHeaders)
            {
                if (header.Name.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                {
                    contentTypeHeader = header;
                    break;
                }
            }
            Log.Info("Validate that Content-Type Header value equals to 'application/json; charset=utf-8'");
            Assert.That(actual: contentTypeHeader.Value.ToString(), expression: Is.EqualTo("application/json; charset=utf-8"), message: "Unexpected value of Content-Type header");
        }
    }
}