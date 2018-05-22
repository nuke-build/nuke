// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.NSwag.Generator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SpecificationParser.WriteSpecifications(new SpecificationGeneratorSettings
                                                    {
                                                        OutputFolder = args[0],
                                                        PackageFolder = args[1]
                                                    });
        }
    }
}