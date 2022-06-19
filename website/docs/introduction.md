---
title: Introduction
sidebar_position: 0
---

<!-- https://docusaurus.io/docs/next/api/plugins/@docusaurus/plugin-content-docs#markdown-front-matter -->

🪴 Write **automation tools and CI/CD pipelines** in plain C# and with access to all .NET libraries.

💸 Tedious commit cycles are expensive. Instead, **debug and test your builds locally**.

💡 Install one of the **support extensions** for Visual Studio, Rider, ReSharper, or VS Code.

💥 Ready for more? Use **advanced features** like CI/CD generation, parallel execution, and build sharing.

## Fast Track ⏱

**1. Install the global tool:**

```powershell
# terminal-command
dotnet tool install Nuke.GlobalTool --global
```

**2. Go to a repository of your choice and set up a build:**

```powershell
# terminal-command
nuke :setup
```

**3. Run the build:**

```powershell
# terminal-command
nuke
```

**4. Open the build project and explore the default `Build` class.**

<!--
## Coming from Cake? 🍰

Get a feeling how your Cake scripts would look like in NUKE.

**1. Install the global tool:**

```powershell
# terminal-command
dotnet tool install Nuke.GlobalTool --global
```

**2. Go to a repository built with Cake**

**3. Convert your Cake scripts:**

```powershell
# terminal-command
nuke :cake-convert
```

**4. Inspect the outcome (errors are expected)**
-->
