using System.Text.RegularExpressions;

namespace dot_net_2_1
{
    public class Book
    {
        const int MaxLength = 1000;
        const string pattern1 = @"[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}";
        const string pattern2 = @"[0-9]{13}";

        private string _isbn;
        private string _nameBook;

        public DateTime Date { get; set; }
        public IList<Author> Authors { get; set; } = new List<Author>();

        public string Isbn
        {
            get => _isbn;

            set
            {
                if (!Regex.IsMatch(value, pattern1, RegexOptions.IgnoreCase)
                    && !Regex.IsMatch(value, pattern2, RegexOptions.IgnoreCase))
                {
                    throw new ArgumentException("");
                }
                _isbn = value.Replace("-", "");
            }
        }

        public string NameBook
        {
            get => _nameBook;

            set
            {
                if (string.IsNullOrEmpty(value) == true || value.Length > MaxLength)
                {
                    throw new ArgumentException("");
                }
                _nameBook = value;
            }
        }

        public Book(string isbn) :
            this(isbn, "", DateTime.MinValue, Array.Empty<Author>())
        { }

        public Book(string isbn, string nameBook, DateTime date, List<Author> author) :
            this(isbn, nameBook, date, author.ToArray())
        { }

        public Book(string isbn, string nameBook, DateTime date, params Author[] authors)
        {
            NameBook = nameBook;
            Isbn = isbn;
            Date = date;
            foreach (var author in authors)
            {
                if (author != null)
                {
                    if (!Authors.Contains(author))
                    {
                        Authors.Add(author);
                    }
                }
            }
        }

        public override bool Equals(object obj) =>
            (obj is Book temp)
            && (_isbn == temp._isbn);

        public override int GetHashCode() => _isbn.GetHashCode();

        public override string ToString()
        {
            var listOfAuthors = "";
            foreach (var auth in Authors)
            {
                listOfAuthors += auth.FirstName + " " + auth.LastName + "/";
            }
            return $"{Isbn} {NameBook} {Date.Year} {listOfAuthors}";
        }

    }
}
