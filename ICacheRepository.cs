namespace DotnetRedis
{
    public interface ICacheRepository
    {
        string GetString(string key);

        void SetString(string key, string value, int timeOutHours);
    }
}