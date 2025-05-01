using SurvayBasket.Application.Contracts.Answers;

namespace SurvayBasket.Application.Contracts.Questions;

public record QuestionResponse
(
    int Id,
    string Content,
    List<AnswerResponse> Answers

);
