namespace net_2_1
{
    public class Author
    {
        const int MaxLength = 200;

        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get => _firstName;
            set => _firstName = Helper.CheckedName(value, MaxLength);
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = Helper.CheckedName(value, MaxLength);
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj) =>
            obj is Author author
            && FirstName.ToLower() == author.FirstName.ToLower()
            && LastName.ToLower() == author.LastName.ToLower();

        public override int GetHashCode()
        {
            return (FirstName + LastName).ToLower().GetHashCode();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
