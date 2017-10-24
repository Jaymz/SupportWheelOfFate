namespace SupportWheelOfFate
{
    public class Shift : IShift
    {
        public Shift(int position, int day, double duration)
        {
            Position = position;
            Duration = duration;
            Day = day;
        }

        public int Day { get; set; }
        public double Duration { get; set; }
        public IEngineer Engineer { get; set; }

        public int Position { get; }
    }
}
