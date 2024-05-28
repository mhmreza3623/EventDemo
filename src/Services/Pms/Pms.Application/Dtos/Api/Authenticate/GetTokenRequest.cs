    namespace Pms.Application.Dtos.Api.Authenticate
{
    public class GetTokenRequest
    {
        public string UserName { get; set; }
        public string ClientUxId {
            get;
            set;
        }
    }
}
