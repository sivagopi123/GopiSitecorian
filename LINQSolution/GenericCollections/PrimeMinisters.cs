namespace GenericCollections
{
    class PrimeMinisters
    {
        public string Name { get; private set; }
        public int YearElected { get; private set; }

        public PrimeMinisters(string name, int yearElected)
        {
            this.Name = name;
            this.YearElected = yearElected;
        }
        public override string ToString()
        {
            return $"{Name}, elected:{YearElected}";
        }
    }
}
