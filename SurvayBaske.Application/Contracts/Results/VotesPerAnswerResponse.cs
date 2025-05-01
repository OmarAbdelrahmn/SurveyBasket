namespace SurvayBasket.Application.Contracts.Results;

public record VotesPerAnswerResponse
(
    string answer,
    int count

    );