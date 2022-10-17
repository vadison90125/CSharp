namespace dot_net_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            DiagonalMatrix<int> diagMatrix = new DiagonalMatrix<int>();
            IntMatrix intMatrix = new IntMatrix(3);

            matrix.OnChanged += OutputNewValue;

            Random random = new Random();

            for (int i = 0; i < SquareMatrix<int>.Dimension; i++)
            {
                for (int j = 0; j < SquareMatrix<int>.Dimension; j++)
                {
                    matrix[i, j] = random.Next(0, 9);
                }
            }
            Console.WriteLine(matrix.ToString());

            for (int i = 0; i < SquareMatrix<int>.Dimension; i++)
            {
                for (int j = 0; j < SquareMatrix<int>.Dimension; j++)
                {
                    diagMatrix[i, j] = random.Next(0, 9);
                }
            }
            Console.WriteLine(diagMatrix.ToString());

            try
            {
                SquareMatrix<int> badMatrix = new SquareMatrix<int>(-3);
            }
            catch (MatrixException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                matrix[3, 3] = 4;
            }
            catch (MatrixException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            matrix[0, 0] = 4;

            Console.ReadKey();
        }

        static void OutputNewValue(object sender, Message<int> arg)
        {
            Console.WriteLine($"{arg.i}, {arg.j}, {arg.Data}");
        }

    }
}