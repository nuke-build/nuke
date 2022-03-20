// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public class AzurePipelinesParameter : ConfigurationEntity
    {
        public AzurePipelinesParameterType Type { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Default { get; set; }

        public string[] Values { get; set; }

        // Template expansion form is ${{ VARNAME }}
        public string TemplateVar => $"${{{{{Name}}}}}";
        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"- name: {Name}"))
            {
                if (!string.IsNullOrWhiteSpace(DisplayName))
                    writer.WriteLine($"displayName: {DisplayName}");

                switch (Type)
                {
                    case AzurePipelinesParameterType.String:
                        writer.WriteLine("type: string");
                        break;
                    case AzurePipelinesParameterType.Number:
                        writer.WriteLine("type: number");
                        break;
                    case AzurePipelinesParameterType.Boolean:
                        writer.WriteLine("type: boolean");
                        break;
                    default:
                        writer.WriteLine("type: string");
                        break;
                }

                if (!string.IsNullOrWhiteSpace(Default))
                {
                    if(Type == AzurePipelinesParameterType.Boolean)
                        writer.WriteLine($"default: {Default.ToLower()}");
                    else
                        writer.WriteLine($"default: {Default}");
                }

                if (Values != null && Values.Length > 0)
                {
                    using (writer.WriteBlock("values:"))
                    {
                        Values.ForEach(x => writer.WriteLine($"- {x}"));
                    }
                }
            }
        }
    }
}
