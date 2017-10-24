using System;
using System.Collections.Generic;
using System.Linq;

namespace SupportWheelOfFate
{
    public class Engineer : IEngineer
    {
        private IBusinessRules _rules;

        public Engineer(IBusinessRules rules, string name, double maxShiftDuration)
        {
            Name = name;
            MaxShiftDuration = maxShiftDuration;
            Shifts = new List<IShift>();
            _rules = rules;
        }

        public string Name { get; set; }

        public double ShiftDuration {
            get {
                return Shifts.Sum(s => s.Duration);
            }
        }

        public IList<IShift> Shifts { get; set; }
        public double MaxShiftDuration { get; set; }
        public bool CanWork()
        {
            // If variable length shifts, should also check specific shift duration
            return ShiftDuration < MaxShiftDuration;
        }

        public bool CanWork(IShift shift)
        {
            if (_rules == null)
                throw new ArgumentNullException("IBusinessRules", "Business Rules object must be set before CanWork can be called");

            if (ShiftDuration >= MaxShiftDuration)
                return false;

            if (!_rules.AllowConsecutiveDays)
                if (Shifts.Any(s => s.Day == shift.Day - 1))
                    return false;

            if (Shifts.Count(s => s.Day == shift.Day) >= _rules.MaxShiftsPerDay)
                return false;

            return true;
        }
    }
}
