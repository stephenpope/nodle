namespace Nodle.Distribution
{
    public interface INodleLogger
    {
        NodleLogLevel LogLevel { get; }
        void Info(string infoMessage);
        void Warn(string warnMessage);
        void Error(string errorMessage);
    }
}