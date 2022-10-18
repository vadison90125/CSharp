namespace net_1_2
{
    class OperatorOverloading : SquareMatrix<int>
    {
        public OperatorOverloading(int dimension) : base(dimension)
        {
        }

        public static OperatorOverloading operator +(OperatorOverloading matrix1, OperatorOverloading matrix2)
        {
            OperatorOverloading newMatrix = new OperatorOverloading(Dimension);

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    newMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return newMatrix;
        }

        public static OperatorOverloading operator *(OperatorOverloading matrix1, OperatorOverloading matrix2)
        {
            OperatorOverloading newMatrix = new OperatorOverloading(Dimension);

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    for (int k = 0; k < Dimension; k++)
                    {
                        newMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return newMatrix;
        }

        public static OperatorOverloading operator *(OperatorOverloading matrix, int chislo)
        {
            OperatorOverloading newMatrix = new OperatorOverloading(Dimension);

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    newMatrix[i, j] += matrix[i, j] * chislo;
                }
            }
            return newMatrix;
        }

    }
}
