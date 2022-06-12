using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseRoute)]
    public class PostsController: ControllerBase
    {

        [HttpGet]
        [Route(ApiRoutes.Posts.GetById)]
        public IActionResult GetById(int id)
        {
            var post = "text";

            return Ok(post);
        }
    }
}
