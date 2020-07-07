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
    public class TagsController : ControllerBase
    {
        private readonly NewAndNotificationContext _context;
        private readonly ITagRepo _repository;
        private readonly IMapper _mapper;

        public TagsController(NewAndNotificationContext context, ITagRepo repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Tags
        [HttpGet]
        public ActionResult<IEnumerable<TagReadDto>> GetAllTags()
        {
            IEnumerable<Tag> tags = _repository.GetAllTag();
            if (tags != null)
            {
                return Ok(_mapper.Map<IEnumerable<TagReadDto>>(tags));
            }
            return NotFound();
        }

        // GET: api/Tags/5
        [HttpGet("{tagId}")]
        public ActionResult<TagReadDto> GetTagById(int tagId)
        {
            Tag tag = _repository.GetTagById(tagId);
            if (tag != null)
            {
                return Ok(_mapper.Map<TagReadDto>(tag));
            }

            return NotFound();
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(int id, Tag tag)
        {
            if (id != tag.tagId)
            {
                return BadRequest();
            }

            _context.Entry(tag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(id))
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

        // POST: api/Tags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTag", new { id = tag.tagId }, tag);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tag>> DeleteTag(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();

            return tag;
        }

        private bool TagExists(int id)
        {
            return _context.Tags.Any(e => e.tagId == id);
        }
    }
}
