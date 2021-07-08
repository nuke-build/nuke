using System.Linq;

namespace Nuke.Common.Tools.StrykerNet
{
    public partial class StrykerNetSettings {
        private string GetTestProjects() 
        {
            if (!TestProjectsInternal.Any())
                return null;
            return $"\"['{string.Join("', '", TestProjectsInternal)}']\"";
        }

        private string GetExcludedMutations() 
        {
            if (!ExcludedMutationsInternal.Any())
                return null;
            return $"\"['{string.Join("', '", ExcludedMutationsInternal)}']\"";
        }

        private string GetMutate() 
        {
            if (!MutateInternal.Any())
                return null;
            return $"\"['{string.Join("', '", MutateInternal)}']\"";
        }

        private string GetIgnoreMethods() 
        {
            if (!IgnoreMethodsInternal.Any())
                return null;
            return $"\"['{string.Join("', '", IgnoreMethodsInternal)}']\"";
        }

        private string GetReporters() 
        {
            if (!ReportersInternal.Any())
                return null;
            return $"\"['{string.Join("', '", ReportersInternal)}']\"";
        }
    }
}