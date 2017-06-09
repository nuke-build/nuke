// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using LibGit2Sharp;
using Nuke.Core;
using Nuke.Core.Execution;

namespace Nuke.Git
{
    [PublicAPI]
    [IconClass("git")]
    public static class GitTasks
    {
        private static string s_repositoryDirectory;

        public static string RepositoryDirectory
        {
            get => s_repositoryDirectory ?? Build.Instance?.RootDirectory;
            set => s_repositoryDirectory = value;
        }

        public static PushOptions PushOptions { get; set; }

        public static void GitTag (string tagName)
        {
            UsingRepository(x => x.ApplyTag(tagName));
        }
        
        public static void GitCommit (string message, string name, string email)
        {
            UsingRepository(x => x.Commit(message, GetSignature(name, email), GetSignature(name, email)));
        }

        public static void GitAddAll ()
        {
            UsingRepository(x => Commands.Stage(x, "*"));
        }

        public static void GitPush ()
        {
            UsingRepository(x => x.Network.Push(x.Branches, PushOptions));
        }

        public static void GitPush (string branchName)
        {
            UsingRepository(x => x.Network.Push(x.Branches[branchName].AssertNotNull("branch != null"), PushOptions));
        }

        public static void GitPushRef (string remote, string refSpec)
        {
            UsingRepository(x => x.Network.Push(x.Network.Remotes[remote], x.Tags[refSpec].CanonicalName, PushOptions));
        }

        private static void UsingRepository (Action<Repository> action)
        {
            using (var repository = new Repository(RepositoryDirectory))
            {
                action(repository);
            }
        }

        private static Signature GetSignature (string name, string email)
        {
            return new Signature(name, email, DateTimeOffset.Now);
        }
    }
}
