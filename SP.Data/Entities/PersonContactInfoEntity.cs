using SP.Data.Common;

namespace SP.Data.Entities
{
    public class PersonContactInfoEntity : BaseEntityInt
    {

        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PrivateTel { get; set; }
        public string BusinessTel { get; set; }
        public string CellPhone { get; set; }
        public string BusinessCellPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }

        public int PersonId { get; set; }
        public PersonEntity Person { get; set; }
    }
}
