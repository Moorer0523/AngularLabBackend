using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace StudyBuddyAPI.Models;

public class Question
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public string Answer { get; set; }
}
