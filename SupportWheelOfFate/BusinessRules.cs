namespace SupportWheelOfFate
{
    public class TaskBusinessRules : IBusinessRules
    {
        public TaskBusinessRules()
        {
            MaxShiftsPerDay = 1;
            AllowConsecutiveDays = false;
        }

        public int MaxShiftsPerDay { get; set; }
        public bool AllowConsecutiveDays { get; set; }
    }
}
