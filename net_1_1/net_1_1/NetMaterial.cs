namespace net_1_1
{
    enum TypeLink
    {
        Unknown,
        Html,
        Image,
        Video
    }

    class NetMaterial : BaseMaterial
    {
        private string urlcontent;
        private TypeLink typelink;

        public NetMaterial(string urlcontent, TypeLink typelink, string description) : base(description)
        {
            this.urlcontent = urlcontent;
            this.typelink = typelink;
        }

        public object Clone()
        {
            NetMaterial clonedNetMaterial = new NetMaterial(this.urlcontent, this.typelink, Description);

            return clonedNetMaterial;
        }

    }   
}
