using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SatistackDiffer.Input
{
    /// <summary>
    /// Image library source that fetches images from a file directory
    /// </summary>
    public class FileDiskImageLibrarySource : IImageLibrarySource
    {
        private readonly string _basePath;

        public FileDiskImageLibrarySource(string basePath)
        {
            _basePath = basePath;
        }

        public List<string> ImageFiles()
        {
            return Directory.EnumerateFiles(_basePath, "*.png", SearchOption.AllDirectories).ToList();
        }
    }
}