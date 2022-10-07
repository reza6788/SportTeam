using SP.Common.Enums;
using SP.Data.Common;

namespace SP.Data.Entities
{
    public class PersonEntity : BaseEntityInt
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public Sex Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public bool HasClubNewspaper { get; set; }

        public PersonContactInfoEntity PersonContactInfo { get; set; }
        public PersonContributionEntity PersonContribution { get; set; }
    }
}
