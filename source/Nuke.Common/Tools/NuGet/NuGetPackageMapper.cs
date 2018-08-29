// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JetBrains.Annotations;
using NuGet.Packaging;

namespace Nuke.Common.Tools.NuGet
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class NuGetPackageMapper
    {
        private static readonly IMapper s_mapper;

        static NuGetPackageMapper()
        {
            s_mapper = new MapperConfiguration(
                c =>
                {
                    c.CreateMissingTypeMaps = true;

                    c.CreateMap<Manifest, NuGetPackage>()
                        .AfterMap((s, d) => s_mapper.Map(s.Metadata, d))
                        .AfterMap((s, d) => s_mapper.Map(s.Files, d.ContentFilesInternal));
                    c.CreateMap<ManifestMetadata, NuGetPackage>()
                        .ForMember(s => s.AuthorsInternal, o => o.MapFrom(x => x.Authors))
                        .ForMember(s => s.OwnersInternal, o => o.MapFrom(x => x.Owners))
                        .ForMember(s => s.TagsInternal, o => o.ResolveUsing(x => FromSpaceSeparated(x.Tags)))
                        .ForMember(s => s.DefaultDependenciesInternal, o => o.ResolveUsing(GetDefaultDependencies))
                        .ForMember(s => s.DependencySetsInternal, o => o.ResolveUsing(GetOtherDependencySets));

                    c.CreateMap<NuGetPackage, Manifest>()
                        .AfterMap((s, d) => s_mapper.Map(s, d.Metadata))
                        .AfterMap((s, d) => s_mapper.Map(s.ContentFilesInternal, d.Files))
                        .AfterMap((s, d) => s_mapper.Map(GetAllDependencySets(s), d.Metadata.DependencyGroups));
                    c.CreateMap<NuGetPackage, ManifestMetadata>()
                        .ForMember(s => s.Authors, o => o.ResolveUsing(x => x.AuthorsInternal))
                        .ForMember(s => s.Owners, o => o.ResolveUsing(x => x.OwnersInternal))
                        .ForMember(s => s.Tags, o => o.ResolveUsing(x => ToSpaceSeparated(x.Tags)))
                        .ForMember(s => s.ContentFiles, o => o.Ignore())
                        .ForMember(s => s.DependencyGroups, o => o.Ignore());
                }).CreateMapper();
        }

        public static NuGetPackage Map(Manifest manifest)
        {
            return s_mapper.Map<NuGetPackage>(manifest);
        }

        public static Manifest Map(NuGetPackage nuGetPackage)
        {
            return s_mapper.Map<Manifest>(nuGetPackage);
        }

        // TODO: naming in NuGetPackage? DefaultDependencies / DefaultDependencySet ?
        private static List<PackageDependency> GetDefaultDependencies(ManifestMetadata manifestMetadata)
        {
            var dependencies = manifestMetadata.DependencyGroups.SingleOrDefault(x => x.TargetFramework.IsAgnostic)?.Packages
                               ?? new List<global::NuGet.Packaging.Core.PackageDependency>();
            return s_mapper.Map<List<PackageDependency>>(dependencies);
        }

        private static List<PackageDependencySet> GetOtherDependencySets(ManifestMetadata manifestMetadata)
        {
            var dependencySets = manifestMetadata.DependencyGroups.Where(x => !x.TargetFramework.IsAgnostic);
            return s_mapper.Map<List<PackageDependencySet>>(dependencySets);
        }

        private static List<PackageDependencySet> GetAllDependencySets(NuGetPackage nuGetPackage)
        {
            return new[] { new PackageDependencySet { DependenciesInternal = nuGetPackage.DefaultDependencies.ToList() } }
                .Concat(nuGetPackage.DependencySets)
                .ToList();
        }

        private static string ToSpaceSeparated(IEnumerable<string> values)
        {
            return string.Join(" ", values);
        }

        private static List<string> FromSpaceSeparated(string value)
        {
            return value.Split(' ').Select(y => y.Trim()).ToList();
        }
    }
}
