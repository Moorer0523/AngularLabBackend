using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace StudyBuddyAPI.Models;

public class Question
{
    public int Id { get; set; }
    public string QuestionText { get; set; }
    public string[] QuestionOptions { get; set; }
    public int[] Answers { get; set; }
    public bool IsFavorite { get; set; }
}
