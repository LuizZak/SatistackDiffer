using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
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

        [Pure]
        public static Stream StreamFromString(string text, Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;

            return new MemoryStream(encoding.GetBytes(text));
        }
    }
}