using System.Diagnostics.Contracts;
using Newtonsoft.Json.Linq;

namespace SatistackDifferTests
{
    internal static class TestUtils
    {
        [Pure]
        public static JToken JsonFromString(string json)
        {
            return JToken.Parse(json);
        }
    }
}