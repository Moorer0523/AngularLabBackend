using StudyBuddyAPI.Models.Dto;

namespace StudyBuddyAPI.Models.Mapping;

public static class QuestionExtensions
{
    public static Question toQuestion(this QuestionDTO questionDTO)
    {
        Question question = new Question();
    }
}
