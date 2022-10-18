namespace net_1_1
{
    class BaseMaterial : Entity, ICloneable

    {
        public BaseMaterial(string description) : base(description)
        {
        }

        public object Clone()
        {
            BaseMaterial clonedBaseMaterial = new BaseMaterial(Description);

            return clonedBaseMaterial;
        }

        public override bool Equals(object obj)
        {
            if (obj is BaseMaterial temp)
            {
   
                if (Id == temp.Id)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return Description;
        }

    }
}
