using System;
using System.Collections.Generic;

namespace SupportWheelOfFate
{
    public class Schedule : ISchedule
    {
        public Schedule(IWorkforce workforce)
        {
            Shifts = new List<IShift>();
            Workforce = workforce;
        }

        public IList<IShift> Shifts { get; set; }
        public IWorkforce Workforce { get; set; }
        public void AddShift(IShift shift)
        {
            Shifts.Add(shift);
        }

        public void AddEngineerToShift(IShift shift, IEngineer engineer)
        {
            shift.Engineer = engineer;
            engineer.Shifts.Add(shift);
        }

        public void ClearSchedule()
        {
            foreach (var shift in Shifts) {
                shift.Engineer = null;
            }
            foreach (var engineer in Workforce.Engineers) {
                engineer.Shifts.Clear();
            }
        }

        public void PrintSchedule()
        {
            foreach (var shift in Shifts) {
                Console.WriteLine($"Shift {shift.Position}, Engineer: {shift.Engineer.Name}.");
            }
        }
    }
}
