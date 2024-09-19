using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyBuddyAPI.Data;
using StudyBuddyAPI.Models;
using StudyBuddyAPI.Models.Dto;
using StudyBuddyAPI.Models.Mapping;

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

    // GET: api/Question
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
    {
        return await _context.Questions.ToListAsync();
    }

    // GET: api/Question/5
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

    // PUT: api/Question/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQuestion(int id, [FromBody] QuestionDTO questionDTO)
    {
        try
        {
            Question currentQuestion = await _context.Questions.FindAsync(id);
            if (currentQuestion == null)
            {
                return NotFound();
            }

            currentQuestion.updateQuestion(questionDTO);

            _context.Update(currentQuestion);

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // POST: api/Question
    [HttpPost]
    public async Task<ActionResult<Question>> PostQuestion([FromBody] QuestionDTO questionDTO)
    {
        //need to redo mapping without automapper
        Question question = questionDTO.toQuestion();
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetQuestion", new { id = question.Id }, question);
    }

    // DELETE: api/Question/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(int id)
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
