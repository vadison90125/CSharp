namespace net_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("FirstName1", "LastName1");
            Author author2 = new Author("FirstName2", "LastName2");
            Author author3 = new Author("FirstName3", "LastName3");

            Book book1 = new Book("1234567891011", "NameBook4", DateTime.Parse("1.1.2022"), author1);
            Book book2 = new Book("123-4-56-789101-2", "NameBook2", DateTime.Parse("2.2.2022"), author1, author2);
            Book book3 = new Book("9876543210011", "NameBook3", DateTime.Parse("3.3.2022"), author1, author2, author3);

            var books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            Catalog catal = new Catalog(books);

            Console.WriteLine("Sort books by nameBook:");
            var res1 = catal.GetBooksSortByName();
            foreach (var r in res1)
                Console.WriteLine(r.ToString());
            Console.WriteLine();

            Console.WriteLine("List books by firstName && lastName:");
            var res2 = catal.GetBooksByFirstNameLastName(author3);
            foreach (var r in res2)
                Console.WriteLine(r.ToString());
            Console.WriteLine();

            Console.WriteLine("List books by date to descending:");
            var res3 = catal.GetBooksSortByDateDescending();
            foreach (var r in res3)
                Console.WriteLine(r.ToString());
            Console.WriteLine();

            Console.WriteLine("List tuples (Author - Count books):");
            var res4 = catal.GetTupleAuthorCountBooks();
            foreach (var r in res4)
                Console.WriteLine(r.ToString());
            Console.WriteLine();

            Console.WriteLine(catal["9876543210011"]);
            Console.WriteLine();

            bool r1 = book1.Equals(book2);
            Console.WriteLine(r1);
            bool r2 = book1.Equals(book3);
            Console.WriteLine(r2);
            bool r3 = book2.Equals(book3);
            Console.WriteLine(r3);

            Console.ReadLine();
        }

    }
}
