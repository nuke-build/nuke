// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.NSwag.Generator
{
    public class NSwagSpecificationGenerator : SpecificationGenerator
    {
        public static void WriteSpecifications (NSwagSpecificationGeneratorSettings settings)
        {
            new NSwagSpecificationGenerator(settings).GenerateSpecifications();
        }

        public static void WriteSpecifications (Func<NSwagSpecificationGeneratorSettings, NSwagSpecificationGeneratorSettings> settings)
        {
            WriteSpecifications(settings(new NSwagSpecificationGeneratorSettings()));
        }

        private readonly NSwagSpecificationGeneratorSettings _settings;

        public NSwagSpecificationGenerator (NSwagSpecificationGeneratorSettings settings)
                : base(settings.OutputFolder)
        {
            _settings = settings;
        }

        protected override string ToolName => "NSwag";

        protected override string Help =>
                "The project combines the functionality of Swashbuckle (Swagger generation) and AutoRest (client generation) in one toolchain. This way a lot of incompatibilites can be avoided and features which are not well described by the Swagger specification or JSON Schema are better supported (e.g. <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Inheritance\">inheritance</a>, <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Enums\">enum</a> and reference handling). The NSwag project heavily uses <a href=\"http://njsonschema.org/\">NJsonSchema for .NET</a> for JSON Schema handling and C#/TypeScript class/interface generation.";

        protected override bool CustomExecutable => true;

        protected override string OfficialUrl => "https://github.com/RSuter/NSwag";

        protected override string[] License => new[]
                                               {
                                                       $"Copyright Sebastian Karasek, Matthias Koch {DateTime.Now.Year}.",
                                                       "Distributed under the MIT License.",
                                                       "https://github.com/nuke-build/nswag/blob/master/LICENSE"
                                               };

        protected override ISpecificationParser CreateSpecificationParser ()
        {
            return NSwagSpecificationParser.FromPackages(_settings.PackageFolder, _settings.GitReference);
        }
    }
}