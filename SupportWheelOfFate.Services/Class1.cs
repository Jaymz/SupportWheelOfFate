using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportWheelOfFate.Services
{
    public interface IScheduleService
    {
        ISchedule GetSchedule();
        void FillSchedule();
    }

    public class ScheduleService : IScheduleService
    {
        private ISchedule _schedule;
        private IWorkforce _workforce;
        private IBusinessRules _rules;

        public ScheduleService(ISchedule schedule, IWorkforce workforce, IBusinessRules rules)
        {
            _schedule = schedule;
            _workforce = workforce;
            _rules = rules;
        }

        public ISchedule GetSchedule()
        {
            return _schedule;
        }

        // Naive schedule fill - ensure all rules are met. Won't work with odd number of shifts
        public void FillSchedule()
        {
            bool tryAgain;
            do {
                tryAgain = false;
                _schedule.ClearSchedule();
                try {
                    for (int i = 0; i < _schedule.Shifts.Count / 2; i++) {
                        PickTwo();
                    }
                }
                catch (Exception ex) {
                    tryAgain = true;
                }
            } while (tryAgain);
        }

        private void PickTwo()
        {
            var nextShifts = _schedule.Shifts.Where(s => s.Engineer == null).OrderBy(s => s.Position).Take(2).ToList();

            var rnd = new Random();
            List<IEngineer> availableEngineers = new List<IEngineer>();

            availableEngineers = _workforce.Engineers.Where(e => e.CanWork(nextShifts[0])).ToList();
            var firstEngineer = availableEngineers[rnd.Next(availableEngineers.Count)];
            _schedule.AddEngineerToShift(nextShifts[0], firstEngineer);

            availableEngineers = _workforce.Engineers.Where(e => e.CanWork(nextShifts[0])).ToList();
            var secondEngineer = availableEngineers[rnd.Next(availableEngineers.Count)];
            _schedule.AddEngineerToShift(nextShifts[1], secondEngineer);
        }
    }
}
