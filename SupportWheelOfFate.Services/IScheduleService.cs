namespace SupportWheelOfFate.Services
{
    public interface IScheduleService
    {
        ISchedule GetSchedule();
        void FillSchedule();
        bool ScheduleFilled { get; set; }
    }
}
