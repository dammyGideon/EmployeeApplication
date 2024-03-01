namespace Contracts
{
    public interface ILoggerManager
    {
        Task Loginfo (string message);
        Task LogWarning (string message);
        Task Debug (string message);
        Task LogError (string message);

    }
}