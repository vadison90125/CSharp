namespace net_1_2
{
    class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix()
        {
            elementsMatrix = new T[Dimension];
        }

        protected override int GetIndex(int i, int j)
        {
            return i;
        }

    }
}
