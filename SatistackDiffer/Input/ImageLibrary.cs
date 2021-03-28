using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SatistackDiffer.Input
{
    /// <summary>
    /// Stores item images from Satisfactory assets to be queried when building the output diff document
    /// </summary>
    public class ImageLibrary
    {
        private readonly IImageLibrarySource _source;
        private bool _isPopulated;
        private List<string> _imageList = new List<string>();

        public ImageLibrary(IImageLibrarySource source)
        {
            _source = source;
        }

        /// <summary>
        /// Populates the image library with the contents of the <see cref="IImageLibrarySource"/> provided when this object was instantiated
        /// </summary>
        public void PopulateLibrary()
        {
            _isPopulated = true;

            _imageList = _source.ImageFiles();
        }

        /// <summary>
        /// Returns the file path to an image which the filename of matches the given <see cref="substring"/>.
        ///
        /// Only the file name is matched against the provided <see cref="substring"/>, the path is ignored.
        /// </summary>
        public string PathForImageFileContainingSubstring(string substring, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            if(!_isPopulated)
                PopulateLibrary();

            return _imageList.FirstOrDefault(fileName => Path.GetFileName(fileName).Contains(substring, comparison));
        }
    }

    /// <summary>
    /// Provides file lists for <see cref="ImageLibrary"/>
    /// </summary>
    public interface IImageLibrarySource
    {
        List<string> ImageFiles();
    }
}
