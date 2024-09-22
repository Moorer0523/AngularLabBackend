using Microsoft.EntityFrameworkCore;
using StudyBuddyAPI.Models;

namespace StudyBuddyAPI.Models.Dto;

public class QuestionDTO
{
    public string QuestionText { get; set; }
    public string Answer { get; set; }

}
