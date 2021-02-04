// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;
using YamlDotNet.Core.Tokens;

namespace Nuke.Common
{
    [PublicAPI]
    public class AuditMemberValuesAttribute : BuildExtensionAttributeBase, IOnAfterLogo
    {
        public Type[] DeclaringTypes { get; set; }
        public string[] Members { get; set; }

        public Type[] ExcludeDeclaringTypes { get; set; }
        public string[] ExcludeMembers { get; set; }
        public bool ExcludeReadonly { get; set; }

        public override float Priority => -200;

        public void OnAfterLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets,
            IReadOnlyCollection<ExecutableTarget> executionPlan)
        {
            var allMembers = build.GetType()
                .GetMembers(ReflectionService.All)
                .Concat(build.GetType().GetInterfaces().SelectMany(x => x.GetMembers(ReflectionService.All)))
                .Where(x => x is FieldInfo || x is PropertyInfo)
                .Where(x => x.GetMemberType() != typeof(Target)).ToList();

            var filteredMembers = FilterMembers(allMembers)
                .Distinct(x => x.Name)
                .OrderBy(x => x.Name)
                .Select(x => (Member: x, Value: GetStringValue(x, build))).ToList();
            var indentation = filteredMembers.Max(x => x.Member.Name.Length) + 4;

            var membersByDeclaringType = filteredMembers
                .ToLookup(x => x.Member.DeclaringType, x => x)
                .OrderBy(x => x.Key.NotNull().Name);

            foreach (var typeWithMembers in membersByDeclaringType)
            {
                WriteSection(typeWithMembers.Key, indentation);

                foreach (var (member, value) in typeWithMembers)
                {
                    if (value is IEnumerable<string> values)
                        values.ForEach((x, i) => WriteValue(member, x, indentation, i));
                    else
                        WriteValue(member, (string) value, indentation);
                }
            }
        }

        protected virtual IEnumerable<MemberInfo> FilterMembers(IEnumerable<MemberInfo> members)
        {
            return members
                .Where(x => DeclaringTypes == null || DeclaringTypes.Contains(x.DeclaringType))
                .Where(x => Members == null || Members.Contains(x.Name))
                .Where(x => ExcludeDeclaringTypes == null || !ExcludeDeclaringTypes.Contains(x.DeclaringType))
                .Where(x => ExcludeMembers == null || !ExcludeMembers.Contains(x.Name))
                .Where(x => x is FieldInfo || x is PropertyInfo propertyInfo && (!ExcludeReadonly || propertyInfo.SetMethod != null));
        }

        protected virtual object GetStringValue(MemberInfo member, NukeBuild build)
        {
            string FormatValue(object value)
                => value != null
                    ? NukeBuild.RootDirectory.Contains(value.ToString()) && member.Name != nameof(NukeBuild.RootDirectory)
                        ? NukeBuild.RootDirectory.GetRelativePathTo((AbsolutePath) value.ToString())
                        : value.ToString()
                    : "<null>";

            try
            {
                var value = member.GetValue(build);
                return value is not string && value is IEnumerable enumerable
                    ? (object) enumerable.Cast<object>().Select(FormatValue).ToList()
                    : FormatValue(value);
            }
            catch
            {
                return "<Exception>";
            }
        }

        protected virtual void WriteSection(Type type, int indentation)
        {
            var groupName = type.NotNull().Name;
            Logger.Info();
            Logger.Info($"{new string(c: '─', indentation - groupName.Length / 2)} {groupName} "
                .PadRight(totalWidth: indentation * 2 + 20, paddingChar: '─'));
            Logger.Info();
        }

        protected virtual void WriteValue(MemberInfo member, string value, int indentation, int? number = null)
        {
            var caption = $"{member.Name}{(number != null ? $"[{number}]" : string.Empty)}";
            Logger.Info($"{caption.PadRight(indentation)} = {value}");
        }
    }
}
