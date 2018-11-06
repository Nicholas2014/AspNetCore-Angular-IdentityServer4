using BlogDemo.Core.Entities;
using BlogDemo.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BlogDemo.Api.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostRepository postRepository, IUnitOfWork unitOfWork,ILogger<PostController> logger)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Get All Posts...");

            var posts = await _postRepository.GetAllPostsAsync();

            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var post = new Post()
            {
                Title = "This is a new Title",
                Author = "jack ma",
                Body = "this is body",
                LastModified = DateTime.Now
            };
            _postRepository.AddPost(post);
            await _unitOfWork.SaveAsync();

            return Ok();
        }
    }
}
