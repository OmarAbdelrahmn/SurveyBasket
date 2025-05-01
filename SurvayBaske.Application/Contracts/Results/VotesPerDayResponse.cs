namespace SurvayBasket.Application.Contracts.Results;

public record VotesPerDayResponse
(
    DateOnly Day,
    int NumberOfVotes
    );
