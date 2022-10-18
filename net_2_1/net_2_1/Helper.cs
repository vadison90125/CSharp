namespace net_2_1
{
    public static class Helper
    {
        public static string CheckedName(string name, int maxLength)
        {
            if (string.IsNullOrEmpty(name) || name.Length > maxLength)
            {
                throw new ArgumentException("");
            }
            return name;
        }

    }
}
