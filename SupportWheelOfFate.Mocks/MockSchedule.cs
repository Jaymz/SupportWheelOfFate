using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportWheelOfFate.Mocks
{
    public class MockSchedule : ISchedule
    {
        public IWorkforce Workforce { get; set; }

        public MockSchedule(IWorkforce workforce)
        {
            Workforce = workforce;
        }

        private IList<IShift> _shifts;
        public IList<IShift> Shifts {
            get {
                if (_shifts == null) {
                    _shifts = new List<IShift>() {
                        new Shift(1, 1, 0.5),
                        new Shift(2, 1, 0.5),
                        new Shift(3, 2, 0.5),
                        new Shift(4, 2, 0.5),
                        new Shift(5, 3, 0.5),
                        new Shift(6, 3, 0.5),
                        new Shift(7, 4, 0.5),
                        new Shift(8, 4, 0.5),
                        new Shift(9, 5, 0.5),
                        new Shift(10, 5, 0.5),
                        new Shift(11, 6, 0.5),
                        new Shift(12, 6, 0.5),
                        new Shift(13, 7, 0.5),
                        new Shift(14, 7, 0.5),
                        new Shift(15, 8, 0.5),
                        new Shift(16, 8, 0.5),
                        new Shift(17, 9, 0.5),
                        new Shift(18, 9, 0.5),
                        new Shift(19, 10, 0.5),
                        new Shift(20, 10, 0.5)
                    };
                }
                return _shifts;
            }
            set {
                _shifts = value;
            }
        }

        public void AddEngineerToShift(IShift shift, IEngineer engineer)
        {
            shift.Engineer = engineer;
            engineer.Shifts.Add(shift);
        }

        public void AddShift(IShift shift)
        {
            throw new NotImplementedException();
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
