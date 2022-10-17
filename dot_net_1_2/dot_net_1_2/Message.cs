namespace dot_net_1_2
{
    public class Message<T> : EventArgs
    {
        public int i { get; private set; }
        public int j { get; private set; }
        public T Data { get; private set; }

        public Message(int x, int y, T data)
        {
            i = x;
            j = y;
            Data = data;
        }

    }
}
