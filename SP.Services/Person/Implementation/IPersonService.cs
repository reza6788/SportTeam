using SP.Services.Person.Messaging;

namespace SP.Services.Person.Implementation
{
    public interface IPersonService
    {
        Task<GetPersonInfoResponse> GetPersonInfo(GetPersonInfoRequest request);
        Task<GetPersonContactInfoResponse> GetPersonContactInfo(GetPersonContactInfoRequest request);
        Task<GetPersonContributionsResponse> GetPersonContribution(GetPersonContributionsRequest request);
    }
}
