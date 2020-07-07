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
    public class PostTagsController : ControllerBase
    {
        private readonly NewAndNotificationContext _context;
        private readonly IPostTagsRepo _repository;
        private readonly IMapper _mapper;

        public PostTagsController(NewAndNotificationContext context, IPostTagsRepo repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/PostTags
        [HttpGet]
        public ActionResult <IEnumerable<PostTagsReadDto>> GetAllPostTags()
        {
            IEnumerable<PostTags> PostTag = _repository.GetAllPostTags();
            if (PostTag != null)
            {
                return Ok(_mapper.Map<IEnumerable<PostTagsReadDto>>(PostTag));
            }
            return NotFound();
        }

        // GET: api/PostTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostTags>> GetPostTags(int id)
        {
            var postTags = await _context.PostTags.FindAsync(id);

            if (postTags == null)
            {
                return NotFound();
            }

            return postTags;
        }

        // PUT: api/PostTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostTags(int id, PostTags postTags)
        {
            if (id != postTags.tagId)
            {
                return BadRequest();
            }

            _context.Entry(postTags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostTagsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PostTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PostTags>> PostPostTags(PostTags postTags)
        {
            _context.PostTags.Add(postTags);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostTagsExists(postTags.tagId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPostTags", new { id = postTags.tagId }, postTags);
        }

        // DELETE: api/PostTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostTags>> DeletePostTags(int id)
        {
            var postTags = await _context.PostTags.FindAsync(id);
            if (postTags == null)
            {
                return NotFound();
            }

            _context.PostTags.Remove(postTags);
            await _context.SaveChangesAsync();

            return postTags;
        }

        private bool PostTagsExists(int id)
        {
            return _context.PostTags.Any(e => e.tagId == id);
        }
    }
}
