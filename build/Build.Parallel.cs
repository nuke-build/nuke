using Nuke.Common;
using System.Threading;
using System.Threading.Tasks;

partial class Build
{
    Target CompileIt => _ => _
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });

    Target PublishApi => _ => _
        .DependsOn(CompileIt)
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });

    Target PublishDocker => _ => _
        .DependsOn(PublishApi)
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });

    Target PublishApp => _ => _
        .DependsOn(CompileIt)
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });

    Target PublishIt => _ => _
        .DependsOn(PublishApi, PublishDocker)
        .DependsOn(PublishApp)
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });



    Target PackApp => _ => _
        .DependsOn(PublishApp)
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });

    Target PackApi => _ => _
        .DependsOn(PublishApi)
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });

    Target PackIt => _ => _
        .DependsOn(PackApp, PackApi)
        .Executes(() =>
        {
            Thread.Sleep(1000);
        });
}
