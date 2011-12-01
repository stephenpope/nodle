namespace Nodle.Distribution
{
    public interface INodleDistributionConfig
    {
        string AccessKey { get; }
        string BaseUrl { get; }
        string Channel { get; }
    }
}