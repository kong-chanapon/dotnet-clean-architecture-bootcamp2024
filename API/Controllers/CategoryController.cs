using Application.Features.Category.Commands;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetCategoryByUrlHandle;
using Application.Features.Category.Queries.GetCategoryCount;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var categories = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (categories == null) {
                return NotFound();
            }
            return Ok(categories);
        }

        [HttpGet("{urlHandle}")]
        public async Task<IActionResult> GetBy([FromRoute] string urlHandle) {
            var categories = await _mediator.Send(new GetCategoryByUrlHandleQuery(urlHandle));
            return Ok(categories);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetCount() {
            var result = await _mediator.Send(new GetCategoryCountQuery());
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddCategoryRequestDto reqeust)
        {
            var reuslt = await _mediator.Send(new AddCategoryCommand(reqeust));
            return Ok(reuslt);
        }
        
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateCategoryRequestDto request)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(id, request));
            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id){
            var result = await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }
    }
}
