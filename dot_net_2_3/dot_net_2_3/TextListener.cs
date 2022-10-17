namespace dot_net_2_3
{
    class TextListener
    {
        const string logFile = "log.txt";
        static readonly string path = Directory.GetCurrentDirectory();
        readonly string pathToLog = Path.Combine(path, logFile);

        public async void WriteLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(pathToLog, true, System.Text.Encoding.Default))
            {
                await sw.WriteLineAsync(message);
            }
        }

    }
}
