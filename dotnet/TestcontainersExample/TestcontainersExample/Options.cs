using CommandLine;

namespace TestcontainersExample;

public class Options
{
    [Option('c', "connectionString", Required = true, HelpText = "Provide a connection string.")]
    public string ConnectionString { get; set; }
}