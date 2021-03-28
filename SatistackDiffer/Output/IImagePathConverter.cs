namespace SatistackDiffer.Output
{
    /// <summary>
    /// Class used to convert image resource paths from UE resource format into a file disk path
    /// </summary>
    public interface IImagePathConverter
    {
        string PathForImageResource(string imageResource, PathSeparator separator);
    }

    public enum PathSeparator
    {
        Windows,
        Unix,
        CurrentOsDefault
    }
}