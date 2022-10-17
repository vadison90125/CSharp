namespace dot_net_2_3
{
    class Logger : IListener
    {
        private readonly TextListener _file;

        private readonly string _currentTime = DateTime.Now.ToLongTimeString();

        public Logger(TextListener file)
        {
            _file = file;
        }

        private string CastMessage(LogLevel level, string message)
        {
            return $"{_currentTime} | {level} | {message}";
        }

        public void Log(LogLevel level, string message)
        {
            var response = CastMessage(level, message);
            switch (level)
            {
                case LogLevel.Trace:
                    LogInformation(response);
                    break;
                case LogLevel.Information:
                    LogInformation(response);
                    break;
                case LogLevel.Warning:
                    LogWarning(response);
                    break;
                case LogLevel.Error:
                    LogError(response);
                    break;
                case LogLevel.Critical:
                    LogCritical(response);
                    break;
            }
        }

        public void Trace(string message)
        {
            _file.WriteLog(message);
        }

        public void LogInformation(string message)
        {
            _file.WriteLog(message);
        }

        public void LogWarning(string message)
        {
            _file.WriteLog(message);
        }

        public void LogError(string message)
        {
            _file.WriteLog(message);
        }

        public void LogCritical(string message)
        {
            _file.WriteLog(message);
        }

    }
}
