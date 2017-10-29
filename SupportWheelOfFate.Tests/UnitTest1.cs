using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using SupportWheelOfFate.Services;
using System.Linq;
using SupportWheelOfFate.Mocks;

namespace SupportWheelOfFate.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IContainer _container;
        protected IContainer Container {
            get {
                if (_container == null) {
                    var builder = new ContainerBuilder();
                    builder.RegisterType<TaskBusinessRules>().As<IBusinessRules>();
                    builder.RegisterType<MockWorkforce>().As<IWorkforce>().SingleInstance();
                    builder.RegisterType<MockSchedule>().As<ISchedule>().SingleInstance();
                    builder.RegisterType<EngineerFactory>().As<IEngineerFactory>().SingleInstance();
                    builder.RegisterType<ScheduleService>().As<IScheduleService>().SingleInstance();

                    _container = builder.Build();
                }

                return _container;
            }
        }

        [TestMethod]
        public void CanFillSchedule()
        {
            var service = Container.Resolve<IScheduleService>();
            service.FillSchedule();

            Assert.IsNotNull(service.GetSchedule().Shifts.Last().Engineer);
        }

        [TestMethod]
        public void NoConsecutiveDaysWorked()
        {
            var service = Container.Resolve<IScheduleService>();
            service.FillSchedule();

            var rules = Container.Resolve<IBusinessRules>();
            var schedule = service.GetSchedule();
            var shiftsPerDay = rules.ShiftsPerDay;

            for (int i = shiftsPerDay; i < schedule.Shifts.Count; i++) {
                var eng = schedule.Shifts[i].Engineer;
                foreach (var shift in schedule.Shifts.Where(s => s.Day == schedule.Shifts[i].Day && s != schedule.Shifts[i])) {
                    Assert.AreNotEqual(eng, shift.Engineer);
                }

                foreach (var shift in schedule.Shifts.Where(s => s.Day == schedule.Shifts[i].Day - 1)) {
                    Assert.AreNotEqual(eng, shift.Engineer);
                }
            }
        }
    }
}
