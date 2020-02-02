// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.ProjectModel
{
    /// <summary>
    /// According to https://www.codeproject.com/Reference/720512/List-of-Visual-Studio-Project-Type-GUIDs.
    /// </summary>
    [PublicAPI]
    public class ProjectType
    {
        public static ProjectType SolutionFolder = new ProjectType(Nuke.Common.ProjectModel.SolutionFolder.Guid);

        public static ProjectType CSharpProject = new ProjectType("9A19103F-16F7-4668-BE54-9A1E7A4F7556", "FAE04EC0-301F-11D3-BF4B-00C04F79EFBC");
        public static ProjectType VBNetProject = new ProjectType("F184B08F-C81C-45F6-A57F-5ABD9991F28F");
        public static ProjectType FSharpProject = new ProjectType("F2A71F9B-5D33-465A-A702-920D77279786");
        public static ProjectType VisualCppProject = new ProjectType("8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942");

        public static ProjectType VSTAProject = new ProjectType("A860303F-1F3F-4691-B57E-529FC101A107");
        public static ProjectType VSTOProject = new ProjectType("BAA0C2D2-18E2-41B9-852F-F413020CAA33");
        public static ProjectType AspNetProject = new ProjectType("8BB2217D-0F2D-49D1-97BC-3654ED321F3B");

        public static ProjectType SharePointProject = new ProjectType("593B0543-81F6-4436-BA1E-4747859CAAE2",
            "EC05E597-79D4-47f3-ADA0-324C4F7C7484",
            "F8810EC1-6754-47FC-A15F-DFABD2E3FA90");
        
        public static ProjectType SqlProject = new ProjectType("00D1A9C2-B5F0-4AF3-8072-F6C62B433612");

        public static ProjectType DockerComposeProject = new ProjectType("E53339B2-1760-4266-BCC7-CA923CBCF16C");
        
        public static ProjectType WindowsPhoneProject = new ProjectType("76F1466A-8B6D-4E39-A767-685A06062A39",
            "C089C8C0-30E0-4E22-80C0-CE093F111A43",
            "DB03555F-0C8B-43BE-9FF9-57896B3C5E56");

        public static ProjectType WcfProject = new ProjectType("3D9AD99F-2412-4246-B90B-4EAA41C64699");
        public static ProjectType WpfProject = new ProjectType("60DC8134-EBA5-43B8-BCC9-BB4BC16C2548");

        public static ProjectType WwfProject = new ProjectType("14822709-B5A1-4724-98CA-57A101D1B079",
            "D59BE175-2ED0-4C54-BE3D-CDAA9F3214C8",
            "32F31D43-81CC-4C15-9DE6-3FC5453562B6");

        public static ProjectType WindowsStoreProject = new ProjectType("BC8A1FFA-BEE3-4634-8014-F334798102B3");
        public static ProjectType XamarinProject = new ProjectType("EFBA0AD7-5A72-4C68-AF49-83D382785DCF", "6BC8ED88-2882-458C-8E55-DFD12B67127B");

        public static ProjectType XnaProject = new ProjectType("6D335F3A-9D43-41b4-9D22-F6F17C4BE596",
            "2DF5C3F4-5A5F-47a9-8E94-23B4456F55E2",
            "D399B71A-8929-442a-A9AC-8BEC78BB2433");

        public ProjectType(params string[] guids)
            : this(guids.Select(Guid.Parse).ToArray())
        {
        }

        public ProjectType(params Guid[] guids)
        {
            Guids = guids;
        }

        public Guid FirstGuid => Guids.First();

        public IReadOnlyCollection<Guid> Guids { get; }
    }
}
