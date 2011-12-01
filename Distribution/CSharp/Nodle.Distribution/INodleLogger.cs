namespace Nodle.Distribution
{
    public interface INodleLogger
    {
        void Info(string infoMessage);
        void Warn(string warnMessage);
        void Error(string errorMessage);
    }
}