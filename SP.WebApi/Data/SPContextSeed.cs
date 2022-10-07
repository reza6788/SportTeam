using SP.Common.Enums;
using SP.Common.Utilities;
using SP.Data;
using SP.Data.Entities;

namespace SP.WebApi.Data
{
    public class SPContextSeed
    {
        public static void SeedAsync(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<SPDbContext>();

            if (!dbContext.Persons.Any())
            {
                var person = new PersonEntity
                {
                    Id = 1,
                    BirthDate = new DateTime(1964, 02, 22),
                    CreateDateTime = new DateTime(2019, 02, 01),
                    FirstName = "Thomas",
                    LastName = "Tihl",
                    Title = "Mr",
                    HasClubNewspaper = false,
                    IsDeleted = false,
                    Sex = Sex.Male,
                    Avatar = $"{Constants.BaseUrl}/Media/Avatar/thomas.jpg"
                    ,
                };

                var personContactInfo = new PersonContactInfoEntity
                {
                    Id = 1,
                    PersonId = person.Id,
                    BusinessCellPhone = "917-234-2321",
                    BusinessTel = "917-234-2321",
                    PrivateTel = "917-234-2321",
                    CellPhone = "917-234-2321",
                    Fax = "917-234-2321",
                    City = "Hamburg",
                    Country = "Deutschland",
                    PostalCode = "20234",
                    Street = "Homburger Strasse 1",
                    Email = "info@daisser.com",
                    Website = "daisser.com",
                };

                var personContribution = new PersonContributionEntity
                {
                    Name = "Hockey Einzeltraining",
                    Amount = 200.95m,
                    IsMembership = true,
                    Description =
                        "Phasellus commodo feugiat lectus, id viverra turpis commodo sed. Sed lacinia ut augue nec pretium. Donec felis ante, laoreet et augue ac, pellentesque tincidunt velit. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nullam a dictum purus, vulputate."
                };


                dbContext.Persons.Add(person);
                dbContext.PersonContactInfos.Add(personContactInfo);
                dbContext.PersonContributions.Add(personContribution);

                dbContext.SaveChanges();
            }
        }
    }
}
