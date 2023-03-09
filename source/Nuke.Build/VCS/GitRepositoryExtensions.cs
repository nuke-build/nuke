// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.Git
{
    [PublicAPI]
    public static class GitRepositoryExtensions
    {
        public static bool IsOnMainOrMasterBranch(this GitRepository repository)
        {
            return repository.IsOnMainBranch() ||
                   repository.IsOnMasterBranch();
        }

        public static bool IsOnMasterBranch(this GitRepository repository)
        {
            return repository.Branch?.EqualsOrdinalIgnoreCase("master") ?? false;
        }

        public static bool IsOnMainBranch(this GitRepository repository)
        {
            return repository.Branch?.EqualsOrdinalIgnoreCase("main") ?? false;
        }

        public static bool IsOnDevelopBranch(this GitRepository repository)
        {
            return (repository.Branch?.EqualsOrdinalIgnoreCase("dev") ?? false) ||
                   (repository.Branch?.EqualsOrdinalIgnoreCase("develop") ?? false) ||
                   (repository.Branch?.EqualsOrdinalIgnoreCase("development") ?? false);
        }

        public static bool IsOnFeatureBranch(this GitRepository repository)
        {
            return (repository.Branch?.StartsWithOrdinalIgnoreCase("feature/") ?? false) ||
                   (repository.Branch?.StartsWithOrdinalIgnoreCase("features/") ?? false);
        }

        // public static bool IsOnBugfixBranch(this GitRepository repository)
        // {
        //     return repository.Branch?.StartsWithOrdinalIgnoreCase("feature/fix-") ?? false;
        // }

        public static bool IsOnReleaseBranch(this GitRepository repository)
        {
            return (repository.Branch?.StartsWithOrdinalIgnoreCase("release/") ?? false) ||
                   (repository.Branch?.StartsWithOrdinalIgnoreCase("releases/") ?? false);
        }

        public static bool IsOnHotfixBranch(this GitRepository repository)
        {
            return (repository.Branch?.StartsWithOrdinalIgnoreCase("hotfix/") ?? false) ||
                   (repository.Branch?.StartsWithOrdinalIgnoreCase("hotfixes/") ?? false);
        }
    }
}
