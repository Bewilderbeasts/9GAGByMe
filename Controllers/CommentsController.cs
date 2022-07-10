using FunnyImages.Commands;
using FunnyImages.Commands.Comment;
using FunnyImages.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FunnyImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ApiControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService, ICommandDispatcher commandDispatcher
        ) : base(commandDispatcher)
        {
            _commentService = commentService;
        }

        // GET: api/<CommentsController>
        [HttpGet]
        public async Task<IActionResult> GetCurrentComments(Guid imageId)
        {
            var comments = await _commentService.GetImageCommentsAsync(imageId);
           
            return Json(comments);
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var comment = await _commentService.GetAsync(id);
            if (comment == null)
            {
                throw new Exception("There is no such a comment!");
            }
            return Json(comment);
        }

        // POST api/<CommentsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateComment command)
        {
            await DispatchAsync(command);

            return Created($"comment/{command.Id}", null);
        }


        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
