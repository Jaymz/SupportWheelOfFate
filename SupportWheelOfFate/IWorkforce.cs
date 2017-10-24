using System.Collections.Generic;

namespace SupportWheelOfFate
{
    public interface IWorkforce
    {
        IList<IEngineer> Engineers { get; set; }

        void AddEngineer(IEngineer engineer);
    }
}
