using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewAndNotificationAPI.Data;
using NewAndNotificationAPI.Dtos;
using NewAndNotificationAPI.Models;
namespace NewAndNotificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        
        private readonly NewAndNotificationContext _context;
        private readonly IPostRepo _repository;
        private readonly IMapper _mapper;

        public PostsController (NewAndNotificationContext context, IPostRepo repository, IMapper mapper)
        { 
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Posts
        [HttpGet]
        public ActionResult <IEnumerable<PostReadDto>> GetAllPost()
        {
            IEnumerable<Post> posts = _repository.GetAllPost();
            if (posts != null)
            {
                return Ok(_mapper.Map<IEnumerable<PostReadDto>>(posts));
            }
            return NotFound();
        }

        // GET: api/Posts/5
        [HttpGet("{postId}")]
        public ActionResult<PostReadDto> GetPostById(int postId)
        {
            Post post = _repository.GetPostById(postId);
            if (post != null)
            {
                return Ok(_mapper.Map<PostReadDto>(post));
            }
            
                return NotFound();
           
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
           

            return NoContent();
        }

        // POST: api/Posts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            return NoContent();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return post;
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.topicId == id);
        }
    }
}
