using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using SatistackDiffer.Model;

namespace SatistackDiffer.Input
{
    public static class DocsParser
    {
        public static DocsFile Parse(JToken document)
        {
            var file = new DocsFile { ItemDescriptors = new ItemDescriptor[]{} };
            
            if (document.Type != JTokenType.Array)
                throw new ArgumentException($"Expected root JSON element to be an Array, received {document.Root.Type}");

            foreach (var element in document)
            {
                if (element["NativeClass"] != null)
                    ParseClassEntry(ref file, element);
            }

            return file;
        }

        private static void ParseClassEntry(ref DocsFile file, JToken classEntry)
        {
            string className = classEntry["NativeClass"].Value<string>();

            switch (className)
            {
                case "Class'/Script/FactoryGame.FGItemDescriptor'":
                    file.ItemDescriptors = ParseItemDescriptors(classEntry);
                    break;
            }
        }

        private static ItemDescriptor[] ParseItemDescriptors(JToken itemDescriptorRoot)
        {
            var classList = itemDescriptorRoot["Classes"];
            
            var result = classList.ToObject<ItemDescriptor[]>();

            if (result != null)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    result[i].SmallIcon = result[i].SmallIcon;
                    result[i].BigIcon = result[i].BigIcon;
                }
            }

            return result;
        }
    }
}
