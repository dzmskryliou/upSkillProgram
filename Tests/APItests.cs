using Business.Data;
using Business.Services;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics.CodeAnalysis;

namespace Tests
{

    public class UserAPITests : UserServices
    {
        UserServices userServices = new UserServices();

        [Test]
        public void TestGetListOfUsers()
        {
            Log.Info("Hello. This is the beginning of Test GetListOfUsers");

            var response = userServices.GetUsers("/users");
            //Console.WriteLine(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var responseBody = response.Content.ToString();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(responseBody);

            Assert.That(users.All(user => user.Name != null), Is.True, "user does not contain Name");
            Assert.That(users.All(user => user.Username != null), Is.True, "user does not contain Username");
            Assert.That(users.All(user => user.email != null), Is.True, "user does not contain email");
            Assert.That(users.All(user => user.Address != null), Is.True, "user does not contain Address");
            Assert.That(users.All(user => user.Phone != null), Is.True, "user does not contain Phone");
            Assert.That(users.All(user => user.Website != null), Is.True, "user does not contain Website");
            Assert.That(users.All(user => user.Company != null), Is.True, "user does not contain Company");  
        }


        [Test]
        public void TestValidateResponseHeader()
        {
            var response = userServices.GetUsers("/users");

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var headerType = response.ContentHeaders.Where(headerType => headerType.Name == "Content-Typ");
            Assert.That(headerType, Is.Not.Null);  
        }


        [Test]
        public async Task TestUsersContainCompany()
        {
            var response = userServices.GetUsers("/users");

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));

            var responseBody = response.Content.ToString();
            List<User> users = JsonConvert.DeserializeObject<List<User>>(responseBody);

            Assert.That(users, Has.Count.EqualTo(10), "The number of users is not 10");
            Assert.That(users.Select(user => user.Id).Distinct().Count(), Is.EqualTo(users.Count), "Not all users have unique IDs");
            Assert.That(users.All(user => user.Name != null), Is.True, "user does not contain Name");
            Assert.That(users.All(user => user.Username != null), Is.True, "user does not contain Username");
            Assert.That(users.All(user => user.Company.Name != null), Is.True, "user does not contain Company Name");
        }


        [Test]
        public void TestCreateUser()
        {
            Log.Info("Hello. This is the beginning of Test CreateUser");

            var response = userServices.AddUser("/users");

            Assert.That(response.Content, Is.Not.Null, "Response content should not be empty.");
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created), "Expected 201 Created response code.");
            Assert.That(response.Content, Does.Not.Contain("error"), "Response should not contain error message.");
        }


        [Test]
        public void TestResourceNotFound()
        {
            var response = userServices.GetUsers("/invalidEndPoint");

            Assert.That(response.ErrorMessage, Is.Null, "Error message should be null for 404 response");
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.NotFound), "Expected response code: 404 Not Found");
        }
    }
}
