using System.Text.Json;
using System.Text.Json.Serialization;

namespace net_2_2
{
    [Serializable]
    public class WindowAttributesInt : WindowAttributesString
    {
        static string nameFile = null;
        static int countMain;

        readonly protected static string fullPathJson = Path.Combine(path, $@"Config\");

        public new string Title { get; set; }
        public new int? Top { get; set; }
        public new int? Left { get; set; }
        public new int? Width { get; set; }
        public new int? Height { get; set; }

        public static List<string> OutputNotTrueLogins()
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
                var windows = new List<WindowAttributesInt>();

                foreach (var window in nameWindows)
                {
                    var temp = new WindowAttributesInt();
                    temp.Title = window.Attributes("title").FirstOrDefault().Value;

                    foreach (var itemInWindow in window.Elements())
                    {
                        switch (itemInWindow.Name.ToString())
                        {
                            case "top":
                                temp.Top = int.Parse(itemInWindow.Value);
                                break;
                            case "left":
                                temp.Left = int.Parse(itemInWindow.Value);
                                break;
                            case "width":
                                temp.Width = int.Parse(itemInWindow.Value);
                                break;
                            case "height":
                                temp.Height = int.Parse(itemInWindow.Value);
                                break;
                        }
                    }

                    if (!(nameWindows.Count() == 1
                        && temp.Top != null
                        && temp.Left != null
                        && temp.Width != null
                        && temp.Height != null))
                    {
                        windows.Add(temp);
                    }
                }

                countMain = 0;
                for (int i = 0; i < windows.Count; i++)
                {
                    if (windows[i].Title == "main")
                    {
                        countMain++;
                    }
                }

                if (countMain == 0)
                {
                    for (int i = 0; i < windows.Count; i++)
                    {
                        windows.RemoveAt(i);
                    }
                }

                if (nameWindows != null)
                {
                    nameFile = nameLogin ?? "?";
                }

                using FileStream fs = new FileStream(Path.GetFullPath(fullPathJson) + $"{nameFile}.json", FileMode.OpenOrCreate);
                if (windows.Count != 0)
                {
                    results.Add(nameLogin);
                }

                foreach (var window in windows)
                {
                    window.SetNulls();
                    results.Add(window.ToString());
                }

                //var options = new JsonSerializerOptions()
                //{
                //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //    WriteIndented = true
                //};

                JsonSerializerOptions options = new()
                {
                    NumberHandling = JsonNumberHandling.Strict,
                    WriteIndented = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                };
                JsonSerializer.Serialize(fs, windows, options);
            }
            return results;
        }

        public override string ToString()
        {
            return $"  {Title}({Top}, {Left}, {Width}, {Height})";
        }

        public void SetNulls()
        {
            Top ??= 0;
            Left ??= 0;
            Width ??= 400;
            Height ??= 150;
        }

        public static void DeleteEmptyFiles()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetFullPath(fullPathJson));
            FileInfo[] fileInfoArr = dirInfo.GetFiles();
            foreach (FileInfo f in fileInfoArr)
                if (f.Length == 2) f.Delete();
        }

    }
}