using SP.Data.Common;

namespace SP.Data.Entities
{
    public class PersonContributionEntity : BaseEntityInt
    {
        public string Name { get; set; }
        public bool IsMembership { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
