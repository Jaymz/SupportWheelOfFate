using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportWheelOfFate.Tests
{
    public class MockWorkforce : IWorkforce
    {
        public MockWorkforce(IEngineerFactory engFactory)
        {
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
                AddEngineer(engineer);
            }
        }

        public IList<IEngineer> Engineers { get; set; }

        public void AddEngineer(IEngineer engineer)
        {
            if (Engineers == null)
                Engineers = new List<IEngineer>();

            Engineers.Add(engineer);
        }
    }
}
