using System.Collections.Generic;

namespace SupportWheelOfFate
{
    public class Workforce : IWorkforce
    {
        public Workforce()
        {
            Engineers = new List<IEngineer>();
        }

        public IList<IEngineer> Engineers { get; set; }
        public void AddEngineer(IEngineer engineer)
        {
            Engineers.Add(engineer);
        }
    }
}
