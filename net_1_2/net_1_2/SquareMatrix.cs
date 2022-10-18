namespace net_1_2
{
    class SquareMatrix<T>
    {
        public delegate void EventHandler(object sender, Message<T> arg);
        public event EventHandler OnChanged;

        private static int _dimension;
        public static int Dimension
        {
            get => _dimension;
            private set
            {
                if (value > 0)
                {
                    _dimension = value;
                }
                else
                {
                    throw new MatrixException("Wrong dimension");
                }
            }
        }

        protected T[] elementsMatrix;

        public SquareMatrix(int dimension)
        {
            elementsMatrix = new T[dimension * dimension];
            Dimension = dimension;
        }

        public SquareMatrix()
        {
        }

        protected virtual int GetIndex(int i, int j)
        {
            return i * Dimension + j;
        }


        public T this[int i, int j]
        {
            get
            {
                CheckIndex(i, j);
                int index = GetIndex(i, j);
                return elementsMatrix[index];
            }
            set
            {
                CheckIndex(i, j);
                int index = GetIndex(i, j);
                if (!elementsMatrix[index].Equals(value))
                {
                    OnChanged?.Invoke(this, new Message<T>(i, j, value));
                }
                
            }
        }

        private void CheckIndex(int i, int j)
        {
            if (i >= 0 && i < Dimension && j >= 0 && j < Dimension)
            {
                return;
            }
            throw new MatrixException("Wrong index");
        }

        public override string ToString() => string.Join(" ", elementsMatrix);

    }
}