namespace SupportWheelOfFate
{
    public interface IShift
    {
        int Day { get; set; }
        double Duration { get; set; }
        int Position { get; }
        IEngineer Engineer { get; set; }
    }
}
