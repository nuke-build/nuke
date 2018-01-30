# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)
and this project adheres to [Semantic Versioning](http://semver.org/spec/v2.0.0.html).

## [vNext]
- Added ChangelogTasks for finalizing unpublished changes to a certain version or extracting NuGet-compatible release notes for a specified tag.
- Added CLT tasks for Git.
- Added GitRepository.IsGitHubRepository extension method.
- Added switches (-major and -minor) for bumping versions when using GitVersionAttribute.
- Added NukeBuild.InvokedTargets (targets passed from command-line).
- Added NukeBuild.ExecutingTargets (targets that will be executed).
- Added GitRepository.Branch and GitRepository.Remote properties for pass-through.
- Deprecated -Target parameter in favor of passing targets as first argument to the bootstrapping scripts.
