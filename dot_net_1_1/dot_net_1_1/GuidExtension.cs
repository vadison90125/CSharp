namespace dot_net_1_1
{
    static class GuidExtension
    {
        public static Guid GetNewId(this Entity id)
        {
            return Guid.NewGuid();
        }

    }
}
