using System;
using System.Collections.ObjectModel;

namespace GenericCollections
{
    class NonBlankStringList : Collection<string>
    {
        protected override void InsertItem(int index, string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException($"Elements of NonBlankStringList must not " +
                    $"be null of whitespaces");
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, string item)
        {
            if (string.IsNullOrWhiteSpace(item))
                throw new ArgumentException($"Elements of NonBlankStringList must not be " +
                    $"null of whitespaces");
            base.SetItem(index, item);
        }
    }
}
