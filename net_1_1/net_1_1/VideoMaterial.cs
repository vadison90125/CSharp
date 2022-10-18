namespace net_1_1
{
    enum FormatVideo
    {
        Unknown,
        Avi,
        Mp4,
        Flv
    }

    class VideoMaterial : BaseMaterial, IVersionable
    {
        const int VERSION_LENGTH = 8;

        private string urlVideo;
        private string urlPicture;
        private FormatVideo formatvideo;

        public byte[] _version;

        public VideoMaterial(string urlVideo, string urlPicture, FormatVideo formatvideo, string description) : base(description)
        {
            this.urlVideo = urlVideo;
            this.urlPicture = urlPicture;
            this.formatvideo = formatvideo;
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

        public object Clone()
        {
            VideoMaterial clonedVideoMaterial = new VideoMaterial(this.urlVideo, this.urlPicture, this.formatvideo, Description);

            return clonedVideoMaterial;
        }

    }
}
