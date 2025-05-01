using SurvayBasket.Application.Contracts.Results;

namespace SurvayBasket.Application.Contracts.Results;

public record PollVotesResponse
(
    string PollName,
    IEnumerable<VoteResponse> Votes
    );
