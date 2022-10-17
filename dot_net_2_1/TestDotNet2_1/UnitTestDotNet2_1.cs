using dot_net_2_1;

namespace TestDotNet2_1
{
    [TestClass]
    public class UnitTestDotNet2_1
    {
        // Arrange
        private static Author author1 = new Author("FirstName1", "LastName1");
        private static Author author2 = new Author("FirstName2", "LastName2");
        private static Author author3 = new Author("FirstName3", "LastName3");

        private static Book book1 = new Book("1234567891011", "NameBook4", DateTime.Parse("1.1.2022"), author1);
        private static Book book2 = new Book("123-4-56-789101-2", "NameBook2", DateTime.Parse("2.2.2022"), author1, author2);
        private static Book book3 = new Book("9876543210011", "NameBook3", DateTime.Parse("3.3.2022"), author1, author2, author3);

        private static List<Book> books = new List<Book>() { book1, book2, book3 };

        Catalog catal = new Catalog(books);


        [TestMethod]
        public void TestGetBooksSortByName()
        {
            // Act
            var expected = new List<Book>();
            expected.Add(book2);
            expected.Add(book3);
            expected.Add(book1);

            IEnumerable<Book> actual = catal.GetBooksSortByName();

            // Assert 
            CollectionAssert.AreEqual(expected, actual.ToList(), $"Error: {actual} - not corrected ");
        }


        [TestMethod]
        public void TestGetBooksByFirstNameLastName()
        {
            // Act
            var expected = new List<Book>();
            expected.Add(book3);

            IEnumerable<Book> actual = catal.GetBooksByFirstNameLastName(author3);

            // Assert 
            CollectionAssert.AreEqual(expected, actual.ToList(), $"Error: {actual} - not corrected ");
        }

        [TestMethod]
        public void TestGetBooksSortByDateDescending()
        {
            // Act
            var expected = new List<Book>();
            expected.Add(book3);
            expected.Add(book2);
            expected.Add(book1);

            IEnumerable<Book> actual = catal.GetBooksSortByDateDescending();

            // Assert 
            CollectionAssert.AreEqual(expected, actual.ToList(), $"Error: {actual} - not corrected ");
        }

        [TestMethod]
        public void TestGetTupleAuthorCountBooks()
        {
            // Act
            var expected = new List<(string, int)>();
            expected.Add((author1.ToString(), 3));
            expected.Add((author2.ToString(), 2));
            expected.Add((author3.ToString(), 1));

            IEnumerable<(string author, int count)> actual = catal.GetTupleAuthorCountBooks();

            // Assert 
            CollectionAssert.AreEqual(expected, actual.ToList(), $"Error: {actual} - not corrected ");
        }

    }
}
