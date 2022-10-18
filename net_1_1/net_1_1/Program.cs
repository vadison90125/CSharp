namespace net_1_1
{
    class Program
    {

        static void Main(string[] args)
        {

            TextMaterial text = new TextMaterial("text", "description1-text");
            VideoMaterial video = new VideoMaterial("www.video...", "www.picture...", FormatVideo.Mp4, "description2-video");
            NetMaterial netmaterial = new NetMaterial("www.content...", TypeLink.Html, "description3-netmaterial");
            BaseMaterial basematerial = new BaseMaterial("description4-basematerial");
            TraningLesson traninglesson = new TraningLesson("description5-lesson");

            var materials = new BaseMaterial[3];
            materials[0] = text;
            materials[1] = video;
            materials[2] = netmaterial;

            for (int i = 0; i < materials.Length; i++)
            {
                traninglesson.AddMaterial(materials[i]);
            }
            Console.WriteLine(traninglesson.GetLessonType());
            Console.WriteLine();

            var description = new BaseMaterial[4];
            description[0] = text;
            description[1] = video;
            description[2] = netmaterial;
            description[3] = basematerial;

            for (int i = 0; i < description.Length; i++)
            {
                Console.WriteLine(description[i].ToString());
            }
            Console.WriteLine();

            text.Id = text.GetNewId();
            Console.WriteLine(text.Id);
            video.Id = video.GetNewId();
            Console.WriteLine(video.Id);

            video.Id = text.Id;

            Console.WriteLine(text.Equals(video));
            Console.WriteLine();

            traninglesson.SetVersion(new byte[] { 1, 1, 1, 1, 1, 1, 1, 1 });

            video.SetVersion(new byte[] { 2, 2, 2, 2, 2, 2, 2, 2 });

            var newversion = (TraningLesson)traninglesson.Clone();

            newversion._version[2] = 99;
            Console.WriteLine(newversion._version[2]);
            Console.WriteLine(traninglesson._version[2]);

            newversion.Description = "New description";
            Console.WriteLine(newversion.ToString());
            Console.WriteLine(traninglesson.ToString());

            Console.ReadLine();
        }

    }
}