namespace net_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var allLogins in WindowAttributesString.OutputAllLogins())
            {
                Console.WriteLine(allLogins);
            }

            Console.WriteLine();
            Console.WriteLine("Press eny key to create file for NOT TRUE logins");
            Console.ReadKey();
            Console.WriteLine();

            foreach (var notTrueLogins in WindowAttributesInt.OutputNotTrueLogins())
            {
                Console.WriteLine(notTrueLogins);
            }

            WindowAttributesInt.DeleteEmptyFiles();
        }

    }
}