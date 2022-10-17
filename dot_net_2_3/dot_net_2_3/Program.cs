namespace dot_net_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Logger log = LogManager.GetCurrentClassLogger();
            //log.Trace("trace message");
            //log.Debug("debug message");
            //log.Info("info message");
            //log.Warn("warn message");
            //log.Error("error message");
            //log.Fatal("fatal message");

            var log = new Logger(new TextListener { });

            log.Log(LogLevel.Trace, "Information Message");
            log.Log(LogLevel.Information, "Information Message");
            log.Log(LogLevel.Warning, "Warning Message");
            log.Log(LogLevel.Error, "Error Message");
            log.Log(LogLevel.Critical, "Error Message");

        }

    }
}