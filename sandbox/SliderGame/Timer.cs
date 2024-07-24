public class Timer
{
    DateTime _startTime;

    public void Start()
    {
        _startTime = DateTime.Now;
    }

    public TimeSpan GetElapsedTime()
    {
        DateTime currentTime = DateTime.Now;
        TimeSpan difference = currentTime - _startTime;
        return difference;
    }
}
