import React from "react";
import Translate, {translate} from "@docusaurus/core/lib/client/exports/Translate";

export const KEYWORDS = [
    "c# make",
    "csharp make",
    "dotnet make",
    "dotnet build automation",
    "csharp build automation",
    "dotnet devops tools",
    "csharp devops tools",
    "dotnet ci/cd",
    "nuke build",
    "msbuild alternative",
    "dotnet cake alternative",
    "dotnet fake alternative",
    "continuous integration",
    "continuous delivery",
    "continuous deployment",
    "dotnet teamcity",
    "dotnet github actions",
    "dotnet gitlab",
    "dotnet azure pipelines",
    "yaml alternative",
];

export const SMALL_FEATURES = [
    {
        title: 'Easy to Troubleshoot',
        Svg: require('/img/undraw/fixing-bugs.svg').default,
        description: (
            <>
                Investigate issues on your local machine with all debugger features.
                Run build steps in isolation without changing dependencies.
            </>
        ),
    },
    {
        title: 'Granular Versioning',
        Svg: require('/img/undraw/version-control.svg').default,
        description: (
            <>
                Version your build project alongside your solution and use
                dedicated branches to implement and test new builds steps.
            </>
        ),
    },
    {
        title: 'Reusable Components',
        Svg: require('/img/undraw/software-engineer.svg').default,
        description: (
            <>
                Streamline your production by extracting common build steps
                and reusing them across all your projects.
            </>
        ),
    },
];

export const QUOTES = [
    {
        thumbnail: require('/img/testimonials/matt-richardson.webp').default,
        name: 'Matt Richardson',
        title: translate({
            id: 'homepage.quotes.matt-richardson.title',
            message: 'Lead Engineer at Octopus Deploy',
            description: 'Title of quote of Matt Richardson on the home page',
        }),
        text: (
            <Translate
                id="homepage.quotes.matt-richardson"
                description="Quote of Matt Richardson on the home page">
                NUKE has been a game changer in our build pipelines. Previously, the use of DSL-based build scripts
                meant that few people were comfortable making changes. Now, with our builds expressed in C#, change is
                no longer scary. We now get full IDE support (rather than errors from coding in a custom language), we
                get refactoring support, unit tests, and more.
            </Translate>
        ),
    },
    {
        thumbnail: require('/img/testimonials/dennis-doomen.webp').default,
        name: 'Dennis Doomen',
        title: translate({
            id: 'homepage.quotes.dennis-doomen.title',
            message: 'Principal Consultant at Aviva Solutions B.V.',
            description: 'Title of quote of Dennis Doomen on the home page',
        }),
        text: (
            <Translate
                id="homepage.quotes.dennis-doomen"
                description="Quote of Dennis Doomen on the home page">
                Having worked with many different build tools, there was
                always something missing that ruined my productivity. Either the lack of proper IntelliSense, the
                (in)ability to refactor and debug my build scripts, or the need to build all kinds of custom plumbing.
                Nothing can match the experience of treating your build scripts as first-class
                citizens of your code-base. Everything works as you would expect from a current-generation
                build framework. So don't accept anything less.
            </Translate>
        ),
    },
    {
        thumbnail: '/img/testimonials/ron-myers.jpg',
        name: 'Ron Myers',
        title: translate({
            id: 'homepage.quotes.ron-myers.title',
            message: 'Co-Founder at Thinking Big',
            description: 'Title of quote of Ron Myers on the home page',
        }),
        text: (
            <Translate
                id="homepage.quotes.ron-myers"
                description="Quote of Ron Myers on the home page">
                What NUKE has saved me in pipeline integration could be measured in sprints. Annotate your build class
                with one attribute and your project is ready to add to the target CI/CD server - it feels magic! NUKE is
                the perfect tool for small and large teams alike - pure C# build scripts - easy to code review and grok.
            </Translate>
        ),
    },
    // {
    //     thumbnail: '/img/testimonials/chris-gardenberg.jpg',
    //     name: 'Chris Gårdenberg',
    //     title: translate({
    //         id: 'homepage.quotes.chris-gardenberg.title',
    //         message: 'Infrastructure Engineer at MultiNet Interactive AB',
    //         description: 'Title of quote of Chris Gårdenberg on the home page',
    //     }),
    //     text: (
    //         <Translate
    //             id="homepage.quotes.chris-gardenberg"
    //             description="Quote of Chris Gårdenberg on the home page">
    //             Our builds have become easier to manage since we started using NUKE.
    //             We now have structured code that allows us to test builds locally, instead of trying to debug PowerShell
    //             scripts that fails randomly on the build servers.
    //             Finally a build automation solution, that you can extend and customize easily!
    //         </Translate>
    //     ),
    // },
    // {
    //     thumbnail: require('/img/testimonials/michael-staib.webp').default,
    //     name: 'Michael Staib',
    //     title: translate({
    //         id: 'homepage.quotes.michael-staib.title',
    //         message: 'Software Architect at SwissLife',
    //         description: 'Title of quote of Michael Staib on the home page',
    //     }),
    //     text: (
    //         <Translate
    //             id="homepage.quotes.michael-staib"
    //             description="Quote of Michael Staib on the home page">
    //         </Translate>
    //     ),
    // },
];

export const GET_STARTED = `
dotnet tool install Nuke.GlobalTool --global
nuke :setup
nuke`.trim()

export const BUILD_EXAMPLE = `
class Build : NukeBuild
{
    public static int Main() => Execute<Build>();

    Target Restore => _ => _
        .Executes(() =>
        {
            // Restore implementation
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            // Compile implementation
        });
}
`.trim()

export const YAML_EXAMPLE = `
[GitHubActions(
    "deployment",
    GitHubActionsImage.UbuntuLatest,
    OnPushBranches = new[] { MainBranch },
    InvokedTargets = new[] { nameof(Publish) },
    ImportSecrets = new[] { nameof(NuGetApiKey) })]
class Build : NukeBuild
{
    Target Pack => _ => _
        .Produces(RootDirectory / "output" / "*.nupkg") 
        .Executes(() => { /* Pack implementation */ });

    [Parameter] [Secret] readonly string NuGetApiKey;

    Target Publish => _ => _
        .Requires(() => NuGetApiKey)
        .DependsOn(Pack)
        .Executes(() => { /* Publish implementation */ });
}
`.trim()
