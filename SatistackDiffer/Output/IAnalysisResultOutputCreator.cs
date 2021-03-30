namespace SatistackDiffer.Output
{
    /// <summary>
    /// Interface for classes that handle output of Docs analysis
    /// </summary>
    public interface IAnalysisResultOutputCreator
    {
        AnalysisFileOutput[] CreateFileOutputs();
    }

    /// <summary>
    /// Represents a file that an analysis output created
    /// </summary>
    public class AnalysisFileOutput
    {
        /// <summary>
        /// File path to create/write to.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Contents of file.
        /// </summary>
        public byte[] Contents { get; }

        public AnalysisFileOutput(string path, byte[] contents)
        {
            Path = path;
            Contents = contents;
        }
    }
}
