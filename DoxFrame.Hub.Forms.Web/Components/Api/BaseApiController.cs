using Microsoft.AspNetCore.Mvc;

namespace DoxFrame.Hub.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
