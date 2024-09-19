using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyBuddyAPI.Data;
using StudyBuddyAPI.Models;
using StudyBuddyAPI.Models.Dto;

namespace StudyBuddyAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly SbuddyDbContext _context;

    public QuestionController(SbuddyDbContext context)
    {
        _context = context;
    }

    // GET: api/Orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
    {
        return await _context.Questions.ToListAsync();
    }

    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> GetQuestion(int id)
    {
        var question = await _context.Questions.FindAsync(id);

        if (question == null)
        {
            return NotFound();
        }

        return question;
    }

    // PUT: api/Orders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(int id, [FromBody] QuestionDTO questionDTO)
    {
        try
        {
            Question currentQuestion = await _context.Questions.FindAsync(id);
            if (currentQuestion == null)
            {
                return NotFound();
            }

            //Need to redo mapping without automapper
            Question updatedOrder = _mapper.Map(orderInputDTO, currentOrder);

            _context.Entry(currentQuestion).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // POST: api/Orders
    [HttpPost]
    public async Task<ActionResult<Question>> PostOrder([FromBody] QuestionDTO QuestionDTO)
    {
        //need to redo mapping without automapper
        Question question = _mapper.Map<Order>(orderInputDTO);
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
        {
            return NotFound();
        }

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
