using System.Collections.Generic;

namespace GenericCollections
{
    class UncasedStringEqualityComparer : IEqualityComparer<string>
    {

        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }
        public int GetHashCode(string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
}
