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
    public class TopicsController : ControllerBase
    {

        private readonly NewAndNotificationContext _context;
        private readonly ITopicRepo _repository;
        private readonly IMapper _mapper;

        public TopicsController(NewAndNotificationContext context, ITopicRepo repository, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Topics
        [HttpGet]
        public ActionResult<IEnumerable<TopicReadDto>> GetAllTopic()
        {
            IEnumerable<Topic> topics = _repository.GetAllTopic();
            if (topics != null)
            {
                return Ok(_mapper.Map<IEnumerable<TopicReadDto>>(topics));
            }
            return NotFound();
        }

        // GET: api/Topics/5
        [HttpGet("{topicId}")]
        public ActionResult<Topic> GetTopicById(int topicId)
        {
            Topic topic = _repository.GetTopicById(topicId);
            if (topic != null)
            {
                return Ok(_mapper.Map<TopicReadDto>(topic));
            }
            return NotFound();
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.topicId)
            {
                return BadRequest();
            }

            _context.Entry(topic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topics
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            _context.Topics.Add(topic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTopic", new { id = topic.topicId }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Topic>> DeleteTopic(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();

            return topic;
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.topicId == id);
        }
    }
}
