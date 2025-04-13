using RestSharp;
using System.Text.Json;

namespace TASk_loc1.Core
{
    public class ApiBaseClient : IDisposable
    {
        private readonly RestClient _client;
       // public readonly JsonSerializerOptions _jsonOptions;

        public ApiBaseClient(string baseUrl)
        {
            _client = new RestClient(baseUrl);
           /* _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };*/
        }

        public RestResponse ExecuteRequest(RestRequest request)
        {
            return _client.Execute(request);
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}
