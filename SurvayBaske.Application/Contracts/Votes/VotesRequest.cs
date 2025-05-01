namespace SurvayBasket.Application.Contracts.Votes;

public record VotesRequest
(
    IEnumerable<VotesAnswerRequest> Answers

    );
