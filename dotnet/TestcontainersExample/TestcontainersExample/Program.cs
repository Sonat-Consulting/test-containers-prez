using CommandLine;
using TestcontainersExample;
using TestcontainersExample.Persistence;
using TestcontainersExample.Persistence.Schema;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(WithOptions)
    .WithNotParsed(WithArgumentsError);
return;


static void WithOptions(Options opts)
{
    var dataSource = new DataSourceFactory(opts.ConnectionString).Create();
    {
        new Migrator(dataSource).Migrate();
    }
}

static void WithArgumentsError(IEnumerable<Error> errs)
{
    Console.WriteLine(errs);
    Environment.Exit(1);
}