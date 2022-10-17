namespace dot_net_1_1
{

    class TextMaterial : BaseMaterial
    {
        const int MAX_LENGTH = 10000;
       
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value.Length >= 1 && value.Length <= MAX_LENGTH)
                {
                    _text = value;
                }
                else
                {
                    throw new ArgumentException("");
                }
            }
        }
        public TextMaterial(string text, string description) : base(description)
        {
            Text = text;
        }

        public object Clone()
        {
            TextMaterial clonedTextMaterial = new TextMaterial(Text, Description);

            return clonedTextMaterial;
        }

    }
}
