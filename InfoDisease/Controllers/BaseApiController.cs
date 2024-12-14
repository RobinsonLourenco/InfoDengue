using Microsoft.AspNetCore.Mvc;

namespace InfoDisease.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }
}

