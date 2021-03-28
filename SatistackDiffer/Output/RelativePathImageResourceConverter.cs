using System.IO;

namespace SatistackDiffer.Output
{
    /// <summary>
    /// Converts an image path from UE into a relative path rooted at the active directory.
    /// </summary>
    public class RelativeDirectoryImagePathConverter : IImagePathConverter
    {
        public string PathForImageResource(string imageResource)
        {
            // Images arrive in format
            // Texture2D'/Game/FactoryGame/Resource/X/Y/Z.Z
            string result = imageResource;

            // Strip leading Texture2D
            if (result.StartsWith("Texture2D'"))
                result = result.Remove(0, "Texture2D'".Length);

            // Split the string from the original separator into the OS' path separator
            string[] split = result.Split("/");
            result = Path.Join(split);

            // Format the file name with a .png extension
            result = Path.ChangeExtension(result, ".png");

            return result;
        }
    }
}
