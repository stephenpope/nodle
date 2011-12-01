namespace Nodle.Distribution
{
    public class NullNodleLogger : INodleLogger
    {
        public NodleLogLevel LogLevel
        {
            get { return NodleLogLevel.INFO; }
        }

        public void Info(string infoMessage)
        {
            return;
        }

        public void Warn(string warnMessage)
        {
            return;
        }

        public void Error(string errorMessage)
        {
            return;
        }
    }
}