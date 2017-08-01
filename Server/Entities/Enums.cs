using System.ComponentModel.DataAnnotations;

namespace sfBase.Server.Entities
{
    public enum ExternalLoginStatus
    {
        Ok = 0,
        Error = 1,
        Invalid = 2,
        TwoFactor = 3,
        Lockout = 4,
        CreateAccount = 5

    }

    public enum WorkingType
    {
        [Display(Name = "未登録")]
        Unregistered = 0,
        Attendance = 1,
        PaidHoliday = 20,
        LegalHoliday = 10,
        NonLegalHoliday = 11

    }
}