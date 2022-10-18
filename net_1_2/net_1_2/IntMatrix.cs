namespace net_1_2
{
    class IntMatrix : SquareMatrix<int>
    {
        public IntMatrix(int dimension) : base(dimension)
        {
        }

        public IntMatrix AddMatrix(IntMatrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (Dimension != SquareMatrix<int>.Dimension)
            {
                throw new MatrixException("Wrong dimension of matrix");
            }

            IntMatrix newMatrix = new IntMatrix(Dimension);

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    newMatrix[i, j] = this[i, j] + matrix[i, j];
                }
            }
            return newMatrix;
        }

        public IntMatrix MultMatrix(IntMatrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (Dimension != SquareMatrix<int>.Dimension)
            {
                throw new MatrixException("Wrong dimension of matrix");
            }

            IntMatrix newMatrix = new IntMatrix(Dimension);

            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    for (int k = 0; k < Dimension; k++)
                    {
                        newMatrix[i, j] += this[i, k] * matrix[k, j];
                    }
                }
            }
            return newMatrix;
        }

        public IntMatrix MultChisloMatrix(IntMatrix matrix, int chislo)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            if (Dimension != SquareMatrix<int>.Dimension)
            {
                throw new MatrixException("Wrong dimension of matrix");
            }

            IntMatrix newMatrix = new IntMatrix(Dimension);

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