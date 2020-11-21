// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.IO
{
    // TODO: document
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class FileGlobbingAttribute : FileSystemGlobbingAttributeBase
    {
        public FileGlobbingAttribute(params string[] patterns)
            : base(patterns, PathConstruction.GlobFiles)
        {
        }
    }

    // TODO: document
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DirectoryGlobbingAttribute : FileSystemGlobbingAttributeBase
    {
        public DirectoryGlobbingAttribute(params string[] patterns)
            : base(patterns, PathConstruction.GlobDirectories)
        {
        }
    }

    public abstract class FileSystemGlobbingAttributeBase : ParameterAttribute
    {
        private readonly string[] _patterns;
        private readonly Func<AbsolutePath, string[], IEnumerable<AbsolutePath>> _globber;

        protected FileSystemGlobbingAttributeBase(
            string[] patterns,
            Func<AbsolutePath, string[], IEnumerable<AbsolutePath>> globber)
        {
            _patterns = patterns;
            _globber = globber;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var memberType = member.GetMemberType();
            ControlFlow.Assert(memberType == typeof(AbsolutePath) || memberType == typeof(AbsolutePath[]),
                $"Member '{member.Name}' attributed with {GetType().Name} must be of type AbsolutePath or AbsolutePath[].");

            var globbedElements = GetGlobbedElements(member);

            var parameterValue = EnvironmentInfo.GetParameter<AbsolutePath[]>(member);
            if (parameterValue != null)
            {
                parameterValue.ForEach(x =>
                    ControlFlow.Assert(
                        globbedElements.Contains(x),
                        $"Value '{x}' for member '{member.Name}' is not contained any pattern '{_patterns.JoinComma()}'."));
                ControlFlow.Assert(parameterValue.Length == 1 || memberType == typeof(AbsolutePath[]),
                    $"Member '{member.Name}' can only accept a single value but got:"
                        .Concat(parameterValue.Select(x => x.ToString()))
                        .JoinNewLine());

                return memberType == typeof(AbsolutePath)
                    ? parameterValue.Single()
                    : (object) parameterValue;
            }

            return memberType == typeof(AbsolutePath[])
                ? (object) globbedElements
                : globbedElements.Length == 1
                    ? globbedElements.Single()
                    : null;
        }

        public override IEnumerable<(string, object)> GetValueSet(MemberInfo member, object instance)
        {
            return GetGlobbedElements(member).Select(x => (PathConstruction.GetRelativePath(NukeBuild.RootDirectory, x), (object) x));
        }

        private AbsolutePath[] GetGlobbedElements(MemberInfo member)
        {
            ControlFlow.Assert(_patterns.Length > 0, $"Member '{member.Name}' has no globbing patterns defined.");
            return _globber(NukeBuild.RootDirectory, _patterns).ToArray();
        }
    }
}
