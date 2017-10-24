namespace SupportWheelOfFate
{
    public interface IBusinessRules
    {
        int MaxShiftsPerDay { get; set; }
        bool AllowConsecutiveDays { get; set; }
    }
}
