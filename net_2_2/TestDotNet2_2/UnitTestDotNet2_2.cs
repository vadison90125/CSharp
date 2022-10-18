using net_2_2;

namespace TestDotNet2_2
{
    [TestClass]
    public class UnitTestDotNet2_2
    {

        [TestMethod]
        public void TestUser4Json()
        {
            const string JsonFile = "user4.json";
            const string User = "user4.txt";
            string actual;
            string expected;

            //string data ="[\n  {\n    \"title\": \"main\",\n    " +
            //    "\"top\": \"10\",\n    " +
            //    "\"left\": \"10\",\n    " +
            //    "\"width\": \"400\",\n    " +
            //    "\"height\": \"10\"\n  }\n]";

            var path = Directory.GetCurrentDirectory();

            var fullPathJson = Path.Combine(path, $@"Config\{JsonFile}");
            var fullPathUser = Path.Combine(path, $@"Config\{User}");

            //using (StreamWriter writer = new StreamWriter(fullPathUser, false))
            //{
            //    writer.Write(data);
            //}

            using (FileStream fileActual = File.OpenRead(fullPathUser))
            {
                byte[] array = new byte[fileActual.Length];
                fileActual.Read(array, 0, array.Length);

                string exp = System.Text.Encoding.Default.GetString(array);
                expected = exp;
            }


            using (FileStream fileActual = File.OpenRead(fullPathJson))
            {
                byte[] array = new byte[fileActual.Length];
                fileActual.Read(array, 0, array.Length);

                string act = System.Text.Encoding.Default.GetString(array);
                actual = act;
            }

            Assert.AreEqual(expected, actual, $"Error: not corrected ");
        }

    }
}