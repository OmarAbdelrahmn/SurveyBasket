using SurveyBasket.Contracts.Results;

namespace SurvayBasket.Application.Contracts.Results;

public record VoteResponse
(
    string VoterName,
    DateTime VoteTime,
    IEnumerable<QuestionAnswerResponse> SelectedAnswers
    );
