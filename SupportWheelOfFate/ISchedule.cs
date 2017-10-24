using System.Collections.Generic;

namespace SupportWheelOfFate
{
    public interface ISchedule
    {
        IList<IShift> Shifts { get; set; }
        void AddShift(IShift shift);
        void AddEngineerToShift(IShift shift, IEngineer engineer);
        void ClearSchedule();
        void PrintSchedule();
    }
}
