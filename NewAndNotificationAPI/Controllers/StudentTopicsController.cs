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
    public class StudentTopicsController : ControllerBase
    {

        private readonly NewAndNotificationContext _context;
        private readonly IStudentTopicRepo _repository;
        private readonly IMapper _mapper;

        public StudentTopicsController(NewAndNotificationContext context, IStudentTopicRepo repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }


        // GET: api/StudentTopics
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudentTopics()
        {
            IEnumerable<StudentTopics> studentTopics = _repository.GetAllStudentTopics();
            if (studentTopics != null)
            {
                return Ok(_mapper.Map<IEnumerable<StudentTopicReadDto>>(studentTopics));
            }
            return NotFound();
        }

        // GET: api/StudentTopics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentTopics>> GetStudentTopics(int id)
        {
            var studentTopics = await _context.StudentTopics.FindAsync(id);

            if (studentTopics == null)
            {
                return NotFound();
            }

            return studentTopics;
        }

        // PUT: api/StudentTopics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentTopics(int id, StudentTopics studentTopics)
        {
            if (id != studentTopics.studentTopicId)
            {
                return BadRequest();
            }

            _context.Entry(studentTopics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentTopicsExists(id))
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

        // POST: api/StudentTopics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StudentTopics>> PostStudentTopics(StudentTopics studentTopics)
        {
            _context.StudentTopics.Add(studentTopics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentTopics", new { id = studentTopics.studentTopicId }, studentTopics);
        }

        // DELETE: api/StudentTopics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentTopics>> DeleteStudentTopics(int id)
        {
            var studentTopics = await _context.StudentTopics.FindAsync(id);
            if (studentTopics == null)
            {
                return NotFound();
            }

            _context.StudentTopics.Remove(studentTopics);
            await _context.SaveChangesAsync();

            return studentTopics;
        }

        private bool StudentTopicsExists(int id)
        {
            return _context.StudentTopics.Any(e => e.studentTopicId == id);
        }
    }
}
