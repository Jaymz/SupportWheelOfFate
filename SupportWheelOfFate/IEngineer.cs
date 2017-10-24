using System.Collections.Generic;

namespace SupportWheelOfFate
{
    public interface IEngineer
    {
        string Name { get; set; }
        bool CanWork();
        bool CanWork(IShift shift);
        double MaxShiftDuration { get; set; }
        double ShiftDuration { get; }
        IList<IShift> Shifts { get; set; }
    }
}
