using SP.Common.Enums;
using SP.Data.Common;

namespace SP.Data.Entities
{
    public class SettingEntity : BaseEntityInt
    {
        public bool IsActive { get; set; }
        public SettingParameter Parameter { get; set; }
        public string Value { get; set; }
    }
}
