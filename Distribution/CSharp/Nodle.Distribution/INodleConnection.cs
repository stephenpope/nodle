namespace Nodle.Distribution
{
    public interface INodleConnection
    {
        void Send(INodleMessage message);
    }
}