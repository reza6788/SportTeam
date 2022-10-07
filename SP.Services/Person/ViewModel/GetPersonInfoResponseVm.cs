using SP.Common.Enums;

namespace SP.Services.Person.ViewModel
{
    public class GetPersonInfoResponseVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Avatar { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public string MembershipTime { get; set; }
        public bool HasClubNewspaper { get; set; }
    }
}
