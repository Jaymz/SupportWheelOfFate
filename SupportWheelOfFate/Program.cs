using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportWheelOfFate
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TaskBusinessRules>().As<IBusinessRules>();
            builder.RegisterType<Workforce>().As<IWorkforce>().SingleInstance();
            builder.RegisterType<Schedule>().As<ISchedule>().SingleInstance();
            builder.RegisterType<EngineerFactory>().As<IEngineerFactory>().SingleInstance();
            var container = builder.Build();

            var workforce = container.Resolve<IWorkforce>();
            var engFactory = container.Resolve<IEngineerFactory>();

            var engineers = new List<IEngineer>() {
                engFactory.Create("A", 1),
                engFactory.Create("B", 1),
                engFactory.Create("C", 1),
                engFactory.Create("D", 1),
                engFactory.Create("E", 1),
                engFactory.Create("F", 1),
                engFactory.Create("G", 1),
                engFactory.Create("H", 1),
                engFactory.Create("I", 1),
                engFactory.Create("J", 1)
            };

            foreach (var engineer in engineers) {
                workforce.AddEngineer(engineer);
            }

            var shifts = new Shift[] {
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

            var schedule = container.Resolve<ISchedule>();
            foreach (var shift in shifts) {
                schedule.AddShift(shift);
            }

            FillScheduleRandom(schedule, workforce);
            
            schedule.PrintSchedule();

            Console.WriteLine("Complete");
            Console.ReadLine();
        }

        public static void FillScheduleRandom(ISchedule schedule, IWorkforce workforce)
        {
            bool tryAgain;
            do {
                tryAgain = false;
                schedule.ClearSchedule();
                try {
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                    PickTwo(schedule, workforce);
                }
                catch (Exception) {
                    tryAgain = true;
                }
            } while (tryAgain);
        }

        public static void RoundRobin(ISchedule schedule, IWorkforce workforce)
        {
            for (int i = 0; i < schedule.Shifts.Count(); i++) {
                schedule.Shifts.ElementAt(i).Engineer = workforce.Engineers.ElementAt(i % workforce.Engineers.Count());
            }

            foreach (var shift in schedule.Shifts) {
                Console.WriteLine($"Shift {shift.Position}: Engineer {shift.Engineer.Name}");
            }
        }

        public static void PickTwo(ISchedule schedule, IWorkforce workforce)
        {
            var nextShifts = schedule.Shifts.Where(s => s.Engineer == null).OrderBy(s => s.Position).Take(2).ToList();

            var rnd = new Random();
            List<IEngineer> availableEngineers = new List<IEngineer>();
            
            availableEngineers = workforce.Engineers.Where(e => e.CanWork(nextShifts[0])).ToList();
            var firstEngineer = availableEngineers[rnd.Next(availableEngineers.Count)];
            schedule.AddEngineerToShift(nextShifts[0], firstEngineer);

            availableEngineers = workforce.Engineers.Where(e => e.CanWork(nextShifts[0])).ToList();
            var secondEngineer = availableEngineers[rnd.Next(availableEngineers.Count)];
            schedule.AddEngineerToShift(nextShifts[1], secondEngineer);

            //Console.WriteLine(availableEngineers[rnd.Next(availableEngineers.Count)].Name);
        }
    }
}
