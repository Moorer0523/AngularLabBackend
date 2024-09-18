using Microsoft.EntityFrameworkCore;
using StudyBuddyAPI.Models;

namespace StudyBuddyAPI.Models.Dto;

public class QuestionDTO
{
    public string QuestionText { get; set; }
    public string[] QuestionOptions { get; set; }
    public int[] Answers { get; set; }
    public bool IsFavorite { get; set; }

}
