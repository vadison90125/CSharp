using System.Xml.Linq;

namespace net_2_2
{
    [Serializable]
    public class WindowAttributesString
    {
        const string XmlConfigFile = "users.xml";

        readonly protected static string path = Directory.GetCurrentDirectory();
        readonly protected static string fullPath = Path.Combine(path, $@"Config\{XmlConfigFile}");
        readonly protected static XDocument xdoc = XDocument.Load(fullPath);

        public string Title { get; set; }
        public string Top { get; set; }
        public string Left { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

        public static List<string> OutputAllLogins()
        {
            var results = new List<string>();

            foreach (var element in xdoc.Element("config").Elements("login"))
            {
                var nameLogin = element.Attribute("name").Value;

                if (nameLogin == null)
                {
                    continue;
                }

                var nameWindows = element.Elements("window");
                var windows = new List<WindowAttributesString>();

                foreach (var window in nameWindows)
                {
                    var temp = new WindowAttributesString();
                    temp.Title = window.Attributes("title").FirstOrDefault().Value;

                    foreach (var itemInWindow in window.Elements())
                    {
                        switch (itemInWindow.Name.ToString())
                        {
                            case "top":
                                temp.Top = itemInWindow.Value;
                                break;
                            case "left":
                                temp.Left = itemInWindow.Value;
                                break;
                            case "width":
                                temp.Width = itemInWindow.Value;
                                break;
                            case "height":
                                temp.Height = itemInWindow.Value;
                                break;
                        }
                    }
                    windows.Add(temp);
                }
                
                if (nameWindows != null)
                {
                    results.Add(nameLogin);
                }

                foreach (var window in windows)
                {
                    results.Add(window.ToString());
                }
                
            }
            return results;
        }

        public override string ToString()
        {
            return $"  {Title}({Top ?? "?"}, {Left ?? "?"}, {Width ?? "?"}, {Height ?? "?"})";
        }

    }
}