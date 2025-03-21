using SurveyBasket.Contracts.Questions;
using SurveyBasket.Contracts.Users;

namespace SurveyBasket.Mapping;

public class MappingConfigration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<QuestionRequest, Question>()
            .Map(dest => dest.Answers, src => src.Answers.Select(answer => new Answer { Content = answer }));

        //config.NewConfig<RegisterRequest, ApplicataionUser>()
        //    .Map(des => des.UserName, src => $"{src.FirstName}{src.LastName}");


        config.NewConfig<RegisterRequest, ApplicataionUser>()
            .Map(des => des.UserName, src => src.Email);

        config.NewConfig<(ApplicataionUser user, IList<string> userroles), UserResponse>()
            .Map(des => des, src => src.user)
            .Map(des => des.Roles, src => src.userroles);
    }
}
