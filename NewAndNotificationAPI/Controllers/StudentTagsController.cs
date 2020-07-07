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
    public class StudentTagsController : ControllerBase
    {

        private readonly NewAndNotificationContext _context;
        private readonly IStudentTagRepo _repository;
        private readonly IMapper _mapper;

        public StudentTagsController(NewAndNotificationContext context, IStudentTagRepo repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/StudentTags
        [HttpGet]
        public ActionResult<IEnumerable<StudentTags>> GetAllStudentTags()
        {
            IEnumerable<StudentTags> studentTags = _repository.GetAllStudentTags();
            if (studentTags != null)
            {
                return Ok(_mapper.Map<IEnumerable<StudentTagReadDto>>(studentTags));
            }
            return NotFound();
        }

        // GET: api/StudentTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTags>> GetStudentTags(int id)
        {
            var studentTags = await _context.StudentTags.FindAsync(id);

            if (studentTags == null)
            {
                return NotFound();
            }

            return studentTags;
        }

        // PUT: api/StudentTags/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentTags(int id, StudentTags studentTags)
        {
            if (id != studentTags.StudentTagId)
            {
                return BadRequest();
            }

            _context.Entry(studentTags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentTagsExists(id))
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

        // POST: api/StudentTags
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentTags>> PostStudentTags(StudentTags studentTags)
        {
            _context.StudentTags.Add(studentTags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentTags", new { id = studentTags.StudentTagId }, studentTags);
        }

        // DELETE: api/StudentTags/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentTags>> DeleteStudentTags(int id)
        {
            var studentTags = await _context.StudentTags.FindAsync(id);
            if (studentTags == null)
            {
                return NotFound();
            }

            _context.StudentTags.Remove(studentTags);
            await _context.SaveChangesAsync();

            return studentTags;
        }

        private bool StudentTagsExists(int id)
        {
            return _context.StudentTags.Any(e => e.StudentTagId == id);
        }
    }
}
