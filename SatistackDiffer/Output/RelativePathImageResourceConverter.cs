using System;
using System.IO;
using System.Linq;

namespace SatistackDiffer.Output
{
    /// <summary>
    /// Converts an image path from UE into a relative path rooted at the active directory.
    /// </summary>
    public class RelativeDirectoryImagePathConverter : IImagePathConverter
    {
        public string PathForImageResource(string imageResource, PathSeparator pathSeparator)
        {
            // Images arrive in format
            // Texture2D'/Game/FactoryGame/Resource/X/Y/Z.Z
            string result = imageResource;

            // Strip leading Texture2D
            if (result.StartsWith("Texture2D'"))
                result = result.Remove(0, "Texture2D'".Length);

            // Split the string from the original separator into the selected path separator
            string[] split = result.Split("/");
            result = JoinPath(split, pathSeparator);

            // Format the file name with a .png extension
            result = Path.ChangeExtension(result, ".png");

            return result;
        }

        private static string JoinPath(string[] segments, PathSeparator separator)
        {
            return separator switch
            {
                PathSeparator.Windows => string.Join("\\", segments)[1..],
                PathSeparator.Unix => string.Join("/", segments)[1..],
                PathSeparator.CurrentOsDefault => Path.Join(segments),
                _ => throw new ArgumentOutOfRangeException(nameof(separator), separator, null)
            };
        }
    }
}
