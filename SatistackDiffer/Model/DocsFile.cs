namespace SatistackDiffer.Model
{
    public struct DocsFile
    {
        public ItemDescriptor[] ItemDescriptors;

        public DocsFile(ItemDescriptor[] itemDescriptors)
        {
            ItemDescriptors = itemDescriptors;
        }

        public ItemDescriptor? ItemWithClassName(string displayName)
        {
            foreach (var item in ItemDescriptors)
            {
                if (item.DisplayName == displayName) 
                    return item;
            }

            return null;
        }
    }
}
