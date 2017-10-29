namespace SupportWheelOfFate
{
    public interface IBusinessRules
    {
        int MaxShiftsPerDay { get; set; }
        bool AllowConsecutiveDays { get; set; }
        int ShiftsPerDay { get; set; }
    }
}
