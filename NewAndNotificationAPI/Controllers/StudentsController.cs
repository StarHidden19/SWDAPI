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
    public class StudentsController : ControllerBase
    {
        private readonly NewAndNotificationContext _context;
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentsController(NewAndNotificationContext context, IStudentRepo repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public  ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            IEnumerable<Student> students = _repository.GetAllStudent();
            if (students != null)
            {
                return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(students));
            }
            return NotFound();
        }

        // GET: api/Students/5
        [HttpGet("{studentId}")]
        public ActionResult<StudentReadDto> GetStudentById(int studentId)
        {
            Student student = _repository.GetStudentById(studentId);
            if (student != null)
            {
                return Ok(_mapper.Map<StudentReadDto>(student));
            }
            return NotFound();
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.studentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.studentId }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.studentId == id);
        }
    }
}
