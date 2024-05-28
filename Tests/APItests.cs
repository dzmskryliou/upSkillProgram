using Business.Data;
using Business.Services;
using Newtonsoft.Json;
using RestSharp;

namespace Tests
{

    public class UserAPITests : UserServices
    {

        [Test]
        public void TestGetListOfUsers()
        {
            Log.Info("Hello. This is the beginning of Test GetListOfUsers");

            var userServices = new UserServices();
            var response = userServices.GetUsers("/users");
            Console.WriteLine(response.Content);

            Assert.That(response.Content, Does.Contain("id"));
            Assert.That(response.Content, Does.Contain("name"));
            Assert.That(response.Content, Does.Contain("username"));
            Assert.That(response.Content, Does.Contain("email"));
            Assert.That(response.Content, Does.Contain("address"));
            Assert.That(response.Content, Does.Contain("phone"));
            Assert.That(response.Content, Does.Contain("website"));
            Assert.That(response.Content, Does.Contain("company"));

            ValidateOkResponse(response);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }


        [Test]
        public void TestValidateResponseHeader()
        {
            var userServices = new UserServices();
            var response = userServices.GetUsers("/users");

            FindContentTypeHeader(response);

            ValidateOkResponse(response);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
        }


        [Test]
        public async Task TestUsersContainCompany()
        {
            var userServices = new UserServices();
            var response = userServices.GetUsers("/users");

            ValidateOkResponse(response);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var responseBody = response.Content.ToString();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(responseBody);

            Assert.That(users, Has.Count.EqualTo(10), "The number of users is not 10");
            Assert.That(users.Select(user => user.Id).Distinct().Count(), Is.EqualTo(users.Count), "Not all users have unique IDs");

            foreach (var user in users)
            {
                Log.Info("Validating that each user should be with non-empty Name");
                Assert.That(string.IsNullOrWhiteSpace(user.Name), Is.False, $"User with ID {user.Id} has an empty Name");

                Log.Info("Validating that each user should be with non-empty Username");
                Assert.That(string.IsNullOrWhiteSpace(user.Username), Is.False, $"User with ID {user.Id} has an empty Username");

                Log.Info("Validating that each user contains the Company with non-empty");
                Assert.That(string.IsNullOrWhiteSpace(user.Company.Name), Is.False, $"User with ID {user.Id} has an empty Company Name");
            }
        }


        [Test]
        public void TestCreateUser()
        {
            Log.Info("Hello. This is the beginning of Test CreateUser");

            var userServices = new UserServices();
            var response = userServices.AddUser("/users");

            Log.Info("Validate that response is not empty and contains the ID value");
            Assert.That(response.Content, Is.Not.Null, "Response content should not be empty.");

            Log.Info("Validate that user receives 201 Created response code. There are no error messages");
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created), "Expected 201 Created response code.");

            Assert.That(response.Content, Does.Not.Contain("error"), "Response should not contain error message.");
        }


        [Test]
        public void TestResourceNotFound()
        {
            var userServices = new UserServices();
            var response = userServices.GetUsers("/invalidEndPoint");

            Log.Info("Validating that user receives 404 Not Found response code.");
            ValidateOkResponse(response);
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound), "Expected response code: 404 Not Found");

            Log.Info("Validating that there are no error messages");
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            // Assert.That(response.ErrorMessage, Is.Null, "Error message should be null for 404 response");
        }
    }
}
