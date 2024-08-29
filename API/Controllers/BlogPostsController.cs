using Application.Features.BlogPost.Commands.AddBlogPost;
using Application.Features.BlogPost.Commands.DeleteBlogPost;
using Application.Features.BlogPost.Commands.UpdateBlogPost;
using Application.Features.BlogPost.Queries.GetAllBlogPost;
using Application.Features.BlogPost.Queries.GetBlogPostById;
using Application.Features.BlogPost.Queries.GetBlogPostByUrlHandle;
using Application.Features.BlogPost.Queries.GetBlogPostCount;
using Application.Models.BlogPost;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogPostsController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var result = await _mediator.Send(new GetAllBlogPostQuery());
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var result = await _mediator.Send(new GetBlogPostByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("{urlHandle}")]
        [Authorize]
        public async Task<IActionResult> GetByUrlHandle([FromRoute] string urlHandle) {
            var result = await _mediator.Send(new GetBlogPostByUrlHandleQuery(urlHandle));
            return Ok(result);
        }

        [HttpGet("count")]
        [Authorize]
        public async Task<IActionResult> GetCount() {
            var result = await _mediator.Send(new GetBlogPostCountQuery());
            return Ok(result);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] AddBlogPostRequestDto request)
        {
            var blogPost = await _mediator.Send(new AddBlogPostCommand(request));
            return Ok(blogPost);
        }
        
        [HttpPut("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody]UpdateBlogPostRequestDto request)
        {
            var result = await _mediator.Send(new UpdateBlogPostCommand(id, request));
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id){
            var result = await _mediator.Send(new DeleteBlogPostCommand(id));
            return Ok(result);
        }
    }
}
