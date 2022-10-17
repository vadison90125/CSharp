namespace dot_net_2_3
{
    interface IListener
    {
        void Log(LogLevel level, string message);

        void Trace(string message);

        void LogInformation(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogCritical(string message);
    }
}
