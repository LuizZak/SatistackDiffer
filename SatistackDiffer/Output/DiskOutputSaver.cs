using System.Collections.Generic;
using System.IO;

namespace SatistackDiffer.Output
{
    /// <summary>
    /// Saves <see cref="AnalysisFileOutput"/> files into disk
    /// </summary>
    public static class DiskOutputSaver
    {
        public static void SaveFilesToDisk(IEnumerable<AnalysisFileOutput> files)
        {
            foreach (var file in files)
            {
                using var fileStream = File.Create(file.Path);
                fileStream.Write(file.Contents);
                fileStream.Flush();
            }
        }
    }
}
