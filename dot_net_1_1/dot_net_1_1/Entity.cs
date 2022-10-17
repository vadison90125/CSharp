namespace dot_net_1_1
{
    abstract class Entity
    {

        const int MAX_LENGTH = 256;

        public Guid Id { get; set; }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (string.IsNullOrEmpty(value) != true && value.Length <= MAX_LENGTH)
                {
                    _description = value;
                }
                else
                {
                    throw new ArgumentException("");
                }
            }
        }

        public Entity(string description)
        {
            Description = description;
        }

    }
}
