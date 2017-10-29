namespace SupportWheelOfFate
{
    public class TaskBusinessRules : IBusinessRules
    {
        public TaskBusinessRules()
        {
            ShiftsPerDay = 2;
            MaxShiftsPerDay = 1;
            AllowConsecutiveDays = false;
        }

        public int MaxShiftsPerDay { get; set; }
        public bool AllowConsecutiveDays { get; set; }
        public int ShiftsPerDay { get; set; }
    }
}
