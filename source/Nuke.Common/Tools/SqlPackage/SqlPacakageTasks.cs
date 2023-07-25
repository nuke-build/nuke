using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.SqlPackage;

public partial class SqlPackageTasks
{
    internal static string GetToolPath()
    {
         return NuGetToolPathResolver.GetPackageExecutable(packageId: "Microsoft.SqlPackage", packageExecutable: "sqlpackage.dll|sqlpackage.exe");
    }
}

