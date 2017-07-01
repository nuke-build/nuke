// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using LibGit2Sharp;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Git;

[assembly: IconClass (typeof (GitTasks), "git")]

namespace Nuke.Git
{
    [PublicAPI]
    public static class GitTasks
    {
        private static string s_repositoryDirectory;

        [CanBeNull]
        public static string GitRepositoryDirectory
        {
            get => s_repositoryDirectory ?? Build.Instance?.RootDirectory;
            set => s_repositoryDirectory = value;
        }

        [CanBeNull]
        public static SecureUsernamePasswordCredentials GitCredentials { get; set; }

        private static CloneOptions CloneOptions => new CloneOptions { CredentialsProvider = (url, usernameFromUrl, types) => GitCredentials };
        private static PushOptions PushOptions => new PushOptions { CredentialsProvider = (url, usernameFromUrl, types) => GitCredentials };

        public static string GitClone(string sourceUrl, string workingDirectory, Configure<CloneOptions> configurator = null)
        {
            return Repository.Clone(sourceUrl, workingDirectory, configurator.InvokeSafe(CloneOptions));
        }

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
            GitAdd("*");
        }

        private static void GitAdd (string path)
        {
            UsingRepository(x => Commands.Stage(x, path));
        }

        public static void GitPush (Configure<PushOptions> configurator = null)
        {
            var pushOptions = configurator.InvokeSafe(PushOptions);
            UsingRepository(x => x.Network.Push(x.Branches, pushOptions));
        }

        public static void GitPush (string branchName, Configure<PushOptions> configurator = null)
        {
            var pushOptions = configurator.InvokeSafe(PushOptions);
            UsingRepository(x => x.Network.Push(x.Branches[branchName].NotNull("branch != null"), pushOptions));
        }

        public static void GitPushRef (string remote, string refSpec, Configure<PushOptions> configurator = null)
        {
            var pushOptions = configurator.InvokeSafe(PushOptions);
            UsingRepository(x => x.Network.Push(x.Network.Remotes[remote], x.Tags[refSpec].CanonicalName, pushOptions));
        }

        private static void UsingRepository (Action<Repository> action)
        {
            using (var repository = new Repository(GitRepositoryDirectory.NotNull("GitRepositoryDirectory != null")))
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
