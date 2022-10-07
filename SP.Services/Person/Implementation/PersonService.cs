using Microsoft.EntityFrameworkCore;
using SP.Common.Enums;
using SP.Common.Messages;
using SP.Common.Utilities;
using SP.Data;
using SP.Data.Entities;
using SP.Services.Person.Messaging;
using SP.Services.Person.Validation;
using SP.Services.Person.ViewModel;

namespace SP.Services.Person.Implementation
{
    public class PersonService : IPersonService
    {
        private readonly SPDbContext _dbContext;

        public PersonService(SPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetPersonInfoResponse> GetPersonInfo(GetPersonInfoRequest request)
        {
            try
            {
                var validator = await new GetByIdValidator().ValidateAsync(request.Entity.PersonalId);
                if (!validator.IsValid)
                    return new GetPersonInfoResponse
                        { IsSuccess = false, Message = validator.Errors.GetErrors(), Result = ResultType.Warning };

                var personEntity = await _dbContext.Persons.FirstOrDefaultAsync(p => p.Id == request.Entity.PersonalId);

                if(personEntity is null)
                    return new GetPersonInfoResponse { IsSuccess = false, Message = MessagesResource.NotExistData, Result = ResultType.Warning };

                return new GetPersonInfoResponse
                {
                    IsSuccess = true,
                    Message = MessagesResource.GetSuccess,
                    Entity = new GetPersonInfoResponseVm
                    {
                        FirstName = personEntity.FirstName,
                        LastName = personEntity.LastName,
                        Avatar = personEntity.Avatar,
                        Sex = personEntity.Sex.GetDisplayName(),
                        BirthDate = personEntity.BirthDate.ToShortDateString(),
                        HasClubNewspaper = personEntity.HasClubNewspaper,
                        Title = personEntity.Title,
                        MembershipTime=personEntity.CreateDateTime.Year.ToString()
                    }
                };
            }
            catch 
            {
                return new GetPersonInfoResponse
                    { IsSuccess = false, Message = MessagesResource.GetFailed, Result = ResultType.Error };
            }
            finally
            {
                _dbContext.Dispose();
            }
        }

        public async Task<GetPersonContactInfoResponse> GetPersonContactInfo(GetPersonContactInfoRequest request)
        {
            try
            {
                var validator = await new GetByIdValidator().ValidateAsync(request.Entity.PersonalId);
                if (!validator.IsValid)
                    return new GetPersonContactInfoResponse()
                        { IsSuccess = false, Message = validator.Errors.GetErrors(), Result = ResultType.Warning };

                var personContactInfoEntity = await _dbContext.PersonContactInfos.FirstOrDefaultAsync(p => p.Id == request.Entity.PersonalId);
                
                if (personContactInfoEntity is null)
                    return new GetPersonContactInfoResponse { IsSuccess = false, Message = MessagesResource.NotExistData, Result = ResultType.Warning };

                return new GetPersonContactInfoResponse
                {
                    IsSuccess = true,
                    Message = MessagesResource.GetSuccess,
                    Entity = new GetPersonContactInfoResponseVm
                    {
                        Street = personContactInfoEntity.Street,
                        BusinessCellPhone = personContactInfoEntity.BusinessCellPhone,
                        BusinessTel = personContactInfoEntity.BusinessTel,
                        CellPhone = personContactInfoEntity.CellPhone,
                        City = personContactInfoEntity.City,
                        Country = personContactInfoEntity.Country,
                        Email = personContactInfoEntity.Email,
                        Fax = personContactInfoEntity.Fax,
                        PostalCode = personContactInfoEntity.PostalCode,
                        PrivateTel = personContactInfoEntity.PrivateTel,
                        Website = personContactInfoEntity.Website
                    }
                };
            }
            catch
            {
                return new GetPersonContactInfoResponse
                { IsSuccess = false, Message = MessagesResource.GetFailed, Result = ResultType.Error };
            }
            finally
            {
                _dbContext.Dispose();
            }
        }

        public async Task<GetPersonContributionsResponse> GetPersonContribution(GetPersonContributionsRequest request)
        {
            try
            {
                var validator = await new GetByIdValidator().ValidateAsync(request.Entity.PersonalId);
                if (!validator.IsValid)
                    return new GetPersonContributionsResponse
                    { IsSuccess = false, Message = validator.Errors.GetErrors(), Result = ResultType.Warning };

                var personContributionEntity = await _dbContext.PersonContributions.FirstOrDefaultAsync(p => p.Id == request.Entity.PersonalId);

                if (personContributionEntity is null)
                    return new GetPersonContributionsResponse { IsSuccess = false, Message = MessagesResource.NotExistData, Result = ResultType.Warning };


                return new GetPersonContributionsResponse
                {
                    IsSuccess = true,
                    Message = MessagesResource.GetSuccess,
                    Entity = new GetPersonContributionResponseVm
                    {
                        Amount = personContributionEntity.Amount,
                        Description = personContributionEntity.Description,
                        IsMembership = personContributionEntity.IsMembership? "Aktive": "Inaktiv",
                        Name = personContributionEntity.Name
                    }
                };
            }
            catch
            {
                return new GetPersonContributionsResponse
                { IsSuccess = false, Message = MessagesResource.GetFailed, Result = ResultType.Error };
            }
            finally
            {
                _dbContext.Dispose();
            }
        }
    }
}
