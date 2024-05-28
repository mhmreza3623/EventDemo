using Microsoft.AspNetCore.Mvc;
using Pms.APIs.Configs.Filters;
using Pms.APIs.Models;

namespace Pms.APIs.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseV1Controller : ControllerBase
    {
        public ClientModel Client { get; set; }
    }
}
