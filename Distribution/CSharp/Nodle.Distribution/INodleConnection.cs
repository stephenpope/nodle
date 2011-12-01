namespace Nodle.Distribution
{
    public interface INodleConnection
    {
        void Send(INodelMessage message);
    }
}