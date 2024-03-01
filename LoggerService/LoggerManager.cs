using Contracts;
using NLog;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();
        public LoggerManager() { }
        public async Task Debug(string message)
        {
            logger.Debug(message);
        }

        public async Task LogError(string message)
        {
            logger.Error(message);
        }

        public async Task Loginfo(string message)
        {
            logger.Info(message);
        }

        public async Task LogWarning(string message)
        {
            logger.Warn(message);
        }
    }
}