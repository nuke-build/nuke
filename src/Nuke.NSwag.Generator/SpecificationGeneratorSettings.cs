// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.NSwag.Generator
{
    public class SpecificationGeneratorSettings
    {
        public string PackageFolder { get; set; }
        public string OutputFolder { get; set; }
        public string Version { get; set; }
    }
}