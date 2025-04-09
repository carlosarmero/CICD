using RestSharp;

namespace TASk_loc1.Core
{
    public class UserRequestBuilder
    {
        private readonly RestRequest _request;

        public UserRequestBuilder()
        {
            _request = new RestRequest();
        }
        public UserRequestBuilder WithMethod(Method method)
        {
            _request.Method = method;
            return this;
        }

        public UserRequestBuilder WithResource(string resource)
        {
            _request.Resource = resource;
            return this;
        }
        public UserRequestBuilder WithJsonBody(object body)
        {
            _request.AddJsonBody(body);
            return this;
        }
        public RestRequest Build()
        {
            return _request;
        }
    }
}
