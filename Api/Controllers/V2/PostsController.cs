using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PostsController : ControllerBase
    {

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var post = "text";

            return Ok(post);
        }
    }
}
