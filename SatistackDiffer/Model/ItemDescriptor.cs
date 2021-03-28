using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SatistackDiffer.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public struct ItemDescriptor
    {
        [JsonProperty("ClassName")]
        public string ClassName { get; set; }

        [JsonProperty("mDisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("mStackSize")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StackSize StackSize { get; set; }

        [JsonProperty("mSmallIcon")]
        public string SmallIcon { get; set; }

        [JsonProperty("mPersistentBigIcon")]
        public string BigIcon { get; set; }

        public ItemDescriptor(string className, string displayName, StackSize stackSize, string smallIcon, string bigIcon)
        {
            ClassName = className;
            DisplayName = displayName;
            StackSize = stackSize;
            SmallIcon = smallIcon;
            BigIcon = bigIcon;
        }

        public override string ToString()
        {
            return $"{nameof(ClassName)}: {ClassName}, {nameof(DisplayName)}: {DisplayName}, {nameof(StackSize)}: {StackSize}, {nameof(SmallIcon)}: {SmallIcon}, {nameof(BigIcon)}: {BigIcon}";
        }
    }

    public enum StackSize
    {
        [EnumMember(Value = "SS_ONE")] One = 1,
        [EnumMember(Value = "SS_SMALL")] Small = 50,
        [EnumMember(Value = "SS_MEDIUM")] Medium = 100,
        [EnumMember(Value = "SS_BIG")] Big = 200,
        [EnumMember(Value = "SS_HUGE")] Huge = 500,
        [EnumMember(Value = "SS_FLUID")] Fluid = 0
    }
}
