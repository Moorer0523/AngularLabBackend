using StudyBuddyAPI.Models.Dto;

namespace StudyBuddyAPI.Models.Mapping;

public static class QuestionExtensions
{
    public static Question toQuestion(this QuestionDTO questionDTO)
    {

        return new Question()
        {
            QuestionText = questionDTO.QuestionText,
            QuestionOptions = questionDTO.QuestionOptions,
            Answers = questionDTO.Answers,
            IsFavorite = questionDTO.IsFavorite
        };
    }
    public static void updateQuestion(this Question question,QuestionDTO questionDTO)
    {
        {
            question.QuestionText = questionDTO.QuestionText;
            question.QuestionOptions = questionDTO.QuestionOptions;
            question.Answers = questionDTO.Answers;
            question.IsFavorite = questionDTO.IsFavorite;
        };
    }
}
