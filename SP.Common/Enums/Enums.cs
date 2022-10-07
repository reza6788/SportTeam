using System.ComponentModel.DataAnnotations;

namespace SP.Common.Enums
{
    public enum ResultType
    {
        None = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Success = 5,
        Question = 6,
    }
    
    public enum Sex
    {
        [Display(Name = "Männlich")]
        Male=1,
        [Display(Name = "Weiblich")]
        Female=2,
        [Display(Name = "Diverse")]
        Diverse = 3,
    }

    public enum DisplayProperty
    {
        Description = 1,
        GroupName = 2,
        Name = 3,
        Prompt = 4,
        ShortName = 5,
        Order = 6
    }

    public enum SettingParameter
    {
        EditPersonData=1,
    }
}
