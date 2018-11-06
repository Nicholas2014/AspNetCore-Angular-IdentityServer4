using AutoMapper;
using BlogDemo.Core.Entities;
using BlogDemo.Core.Interfaces;
using BlogDemo.Infrastructure.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogDemo.Api.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PostController> _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PostController(IPostRepository postRepository, IUnitOfWork unitOfWork
            , ILogger<PostController> logger, IMapper mapper, IConfiguration configuration)
        {
            _postRepository = postRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = _configuration["Key1"];
            _logger.LogInformation($"Get All Posts...");

            var posts = await _postRepository.GetAllPostsAsync();
            var postResources = _mapper.Map<IEnumerable<PostResource>>(posts);

            return Ok(postResources);
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
