namespace SurvayBasket.Application.Contracts.Answers;

public record AnswerRequest
(int Id,
    string Content,
    int QuestionId);
