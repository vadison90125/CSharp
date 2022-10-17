using System.Collections;

namespace dot_net_2_1
{
    public class Catalog : IEnumerable<Book>, IEnumerable
    {
        private Dictionary<string, Book> _catalog = new Dictionary<string, Book>();

        public Catalog(IEnumerable<Book> books)
        {
            AddBooks(books.ToArray());
        }

        public Book this[string isbn]
        {
            get
            {
                if (isbn == null)
                {
                    throw new ArgumentNullException(nameof(isbn));
                }

                var isbnNorm = isbn.Replace("-", "");
                if (_catalog.ContainsKey(isbnNorm))
                {
                    return _catalog[isbn];
                }
                throw new ArgumentException();
            }
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }
            if (!_catalog.ContainsKey(book.Isbn))
            {
                _catalog[book.Isbn] = book;
            }
        }


        public void AddBooks(params Book[] books)
        {
            foreach (var book in books)
            {
                if (book != null)
                {
                    AddBook(book);
                }
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in _catalog.Values)
            {
                yield return book;
            }
            //return _catalog.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Book> GetBooksSortByName()
        {
            var result = _catalog.OrderBy(x => x.Value.NameBook).Select(x => x.Value);
            return result;
        }

        public IEnumerable<Book> GetBooksByFirstNameLastName(Author author)
        {
            var result = _catalog
                .Where(el => el.Value.Authors
                .Contains(author))
                .Select(x => x.Value);
            return result;
        }

        public IEnumerable<Book> GetBooksSortByDateDescending()
        {
            var result = _catalog.OrderByDescending(x => x.Value.Date).Select(x => x.Value);
            return result;
        }

        public IEnumerable<(string author, int count)> GetTupleAuthorCountBooks()
        {
            var result = new List<(string author, int count)>();
            foreach (var auth in _catalog.Values.SelectMany(x => x.Authors).Distinct())
            {
                var countOfBooks = _catalog.Values.Where(x => x.Authors.Contains(auth)).Count();
                result.Add((auth.ToString(), countOfBooks));
            }
            return result;
        }
        //return _catalog.SelectMany(x => x.Value.Author).GroupBy(x => x).Select(g.Key.ToString(), g.Value.Author.Count());

    }
}
