using StudyBuddyAPI.Models.Dto;

namespace StudyBuddyAPI.Models.Mapping;

public static class QuestionExtensions
{
    public static Question toQuestion(this QuestionDTO questionDTO)
    {

        return new Question()
        {
            QuestionText = questionDTO.QuestionText,
            Answer = questionDTO.Answer,
        };
    }
    public static void updateQuestion(this Question question,QuestionDTO questionDTO)
    {
        {
            question.QuestionText = questionDTO.QuestionText;
            question.Answer = questionDTO.Answer;
        };
    }
}
