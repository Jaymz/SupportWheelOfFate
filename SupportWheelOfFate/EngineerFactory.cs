namespace SupportWheelOfFate
{
    public class EngineerFactory : IEngineerFactory
    {
        private IBusinessRules _rules;
        public EngineerFactory(IBusinessRules rules)
        {
            _rules = rules;
        }

        public IEngineer Create(string name, double maxShiftDuration)
        {
            return new Engineer(_rules, name, maxShiftDuration);
        }
    }
}
