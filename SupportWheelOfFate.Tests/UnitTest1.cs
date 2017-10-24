using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;
using SupportWheelOfFate.Services;
using System.Linq;

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
    }
}
