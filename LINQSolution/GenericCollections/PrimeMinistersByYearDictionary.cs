using System.Collections.ObjectModel;

namespace GenericCollections
{
    class PrimeMinistersByYearDictionary : KeyedCollection<int, PrimeMinisters>
    {
        protected override int GetKeyForItem(PrimeMinisters item)
        {
            return item.YearElected;
        }
    }
}
