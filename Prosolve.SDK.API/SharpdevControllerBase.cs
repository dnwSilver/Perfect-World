using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sharpdev.SDK.API
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [TypeFilter(typeof(LoggerAttribute))]
    public abstract class SharpdevControllerBase : ControllerBase
    {
    }
}
