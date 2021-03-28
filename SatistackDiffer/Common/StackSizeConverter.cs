using SatistackDiffer.Model;

namespace SatistackDiffer.Common
{
    public static class StackSizeConverter
    {
        public static string StackSizeString(StackSize stackSize)
        {
            if (stackSize == StackSize.Fluid)
                return "(fluid)";

            return ((int) stackSize).ToString();
        }
    }
}
