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
}
