using Microsoft.AspNetCore.Authorization;
using Pms.APIs.Configs.Filters;
using Pms.APIs.Models;

namespace Pms.APIs.Api
{
    [IdentifyClient]
    public class BaseV1Controller : GeneralController
    {
        public ClientModel Client { get; set; }
    }
}
