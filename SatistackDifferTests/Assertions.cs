using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatistackDiffer.Analysis;
using SatistackDiffer.Model;

namespace SatistackDifferTests
{
    public static class Assertions
    {
        public static void SequenceEqual<T>(this Assert _, IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer, [MaybeNull] Func<T, string> itemName = null)
        {
            var first = expected as T[] ?? expected.ToArray();
            var second = actual as T[] ?? actual.ToArray();

            Assert.IsTrue(first.SequenceEqual(second, comparer), $"Expected {FormatList(first, itemName)} found {FormatList(second, itemName)}");
        }

        public static void SequenceEqual(this Assert singleton, IEnumerable<ItemDescriptor> expected, IEnumerable<ItemDescriptor> actual)
        {
            SequenceEqual(singleton, expected, actual, new ItemDescriptorComparer());
        }

        public static void SequenceEqual(this Assert singleton, IEnumerable<AnalysisResult.ItemChange> expected, IEnumerable<AnalysisResult.ItemChange> actual)
        {
            SequenceEqual(singleton, expected, actual, new ItemChangeComparer());
        }

        public static void SequenceEqual<T>(this Assert _, IEnumerable<T> expected, IEnumerable<T> actual) where T : Enum
        {
            var first = expected as T[] ?? expected.ToArray();
            var second = actual as T[] ?? actual.ToArray();

            Assert.IsTrue(first.SequenceEqual(second), $"Expected {FormatList(first)} found {FormatList(second)}");
        }

        private static string FormatList<T>(IEnumerable<T> list, [MaybeNull] Func<T, string> itemName = null)
        {
            itemName ??= arg => arg.ToString();

            return $"[{string.Join(",", list.Select(itemName))}]";
        }

        public class ItemDescriptorComparer : IEqualityComparer<ItemDescriptor>
        {
            public bool Equals(ItemDescriptor x, ItemDescriptor y)
            {
                return x.DisplayName == y.DisplayName && x.StackSize == y.StackSize && x.SmallIcon == y.SmallIcon && x.BigIcon == y.BigIcon;
            }

            public int GetHashCode(ItemDescriptor obj)
            {
                return HashCode.Combine(obj.DisplayName, (int) obj.StackSize, obj.SmallIcon, obj.BigIcon);
            }
        }

        public class ItemChangeComparer : IEqualityComparer<AnalysisResult.ItemChange>
        {
            public bool Equals(AnalysisResult.ItemChange x, AnalysisResult.ItemChange y)
            {
                var comparer = new ItemDescriptorComparer();

                return comparer.Equals(x.Old, y.Old) && comparer.Equals(x.New, y.New);
            }

            public int GetHashCode(AnalysisResult.ItemChange obj)
            {
                var comparer = new ItemDescriptorComparer();

                return HashCode.Combine(comparer.GetHashCode(obj.Old), comparer.GetHashCode(obj.New));
            }
        }
    }
}
