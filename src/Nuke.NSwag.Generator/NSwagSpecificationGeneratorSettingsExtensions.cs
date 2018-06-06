// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.NSwag.Generator
{
    public static class NSwagSpecificationGeneratorSettingsExtensions
    {
        public static NSwagSpecificationGeneratorSettings SetPackageFolder (this NSwagSpecificationGeneratorSettings settings, string packageFolder)
        {
            settings.PackageFolder = packageFolder;
            return settings;
        }

        public static NSwagSpecificationGeneratorSettings SetGitReference (this NSwagSpecificationGeneratorSettings settings, string gitReference)
        {
            settings.GitReference = gitReference;
            return settings;
        }
    }
}