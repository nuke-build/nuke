<img width="400px" src="https://github.com/nuke-build/nuke/raw/develop/images/logo-black.png" />

> The AKEless Build System for C#/.NET

[![Latest Release](https://img.shields.io/nuget/v/nuke.common?logo=nuget&label=release&style=for-the-badge)](https://www.nuget.org/packages/nuke.common)
[![Latest Pre-Release](https://img.shields.io/nuget/vpre/nuke.common?logo=nuget&color=yellow&label=pre-release&style=for-the-badge)](https://www.nuget.org/packages/nuke.common/absoluteLatest)
[![Downloads](https://img.shields.io/nuget/dt/nuke.common.svg?style=for-the-badge&logo=data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAHYcAAB2HAY%2Fl8WUAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTnU1rJkAAABrUlEQVR4XuXQQW7DMAxE0Rw1R%2BtN3XAjBOpPaptfsgkN8DazIDB8bNu2NCxXguVKsFwJlrJs6KYGS1k2dFODpSwbuqnBUpYN3dRgKcuGbmqwlGVDNzVYyrKhmxosZdnQTQ2WsmzopgZLWTZ0U4OlLBu6qcFSlg3d1GApy4ZuarCUZUM3NVjKsqGbGixl2dBNDZaybOimBktZNnRTg6UsG7qpwVKWDd3UYPnB86VKfl5owx9YflHhCbvHByz%2FcecnHBofsNzhjk84PD5gudOdnnBqfMDygDs84fT4gOVBVz4hNT5gecIVT0iPD1ieNPMJyviAZcKMJ2jjA5ZJI5%2Bgjg9YCkY8QR8fsJSYTxgyPmApMp4wbHzAUpZ5wtDxAcsBzjxh%2BPiA5SBHnjBlfMByoD1PmDY%2BYDnYtydMHR%2BwnICeMH18wHKS9ydcMj5gOVE84bLxAcuVYLkSLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLDvVQ5saLFeC5UqwXAmW69gev7WIMc4gs9idAAAAAElFTkSuQmCC)](https://www.nuget.org/packages/Nuke.Common/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg?style=for-the-badge&logo=data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAHYcAAB2HAY%2Fl8WUAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTCtCgrAAAADB0lEQVR4XtWagXETMRREUwIlUAIlUAodQAl0AJ1AB9BB6AA6gA6MduKbkX%2BevKecNk525jHO3l%2Fp686xlJC70%2Bl0C942vjV%2Bn9FreVQbBc0wWujfRpW8Z78JaIb53hhJ1ygTA80w9PQ36duBMjHQHPCuoQZfutSjeqU1PAJN4E3j2pN7aVKv6pnWcgGawNfGa5N6prVcgGZBn8yvVXZXQbOgPXokXaPMNZwoc41D%2FaHZ8b7hpBrKjnCizIjD%2FaHZ8aPR6%2BeZXqqh7Agnyow43B%2BaZz40qnQ36a6rlsYgnChDLOkPzTN1z%2B9PafU0N3OAcaIMsaQ%2FNBufG1X9JyrtDMr0Y4xwokxlWX%2BPjAYdemhPrWeDvYcPJ8r0LO3v4oszNfivQQuTp2u9qJGKE2V6lvZ38UVj9q3t3oqEE2U2lvfXF4t6qPjTqDUV1fRyhw8nymws768vfOr2NtqOqFY4UUZE%2BusL6VDRX7%2FGzOHDiTIi0t9WMPsUKzNPx4kysf62gmuHir3sPXw4USbWny485ZOc2PsJ7VTro%2F3pwp5DxV7qHq2xa41TrY%2F2J7PfJkaHir3UwwdtU061PtqfTP0CUaYm2v3LxCtoDI2lMWk8p1of7Y8K0jhRJgaaYZwoE0P%2FpFUndZqtP6T4BE2zC5qtP6T4BE2zC5qtPyRN8OvhZUQae3ZBtT7anyb49PA6Ivp5wKnWR%2FvbJkncZXr6wokysf62CXRCWjmJxhqd2JwoE%2BuvTqS37JGJlB39GLzhRJmN5f31gz8XTpSJgWYYJ8rEQDOME2VioBnGiTIx0AzjRJkYaIZxokwMNMM4USYGmmGcKBMDzTBOlImBZhgnysRAM4wTZWKgGcaJMjHQDONEmRhohnGiTAw0wzhRJgaaYZwoEwPNME6UiYFmGCfKxEAzjBNlYqAZxokyMdAMoL%2FO%2BNi4bzjpT1e%2BNFb8V7gFzUXMLHqk%2BM1A8wArFj1S5GagOUly0SMtuxloTnJrUU%2B7QXOSW4t62g2ak9xa1NNu0Jzk1qKednK6%2Bw9roIB8keT%2F3QAAAABJRU5ErkJggg%3D%3D)](LICENSE.md)

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Example](#example)
- [Contributing](#contributing)
- [Backers & Sponsors](#backers--sponsors)
- [Users](#users)
- [Acknowledgements](#acknowledgements)

## Description

[<img align="right" width="130px" src="https://github.com/nuke-build/nuke/raw/develop/images/icon.png" />](https://nuke.build/)

**NUKE** is an open-source build automation system for C#/.NET that runs cross-platform on .NET Core, .NET Framework, and Mono. While builds are bootstrapped with conventional Bash or PowerShell scripts, their actual implementation resides in simple [C# console applications](https://www.nuke.build/docs/authoring-builds/fundamentals.html). This approach unleashes the power of the type system and natively provides IDE features like code-completion, refactorings, and debugging. A custom [global tool](https://www.nuke.build/docs/running-builds/global-tool.html) and several [IDE extensions](https://www.nuke.build/docs/running-builds/from-ides.html) further improve how build projects are setup, authored and executed. A revolutionary code-generation approach ensures scalable [integration of third-party tools](https://www.nuke.build/docs/authoring-builds/cli-tools.html) like MSBuild or dotnet CLI.

For more information checkout the [resources](http://www.nuke.build/docs/getting-started/resources.html) and [FAQ](http://www.nuke.build/docs/getting-started/faq.html) sections.

[![Slack](https://img.shields.io/badge/slack-nukebuildnet-red.svg?style=for-the-badge&colorB=F5015F&logo=slack)](https://slofile.com/slack/nukebuildnet)
[![Twitter](https://img.shields.io/badge/twitter-%40nukebuildnet-blue.svg?style=for-the-badge&logo=twitter&logoColor=white)](https://twitter.com/nukebuildnet)

## Features

Here is a short list of some most-loved features:

- 🎲 [Easy to adopt in a team](https://www.nuke.build/docs/getting-started/philosophy.html)
- 🧠 [Comfortable to run](https://www.nuke.build/docs/running-builds/fundamentals.html)
- 🔥 [Powerful dependency model](https://www.nuke.build/docs/authoring-builds/fundamentals.html)
- 📥 [Parameter declarations](https://www.nuke.build/docs/authoring-builds/parameter-declaration.html)
- 👾 [Extensive tools support](https://www.nuke.build/docs/authoring-builds/cli-tools.html)
- ⚙️ [Deep CI integration](https://www.nuke.build/docs/authoring-builds/ci-integration.html)
- 🍀 [Build sharing options](https://www.nuke.build/docs/sharing-builds/fundamentals.html)
- 🗂 [Project model support](https://www.nuke.build/docs/authoring-builds/solutions-and-projects.html)
- 💾 [Abstraction of OS paths](https://www.nuke.build/docs/authoring-builds/system-paths.html)
- 🧩 [Extensibility points](https://www.nuke.build/docs/authoring-builds/events.html)
- 🔌 [IDE extensions](https://www.nuke.build/docs/running-builds/from-ides.html)
- 📝 [Logging and assertions](https://www.nuke.build/docs/authoring-builds/logging-and-assertions.html)
- ❤️ [Backed by community](#contributing)

## Example

<p align="center"><img width="800px" src="https://github.com/nuke-build/nuke/raw/develop/images/example-1.png" /></p>

## Contributing

<!--[![Contributors](https://img.shields.io/github/contributors/nuke-build/nuke.svg?style=for-the-badge&label=contributors&logo=data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAAFgAAABACAYAAACeELDCAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAHYcAAB2HAY%2Fl8WUAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTnU1rJkAAAEFUlEQVR4Xu2bjY3UMBCFrwRKoAQ6gA6gA64D6AA6gA6gA%2BgAOoAOjg6gg2XeSl7lfN%2FGdjweR9E%2B6ZNO7%2BIZjzc%2Fjr17dzqdtvLc%2BGD8MJL0tzz9j9rsmSH1oFnBO6MkHUNt98iwetAs8MWolY6lGHtiaD1ortDSmaTPBsXaA8PrQfMKb4ytUluKOZOQetC8woOxVWpLMWcSUg%2BawL3RK8Wg2DMIqwdN4JfRK8Wg2DMIqwfNjBeGlxSLcqzx1vhm5PNTefoftVkjtB40M94bXlIsykFogv%2FXKEnH6FiKQYTWg2bGV8NLikU5luis2HIJq03NFRJaD5oZPw0vKRblSHhcvqVBjqynaoBrLtNaKRblEBoYj1yKsTbIUfWcQTPDW5RDiynehV9boPEW5biAZoa3KIdmBN5STMrlLcpxAc0Mb%2BXxe15ZS6JXWm%2Fl8R%2BBZsboh0LPK2tJ9Eq7u4fcyGnNK2O0lGOZc3fTtI%2BGl%2FKJ%2BXdjtJRjmXNkPU9AM8NjbpqUP9mjtMw5sp4noAn8MXr121jGjLg9JOW3iRH1IGgCI5b3PC%2FVkpRrmXt3y5Wi51NX2zye59O8JHrae9eDoHkF7y2W2QPsXQ%2BC5gra8GvVtU1Cz1fjkq5t8XjWg6BZoGUeuTZPjBb1QXjVg6BZQc2idWmOGC3qQ8KjHgTNSjQHpJmAvOL80IjUP4P6sKS3HgTNjGfGS0PbMp8M7YeJtV0H3fPScWq3x4ecplnqW%2Brn2pqIak3HaQzUTmOiscnjPgJN47Whb714LcRQgbMH2Cu%2FxkhjpTHLczwaYH0a%2BmRGPN1p5Z8ux1FSrjz%2FqDo1hpczOyXTJTx62pRfTj3z0Fbltyj1ZaQ0luecSubx2lij6CKXmvXh3iuZ1322JJqgz1iuFC1z3x49KFmU9EHmhUZcPbQoE3VSnZNFKl82FB5Lh9dEizKRy6TnhJGiV82RZzGdvVG3h7OUMFr0VjRiTkxzX%2BUOlZJGi85iPeX1OuslxcpnDiL07JWUdIboq03yPAZZMSh%2B6L03Ke%2FEbDQ%2F7RlktaUH6TTQnIzOPm0otkpt6MydCpo7QPdPrR%2FUnM06RsfSPXc6aO4IDVpJuxzYBJqBaNqkdVX9TFWrUFr2S%2BuuomYBSscs2yiGYimmYk%2B9baA5iDSQGoAtPxHolXIqdxp46qM7aDqhs1PF6Hu6o5dCt0h9Ut%2FUx81bQiXQ7EQr%2ByO%2BUD1a6jPuSvSA5kY0%2F5xx6XtLNbjNpdHcgO5tR5NqolqbQLORyL21aNFeXhNoNhK2eD1BtEnQBJqNHF1UczVoNnJ0Uc3VoNnI0UU1V4NmI0cX1VwNmo0cXVRzNWg2cnRRzdWg2cjRRTVXg2YjRxfVXA2aN%2FxA84YfaN7wA80bXpzu%2FgPmTK3HK79ikgAAAABJRU5ErkJggg%3D%3D)](https://github.com/nuke-build/nuke/graphs/contributors)
[![Bug Reports](https://img.shields.io/github/issues/nuke-build/nuke/bug%20:beetle:.svg?label=bug%20reports&colorB=DFB317&style=for-the-badge&logo=data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAWdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjFM78X%2FAAADc0lEQVR4Xu2bi1HjMBCGUwIlUAIlUAIdQAdHCZRAB1ACHUAH0MHRAXQQvt9aOR6HxHraIs43oznifVmWdm3Lus2cbLfbS9o%2F2ivtnebR3zom2aWpL4NOgHZrP4tgPp9ooUi36IXA3%2B1Rnwgfaf9pnisTZYGfO9pX5zEO2dyYmyzwc9V5dKiPjybawcGXTrzj3kTJ4EOdz%2BXO3CWDj3vnqufFRDs4OK0UAfYlOu%2FJmgnYTw8uB4fTRHyZKBpslfMp0%2F4Q8pVcE8x%2ByO%2FpjeDbyXuS6gB2z868KM%2FmPgrsxgP7baJ9EGbXAWw0%2BrWIngXYhKc2wuw6gM3YR0lSBiR8UBFm1wFs3pxpFVIGJCz%2FPShk1QH0h094pXm3MEGgH57%2FHpSy6oDZVMPCBIF6fEqjlFUHzKYaFiYI1OMHE6WsOoD%2BpzOrwqeFCQL9uPz3oJhcB9AdX%2FWSBM9GdOPz34Nych1A98GZVOHBwkyCbnoqo1zzXr4U4cUc5fH0OQXiHusxGNeBv0x4%2FnswqlnM5ib6CTIYnGstbyle7TSWgRNooVhGPakWg8ClFz1SyVosSYagWkRtheDngyIQ8ILWwuh7dC4Xdnr1IViLD0rz1QKC1XznT%2BXNTq8uBNL0b5X6aUCQkuv9pcn%2BiDIJQWq%2B7eVS%2F25AkJqLnrnUrwMEabEAeqIWTTvMcLWcL4D9u1rOFyAWbD6caZN82GnWgyCrvw229Bo8Zn%2FvT2kIcuNiNUmRTVVHIUjNDRC5zLMmQKAWC2H9AughWIsLIvXfBD0E05pASx9OdC5lpz8O1%2F1hBKOWFj1zidvrhMG6P46ivPrP48EbJJAtVRC1Fedg4UM2HsSoDRLj%2FD86fSSnzXkRFCvknIaE1QEUk%2FbWoDfXRZjsvMd0h0zboZQ8ddDVRai6S4wWXMzQjd%2FrhFLyBimBvmpCjWcI%2BYx62EE%2FfjBRisr%2FQ2B3TSsxG%2BTj2txGgV1cHUAhKf%2BPgQ99SUpZRJFNif8uE14HEKbfOibAl16jdTG0oKLODWeH%2FtYxyaRT7LkeX%2BEpjTAr%2F1tEfXBd6Tk8qAiL5H9LqA%2BuKz2%2F1wEExfO%2FFdQX16We%2FYHlYLX8Xxr1xXWpZz%2B1OXhy%2Be9RX1yXevYHl4OqwMPK%2FOfz36O%2BuC51qI%2BHl88Rdrcr%2B3kyqE%2Fqm%2F0849hsfgB%2BO7VepkdkzgAAAABJRU5ErkJggg%3D%3D)](https://github.com/nuke-build/nuke/issues?q=is%3Aissue+is%3Aopen+sort%3Aupdated-desc+label%3A%22bug+%3Abeetle%3A%22)-->

[<img align="right" width="130px" src="https://github.com/nuke-build/nuke/raw/develop/images/dotnet-bot.png" />](https://dotnet.microsoft.com/)

NUKE is already a stable full-featured tool that allows implementing build automation on a professional level, and it continues to evolve! We add new features all the time, but we have too many new cool ideas so that any help is highly appreciated. You can develop new features, fix bugs, improve the documentation, or do some other cool stuff.

If you want to contribute, check out the [contribution guidelines](CONTRIBUTING.md) and
  [first-timer](https://github.com/nuke-build/nuke/issues?q=is%3Aissue+is%3Aopen+label%3A%22first-timers+%3Ahugs%3A%22) issues. If you have new ideas or want to complain about bugs, feel free to [create an issue](https://github.com/nuke-build/nuke/issues/new). Let's create the best tool for build automation together!

Thanks to all the great people who have already contributed to the project! 

[![Contributors](https://opencollective.com/nuke/contributors.svg?button=false&avatarHeight=80&width=900)](CONTRIBUTORS.md)

## Backers & Sponsors

[![OpenCollective](https://opencollective.com/nuke/backers/badge.svg?style=for-the-badge)](https://opencollective.com/nuke/order/7399) 
[![OpenCollective](https://opencollective.com/nuke/sponsors/badge.svg?style=for-the-badge)](https://opencollective.com/nuke/order/7400)

This project is driven by contributors investing their private free time. If it helps you improving your productivity and thus financial situation, please consider becoming a [backer](https://opencollective.com/nuke/order/7399) (individuals) or [sponsor](https://opencollective.com/nuke/order/7400) (companies). Your monetary contributions will be used to further promote the project (website, stickers, cups). Additional profits will be forwarded to non-profit associations.

<img src="https://opencollective.com/nuke/sponsor.svg?avatarHeight=100&button=false"><img src="https://opencollective.com/nuke/backer.svg?&avatarHeight=100&button=false">

<!--[![TeamCity Build](https://img.shields.io/teamcity/codebetter/matkoch_NukeBuild_NukeBuildCommonBuildType.svg?label=teamcity&style=for-the-badge&logo=data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAAEEAAAA%2FCAYAAAC%2F36X0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTCtCgrAAAAC%2B0lEQVR4Xu2aDZHCMBSETwISkIAEJCABCUjAARKQgAQkIAEJSMhl75KbtOzLC%2FDyhpuwMx%2B0e7RNtvmj3FcIYXio%2BR9YrVZhvV7%2Fgf35Z1r5ednv98EbFLwsSI3FYhG22204Ho%2Fher1GS9btdgvn8znsdruwXC5h0XOW5A13IYioSWHmoBKo%2BCtCIFrgecNdtRBw5w%2BHQ9y0E8KQWkbecJcUAvr25XKJm%2FZCV0G3ippcM2%2B4i4WAAFDQ3kqt7O%2B6ecNd8xC8AoBwnbJrvEUIKJBXANBms8FbrvtvCBg0WtD6KirCjmOUfRP7rcI10JxRkXKdkKdQLczamNBEmmpEpcrQYyVSoVShcrUZJYOZBZ9jYczHgsydUaNHCNriB0KFHl0RIoyyhaX1Bv0sNSWsQ2hpBc8EUIK7n7ox%2FTugpoR1COWdkpSuSY%2B3gpoSliGguWqqNWFLqClhGUKapqp6pRs8AjUlLENII70orR9bQk0JyxC08UCaznpATQnPEPA8IIoeaw01JTxDSNeix1pDTYlPCBHPEFqWyFZQU8IzBK81AqCmhGUI2hSZvlPQY62hpoRlCC2LJa9xgZoSliG0LJsfOd8rUFPCMgRwOp3iW13sIcijaC2KmhLWIfT%2BKo3WloOuhUlNCesQQOtDFe1uzkFw88eBUhB3Ro0eIbQMkFmYNrWf1rRfrVgQkx2NHiGAlrGhFK6DKRYVQpnwPQP7rT%2FazIOYFEajVwjou60VsFLZve4KVKNXCAB9mD0h7qH5anRSEI2eIQAE0TJQviK2HJ%2FsaPQOAcwflVsJrextZwcJFNiqe6BctVmFmhKeIQC0CoTx7KCJWSeVmZ4%2FQ00JFAonlej5dBh3ElMh%2BjTCLscOtBh4AFMl1h4oaxQ91xxqjgY1R4Oao0HN0aDmaFBzNKg5GtQcDWqOBjVHg5qjQc3RoOZoUHM0qDka1BwNao7Gzwt7StQb7ZckT%2FKGuzz%2FHUcjb7jrE0LUJ4SoTwhRbxcCG717846zw8CEr2%2Fmetn3QDyWVAAAAABJRU5ErkJggg%3D%3D)](https://teamcity.jetbrains.com/viewLog.html?buildTypeId=matkoch_NukeBuild_NukeBuildCommonBuildType&buildId=lastFinished)
[![AzurePipelines Build](https://img.shields.io/azure-devops/build/nuke-build/6c8c128e-f661-413f-a023-46f47bbc1bbc/1.svg?style=for-the-badge&label=azure%20pipelines&logo=azure-pipelines&logoColor=white)](https://dev.azure.com/nuke-build/common/_build?definitionId=1)
[![AppVeyor Build](https://img.shields.io/appveyor/ci/matkoch/nuke.svg?style=for-the-badge&label=appveyor&logo=appveyor&logoColor=white)](https://ci.appveyor.com/project/matkoch/nuke)
[![Travis CI Build](https://img.shields.io/travis/nuke-build/nuke.svg?style=for-the-badge&label=travis&logo=travis-ci&logoColor=white)](https://travis-ci.org/nuke-build/common)
[![Bitrise Build](https://img.shields.io/bitrise/ffbfd67a7e3f1561/develop.svg?token=AsgY8yIy6MzdWs0cncU2Jg&style=for-the-badge&logo=data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAAEYAAABGCAYAAABxLuKEAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMTZEaa%2F1AAAD1ElEQVR4Xu2bO2gUURSG88bGQhSVBCFEUVHSaKGCBBuFgI02IiIIgoU2ki6NWohikYBCEAuxkBBUSBfEFCI%2BQBFLRRDSiBhfQTAkanT1O%2FeeHXY3e2CX3Sgzez74mXse987cfyez7iY2%2FQ9yudzbPxVC7wudln3cGAM3xqDUGOIZyalmNB0gbug7ZpWWmhh3x1Sk0Y1p1ZIYsyKmIm6MwtiNKeAYuV2qfZoLNLoxJm6MgRtj0GjGXGXPt0WMHwYHCiB3n0O%2BfkmnNR5s%2FldwBBjPaNpxYwzcGAM3xsCNMUiVMVzgNnT9HymnvogxPwryS61e3W7lMOmAXmtmYY%2F9ut3KcWMM3BiDUmOI59EZNJZSDaNXup0AcV2M%2BcChTcuphD2MxN1E3BjFjTFwYwzcGAM3xsCNMajJGPrb0R4m3QuzlYwaM4H6GDZrS3lo2oGm47RiyGfOmDzk76IubSuGwnH0W3sXQS2zxgjUZtEhbY2QOIySj%2F7loJxpYwTqC2hLvrkLvdNaArkpHQaIM2%2BMQM%2Bb0Mz4RExFKMgXRftR1e9K1Jvp60QHRcTyC%2FoWLS8JrN%2FBufbq%2BXpQ8gcCpdBT%2BvDtR2MaJpA7Ks2TGgeIB3WRqoyRGjpHX%2FKckjG6zHCtttUN1mxh7dPoWzgZ6PmeoE3aVgT5RcZwkBdTfsGXQDwqJ0ggIXfLOl2kYmPIy6t2IzSWgdprDh3aXjOsJaacRWWfi6Sn0UZtTyC3yBjJM9wdMxHyC6XGTIUVgHHFxlA7GbtCn5grb3%2BTqPBL7lPaXjMst5n1Cu%2FMp2gczWlKchMcin6MyVnGtDOejdlIzcaQk1fvWWgCxoMcWlArKnx%2BPdApNcM5BnRNOd9jtJyhXIc8a8JdxEH%2Brm%2B1TgkQlzWG4xr0XdOBUmPmUKc2V2PMCJJXbJx4mZZkjZX5PDqv6ZphrYGCdcP1CnotF%2FI14m4tBchZxuzUVIIkR3UcIL6jzVU9fNMAe7CMeampAPGoJJPbMg%2B5i6gRjDmChjUMEMtzcbvcfm0En0O2AHLzOgwQZ9GYnzpMIPdI28OEreS%2BxlJ5smhMKbrHHm2PkOxFyT%2BWSsm6MdQ%2BofXaWgz1Hoo3Y2sxWTZG88V3Sjlo3ICuxGmRLBpDPCR71XJlMKFh3q6rwo0xcGMMLGNQc1rFHq5xTKiXMfKpWT4xp1lF32kT125MFnFjDNwYg7oYQ%2FyRg%2Fx%2FxdSKPTznmFAvY95rKbWwhyHdTsCNUdwYAzfGwI0xcGMM3BgDN8ZgqYz5gvpSrlu6nQBx7cZkETfGwI0xcGMMbGOamv4CdueugEMtOgwAAAAASUVORK5CYII%3D)](https://www.bitrise.io/app/ffbfd67a7e3f1561#/builds)-->
<!--[![Jenkins Build](https://img.shields.io/jenkins/s/https/jenkins.nuke.build/job/nuke-build/job/nuke/job/develop.svg?style=for-the-badge&label=jenkins&logo=%20data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAYAAACM%2FrhtAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMjHxIGmVAAAGBklEQVRYR82YfayWcxjHT%2B%2BnkuQlU2e9iE6MiJS%2FakOLFCvOJHGY1kRYRqNh2LAOUXZaTJFWMubloGYtm7Nl8tZ0hlUzJ0dFRVGhF53j8%2F093%2Ftxnufc9%2FNyTjbf7bvf77qu73Xd93M%2Fv%2Fv3cpe0BU1NTaWNjY0Xw2nwSbgMroK1cD38BK5BtxTeT380bSen%2FzfgAj250G1wLTyIHQtih%2BE%2BeMSuAOxf4bOwzCWPDajdjaKPwX2pS2UC%2Fx9wGd0K2v607Z3XHrsvvAJWwXrr%2F4T3Rbo2gSKnU%2BwbFc4G%2FqNwETzF8pwgRTc8Gf7g%2FDdhF4eLB8m9o2LZwL8fjre0KJCuobLKdd6gaedQcSB5pYpkA%2F9fcJRlrQJlOlFjtevNsrtwkNQfHlWBbOCfYVmbQKkTqPUjPAD72J0fiLvCFanbyYSLtRg3%2BE6DI5AMgR3sjgU61R8I9QJNcd35DucH4reVlATiYy3VUzgf%2B%2BNUJI0BDseC%2BPSULNTa43YvTaklyUCoCTUfKqSlHYL%2Bd3gEvgofgnNDoRxAUw4Xkb%2BU9rtQEdCfYEkyED1tfSyIC%2F2trUmZjRNDcitAyQ7kL3Tt%2FH8zonckTgLxWkulHQ%2FvsJkGPq02NchzTh9oytF8RHsD1OqzzqFkIArzUxKIT7U0EWietzY9FdHXSvIh7vTqgX0mPAS%2FhZvhboeSgWi5iseBmMZaD0sTgWak9cvtkq%2FavvPsCsCeZ%2F%2FfUCtT7pUF7SNKiAPJDZYlAllHtWg%2Fhwdh2BjQjnWNBbYrYR2slT8Cdm%2FFE4Gg%2BUvym9sAYodoeloaCzTacmm79bVzZspPV%2Buw%2Fkrd9NlwDvwF6qlp87DD%2BoGhUBwI3mTROpoL7XtYvgjYVwdxDAhrj7gGhq0Y7VY42GHVuhTqhrbAvvIh6wz1JmvaUc6gIM4GsY4Ed8Bt9I%2BTkLYdbZkSI2Df45REINM6exJti%2B0Ufm2zVKcepm%2BG%2Fkv2xy95BC6wYB7sAXWzsx3TAN4G70SSf7bPA%2BrMgoL2hyfb95Yc2N2CKBvEokGs5Bvdv9uxGZhtvrHmoOYcX6PKtsatNsTxcyfB6Ak%2BB%2B%2BFm%2BBQh1sNagyHGX8btjYJL%2Fh6mjM1lHQc2GhJSyDSuNkJd8ET7W4zqKXDlFaJ66H%2BHb3lh31zX0HtgsI4p13htHgg0BiTUHPYGfJh9qOvbX1YfwsF%2BuPdzlTNCNh6i7X7uZm2qzT0KxwLQyoRaPSo51usF%2BMz2GD7WsvyAu25cA%2FU8lYGr4R3wUnwVF9Hvu%2FhdXCxr1HYkEI4Dq4lJ0zU9KsdKgjoR8DNztUT2wh1QNL41s1vdUzr8O1wN9QbXdzZhKSwN6R9wq4A7NlQW%2FXYSRW%2FnpLG9FT4PtSKIWgVGQp%2FhkvQaD95Tdw1CgJ5nUncCzPeLuzJLvq4XWngewbqqU1DEtZl2nawFPZSPwiB%2Buj0BUKbkOQlLhdIjKaDc%2BySrwtsgDqflNsdgD0Y7nKOdtsb6H5Bq4m%2B3rIA7InWpXc9RYN8nTmExXYFYE9IucONXmR3AHYf%2BBTcADW%2B9Bdrv6e%2Fu7s1OjXqpg9wjZxnmJwg%2BTKKROeOYXYHYGuA621XbCEs6JsLukEweom0pOY%2Fi2SDJB1s3lORCNjb4XBLArBHwS2Oa0LWOaUScwDMeCvx66k9CvdL3xz43qXpZ2kyEOkwrYEeZvts4NfTehmOwexFq7kt6aOSvnBpydQ0E%2FZ7uYBG%2F1T8kYK4NpS3wp0peeEgR%2BvoXLgEbrc7AFs7lDQwV8ORUOeROrvTwCeM8W2lgGMYXG9NQUD%2FAc3r7q90Kf1Q7SunwC8Vi4D9E5xkWQD2AoezMd2SIHoAZnxoLATkaK6LlsXXXC4D%2BC%2BBL8Jq2OITHb6qUCwL%2BK8KAvqaiGM%2FEBUDasTeYD6Q94pLZAD%2FWZYE0af2txrUqHG5NHBrTI%2Bj1ecNfRYR9flXf%2F%2Fl%2BKfThu8yzYFP55l%2Fv2XjuCUVaj2osYlGN9QdjoZ6YcKGoFiQV%2BdbSwGfvj%2Fry1KbQA0te8diuLRc9nA%2BCLX3%2Bz%2BwMnVXJSX%2FACrjqI7wt59WAAAAAElFTkSuQmCC)](https://jenkins.nuke.build/blue/organizations/jenkins/nuke-build%2Fnuke/branches/)-->

## Users

- [AvaloniaUI/Avalonia](https://github.com/AvaloniaUI/Avalonia/tree/master/nukebuild)
- [avivasolutionsnl/sitecore-commerce-docker](https://github.com/avivasolutionsnl/sitecore-commerce-docker/tree/master/build)
- [avivasolutionsnl/sitecore-docker](https://github.com/avivasolutionsnl/sitecore-docker/tree/master/build)
- [JoshClose/CsvHelper](https://github.com/JoshClose/CsvHelper/tree/master/build)
- [fluentassertions/fluentassertions](https://github.com/fluentassertions/fluentassertions/tree/master/Build)
- [zarunbal/LogExpert](https://github.com/zarunbal/LogExpert/tree/master/build)
- [nuke-build/nuke](https://github.com/nuke-build/nuke/tree/develop/build)
- [nuke-build/web](https://github.com/nuke-build/web/tree/master/build)
- [JetBrains/YouTrackSharp](https://github.com/JetBrains/YouTrackSharp)
- [joaomatossilva/DateTimeExtensions](https://github.com/joaomatossilva/DateTimeExtensions)
- [ViGEm/HidGuardian](https://github.com/ViGEm/HidGuardian/tree/master/build)
- [VirtoCommerce/vc-platform](https://github.com/VirtoCommerce/vc-platform/tree/release/3.0.0/build)

## Acknowledgements

Thanks to [JetBrains](https://jetbrains.com) for providing licenses for [Rider](https://jetbrains.com/rider) and access to the community [TeamCity](https://jetbrains.com/teamcity) instance, which both make open-source development a real pleasure!

[<img src="https://raw.githubusercontent.com/nuke-build/nuke/develop/images/jetbrains.png" width="450" />](https://jetbrains.com/)
