using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sharpdev.SDK.API
{
    [ApiController]
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [TypeFilter(typeof(LoggerAttribute))]
    public abstract class SharpdevControllerBase : ControllerBase
    {
    }
}
