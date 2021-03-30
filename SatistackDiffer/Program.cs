using CommandLine;

namespace SatistackDiffer
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<MainInvocation>(args).WithParsed(options =>
            {
                options.Run();
            });
        }
    }
}
