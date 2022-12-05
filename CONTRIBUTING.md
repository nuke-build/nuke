# Contribution Guidelines

As a community, we want to help each other, provide constructive feedback, and make a better product. Of course, our [code of conduct](CODE_OF_CONDUCT.md) must be followed at any time.

## Consumer Expectations

NUKE is a personal project that was made open-source to let the whole community benefit from it **free of charge** but also ["as is"](https://github.com/nuke-build/nuke/blob/develop/LICENSE). Like a lot of open-source projects, it is primarily maintained and developed by a [single person](https://github.com/matkoch). Some of the **most time-consuming tasks** around the project are:

- Development of the NuGet package itself (C#, .NET, MSBuild)
- Collecting CLI metadata (.NET ClI, MSBuild, Docker, +30 others)
- Integration with CI/CD services (Azure Pipelines, GitHub Actions, TeamCity, ...)
- IDE extensions (VSSDK, ReSharper SDK, IntelliJ SDK, Kotlin, JVM, Gradle)
- Website (JavaScript, TypeScript, React, Docusaurus)
- Hosting (Azure, Cloudflare, Algolia, Fathom)
- Documentation, presentation slides, and blog posts
- Helping in GitHub issues/discussions, Slack, and Discord
- Talking at conferences and meetups including travel
- Promotion on Twitter and Mastodon

This list should give you an impression of what it took to make NUKE what it is today and what it continuously takes to move it forward. Obviously though, there's only a limited amount of time a single person can dedicate besides their personal life and real job [without burning out](https://www.jeffgeerling.com/blog/2022/burden-open-source-maintainer).

Therefore, **everything that benefits a larger audience is prioritized** over digging into issues that only affect a single or few individuals. Please don't take offense when your issue or pull-request is not getting the attention you were hoping for. It is simply a time management decision.

## Baseline Contributions

There are a number of minimal to zero efforts you can make to show your support for the project:

- Give the [GitHub project](https://github.com/nuke-build/nuke/stargazers) a star (and tell your team)
- Follow [@nukebuildnet](https://twitter.com/nukebuildnet) and [@nuke@dotnet.social](https://dotnet.social/@nuke)
- Upvote, share, and comment our content (see [#mentions](https://app.slack.com/client/T9QUKHC4A/CDJD8CGQ5) on Slack)
- Talk about NUKE on social media and let others know where it can help (tag us!)
- Give ratings where possible (e.g., extensions for [Rider](https://plugins.jetbrains.com/plugin/10803-nuke-support/reviews) or [Visual Studio](https://marketplace.visualstudio.com/items?itemName=nuke.visualstudio&ssr=false#review-details)) 

The above points are considered somewhat of the norm in exchange for using the project free of charge.

## Sustainability Contributions

There are plenty of ways to show your commitment to the project and strengthen its longevity. These are typically tied to contributing time or money, but also allow for prioritizing your individual issues in return:

- [Convince your company to sponsor](https://humanwhocodes.com/blog/2021/05/talk-to-your-company-sponsoring-open-source/)
- Sponsor personally (e.g., when the project improves your work performance reviews)
- Fix or investigate issues that are marked as [`good first issue`](https://github.com/nuke-build/nuke/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22)
- Take ownership for a tool wrapper or CI/CD service (.NET CLI, GitHub Actions, ...)
- Write a blog post or give a meetup talk (let us know!)
- Help others in GitHub issues/discussions or on Slack and Discord

**If you need help with any of the above suggestions, don't hesitate to ask!**

## Issues

### Before creating an issue

Evaluate whether your topic is going to be a valid issue:

- Have you read and searched the [documentation](https://nuke.build/docs/introduction/)?
- Have you checked the [FAQ](https://nuke.build/faq/)?
- Is your issue more of a question? Ask on [GitHub discussions](https://github.com/nuke-build/nuke/discussions), [Slack](https://nuke.build/slack), or [Discord](https://nuke.build/discord)!
- Have you checked existing/closed issues? Maybe your version is behind?
- Did you verify it's not an external tool issue? Invoke the command manually!
- Don't file issues for tool wrappers. Send a pull-request instead!
- Refrain from debating the governance or state of the project out of your own interests (see [consumer expectations](#consumer-expectations) & [sustainability contributions](#sustainability-contributions))

### When creating an issue

Choose one of the [issue templates](https://github.com/nuke-build/nuke/issues/new/choose) and fill it out as good as possible. This includes, but is not limited to:

- State the issue as short as possible (more likely there's time to comprehend it)
- Use [markdown](https://docs.github.com/en/get-started/writing-on-github) for code, logs, and other special text fragments
- Don't paste images when they're showing log output or exception messages
- [Refrain from making demands or expressing disappointment](https://mikemcquaid.com/2018/03/19/open-source-maintainers-owe-you-nothing) (see [consumer expectations](#consumer-expectations) & [sustainability contributions](#sustainability-contributions))

**When an issue is of poor quality, or it is evident that the guidelines haven't been read, it will be closed without any further response.**

### After creating an issue

Once the `triage` label is removed from your issue, you will know how it is seen from the project's perspective:

- Issues labelled as `area:cicd` or `area:tools` usually can be fixed in user code
  - [Custom arguments](https://nuke.build/docs/common/cli-tools/#custom-arguments) can be wrapped in local extension methods
  - Additional steps in CI/CD configuration generation can be added through inheritance
- If your issue is labelled as `good first issue`, consider sending a pull-request

Depending on the priority, available time, and your personal commitment to the project, the issue will be addressed sooner or later. In (hopefully) rare cases, it might also be closed due to missing resources.

## Pull-Requests

### Before creating a pull-request

In your own interest of getting a pull-request merged (timely):

- Discuss non-trivial changes in an [issue](https://github.com/nuke-build/nuke/issues/new/choose)
- Make sure your employer allows contributions
- Branch your work off from the `develop` branch
- Get familiar with the coding conventions

### When working on a pull-request

- Aim for qualitative and readable code
- Follow the coding style of the existing codebase
- Make sure the project builds and all tests pass
- Don't copy/paste chunks of code, even when it's meant as a draft
- Drafting APIs is okay, as long as you're ready to finish it later
- Add tests when meaningful, particularly when there is a related test class already

### When creating a pull-request

- [Link the issue it relates to](https://docs.github.com/en/issues/tracking-your-work-with-issues/linking-a-pull-request-to-an-issue) (unless it's trivial)
- Check all the applicable boxes

For tool wrappers (e.g. [.NET CLI](https://github.com/nuke-build/nuke/blob/develop/source/Nuke.Common/Tools/DotNet/DotNet.json)), also note the following remarks:

- Copy/paste as much as possible
- Cover at least a full command with all its arguments
- Use tags for formatting in `help`
  - `<c>` for inline code
  - `<a>` for links
  - `<ul>`/`<ol>` for lists
  - `<em>` for emphasized text
  - `<para/>` in between paragraphs (as opposed to `<p>...</p>`)
- Don't explicitly define `secret: false` (it's the default)
- Don't provide `default: xxx` (it's obsolete)
- Don't generate the code; it will be done manually once per release

### After creating a pull-request

- Don't bother to rebase your pull-request if commits have been force-pushed
- [Don't "push" your pull-request](https://www.igvita.com/2011/12/19/dont-push-your-pull-requests/) (see [sustainability contributions](#sustainability-contributions))
