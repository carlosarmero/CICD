using Microsoft.Extensions.Configuration;
using RestSharp;
using Serilog;
using System.Text.Json;
using TASk_loc1.Business.BOM;
using TASk_loc1.Core;

namespace TASk_loc1.Tests
{
    public class UserApiTests : IDisposable
    {
        private readonly ApiBaseClient _apiClient;
        private readonly string settingsDirectory;

        public UserApiTests()
        {
            settingsDirectory = settingsDirectory = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "core", "files");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(settingsDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            _apiClient = new ApiBaseClient(configuration.GetSection("ApiConfiguration:BaseUrl").Value);

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        }

        [Fact]
        [Trait("Category", "API")]
        public async Task ValidateListOfUsersCanBeReceivedSuccessfully()
        {
            Log.Information("Starting getting users test");
            var request = new UserRequestBuilder()
                .WithMethod(Method.Get)
                .WithResource("users")
                .Build();

            var response = await _apiClient.ExecuteRequestAsync(request);
            Assert.Multiple(
                () => Assert.NotNull(response),
                () => Assert.Equal(200, (int)response.StatusCode),
                () => Assert.NotNull(response.Content)
             );

            var users = JsonSerializer.Deserialize<List<User>>(response.Content, _apiClient._jsonOptions);

            Assert.Multiple(() =>
            {
                Assert.NotNull(users);
                Assert.NotEmpty(users);

                foreach (var user in users)
                {
                    Assert.NotNull(user.Id);
                    Assert.NotNull(user.Name);
                    Assert.NotNull(user.Username);
                    Assert.NotNull(user.Email);
                    Assert.NotNull(user.Address);
                    Assert.NotNull(user.Phone);
                    Assert.NotNull(user.Website);
                    Assert.NotNull(user.Company);
                }
            });
        }

        [Fact]
        [Trait("Category", "API")]
        public async Task ValidateResponseHeaderForListOfUsers()
        {
            Log.Information("Starting header test");
            var request = new UserRequestBuilder()
                .WithMethod(Method.Get)
                .WithResource("users")
                .Build();
            var response = await _apiClient.ExecuteRequestAsync(request);
            Assert.Multiple(
                () => Assert.NotNull(response),
                () => Assert.Equal(200, (int)response.StatusCode),
                () => Assert.NotNull(response.Content)
            );

            var contentTypeHeader = response?.ContentHeaders?
                .FirstOrDefault(h => h.Name.Equals("Content-Type", StringComparison.OrdinalIgnoreCase));
            Assert.Multiple(() =>
            {
                Assert.NotNull(contentTypeHeader);
                Assert.Equal("application/json; charset=utf-8", contentTypeHeader.Value.ToString());
            });
        }

        [Fact]
        [Trait("Category", "API")]
        public async Task ValidateResponseBodyForListOfUsers()
        {
            Log.Information("Starting different ids test");
            var request = new UserRequestBuilder()
                .WithMethod(Method.Get)
                .WithResource("users")
                .Build();

            var response = await _apiClient.ExecuteRequestAsync(request);

            Assert.Multiple(() =>
            {
                Assert.NotNull(response);
                Assert.Equal(200, (int)response.StatusCode);
                Assert.NotNull(response.Content);
            });

            var users = JsonSerializer.Deserialize<List<User>>(response.Content, _apiClient._jsonOptions);

            Assert.Multiple(() =>
            {
                Assert.NotNull(users);
                Assert.Equal(10, users?.Count);

                var userIds = users?.Select(u => u.Id).Distinct().ToList();
                Assert.Equal(users?.Count, userIds?.Count);

                foreach (var user in users)
                {
                    Assert.False(string.IsNullOrEmpty(user.Name), "User name is empty.");
                    Assert.False(string.IsNullOrEmpty(user.Username), "Username is empty.");
                    Assert.False(string.IsNullOrEmpty(user.Company?.Name), "Company name is empty.");
                }
            });
        }

        [Theory]
        [InlineData("Test User", "testuser")]
        [InlineData("epam", "company")]
        [Trait("Category", "API")]
        public async Task ValidateUserCreation(string name, string username)
        {
            Log.Information("Starting user creation test");
            var newUser = new User
            {
                Name = name,
                Username = username
            };

            var request = new UserRequestBuilder()
                .WithMethod(Method.Post)
                .WithResource("/users")
                .WithJsonBody(newUser)
                .Build();
            var response = await _apiClient.ExecuteRequestAsync(request);
            Assert.Multiple(() =>
            {
                Assert.NotNull(response);
                Assert.Equal(201, (int)response.StatusCode);
                Assert.NotNull(response.Content);
            });

            var createdUser = JsonSerializer.Deserialize<User>(response.Content, _apiClient._jsonOptions);

            Assert.Multiple(() =>
            {
                Assert.NotNull(createdUser);
                Assert.NotNull(createdUser.Id);
            });
        }

        [Fact]
        [Trait("Category", "API")]
        public async Task ValidateUserNotifiedIfResourceDoesNotExist()
        {
            Log.Information("Starting invalid endpoint test");
            var request = new UserRequestBuilder()
                .WithMethod(Method.Get)
                .WithResource("/invalidendpoint")
                .Build();
            var response = await _apiClient.ExecuteRequestAsync(request);
            Assert.Multiple(() =>
            {
                Assert.NotNull(response);
                Assert.Equal(404, (int)response.StatusCode);
            });
        }
        public void Dispose()
        {
            _apiClient?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
