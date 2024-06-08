namespace Wator;

class Chronon
{
    private uint _delayDuration = 0;

    // (use this default constructor for unlimited simulation speed)
    public Chronon() {}
    public Chronon(uint delay) { _delayDuration = delay; }

    // mechanism to control the speed of the simulation
    public void Tick()
    {
        if (_delayDuration > 0)
        {
            Thread.Sleep((int)_delayDuration);
        }
    }
}