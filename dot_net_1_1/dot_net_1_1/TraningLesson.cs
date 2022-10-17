namespace dot_net_1_1
{
    enum LessonType
    {
        VideoLesson,
        TextLesson
    }

    class TraningLesson : Entity, IVersionable, ICloneable
    {
        const int VERSION_LENGTH = 8;

        public byte[] _version;

        public TraningLesson(string description) : base(description)
        {
        }


        List<BaseMaterial> materials = new List<BaseMaterial>();
        public void AddMaterial(BaseMaterial material)
        {
            materials.Add(material);
        }


        public object Clone()
        {
            TraningLesson clonedLesson = new TraningLesson(Description);

            clonedLesson._version = new byte[VERSION_LENGTH];
            Array.Copy(_version, clonedLesson._version, VERSION_LENGTH);

            List<BaseMaterial> newList = new List<BaseMaterial>();
            for (int i = 0; i < materials.Count; i++)
            {
                newList.Add((BaseMaterial)materials[i].Clone());
            }
            
            return clonedLesson;
        }

        public LessonType GetLessonType()
        {
            foreach (var material in materials)
            {
                if (material is VideoMaterial)
                {
                    return LessonType.VideoLesson;
                }
            }
            return LessonType.TextLesson;
        }

        public override string ToString()
        {
            return Description;
        }


        public byte[] GetVersion()
        {
            return _version;
        }

        public void SetVersion(byte[] version)
        {
            if (version.Length == VERSION_LENGTH)
            {
                _version = version;
            }
            else
            {
                throw new ArgumentException("");
            }
        }

    }
}