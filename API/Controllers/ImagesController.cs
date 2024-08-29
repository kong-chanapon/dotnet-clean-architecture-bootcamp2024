using Application.Features.BlogImage.Commands;
using Application.Features.BlogImage.Queries.GetAllBlogImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
         private readonly IMediator _mediator;

        public ImagesController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll() {
            var reuslt = await _mediator.Send(new GetAllBlogImageQuery());
            return Ok(reuslt);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title) {
            await _mediator.Send(new AddBlogImageCommand{ File = file, FileName = fileName, Title = title });
            return Ok();
        }
    }
}
