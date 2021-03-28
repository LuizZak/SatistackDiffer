namespace SatistackDiffer.Output
{
    /// <summary>
    /// Interface for classes that handle output of Docs analysis
    /// </summary>
    public interface IAnalysisResultOutput
    {
        /// <summary>
        /// Saves output to disk on a given path
        /// </summary>
        void Output(string path);
    }
}
