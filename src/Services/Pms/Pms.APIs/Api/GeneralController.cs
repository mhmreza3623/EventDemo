using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pms.APIs.Api;

[ApiController]
[Authorize, Route("api/v1/[controller]")]
public class GeneralController : ControllerBase
{
}