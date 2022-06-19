---
title: Installation
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';

Before you can set up a build project, you need to install NUKE's dedicated [.NET global tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools):

```powershell
# terminal-command
dotnet tool install Nuke.GlobalTool --global
```

From now on you can use the global tool to:

- [Set up new builds](02-setup.md)
- [Run existing builds](03-execution.md)
- [Leverage shell completion](../06-global-tool/00-shell-completion.md)
- [Add tool & library packages](../06-global-tool/01-packages.md)
- [Navigate around root directories](../06-global-tool/03-navigation.md)
- [Convert CAKE build scripts](../06-global-tool/04-cake.md)
- [Manage secrets in parameter files](../06-global-tool/02-secrets.md)

:::note
If you're running on Linux-based systems, it's worth checking if the `nuke` global tool is available. This can be verified with `where nuke`. If the global tool is not found, you have to manually add `$HOME/.dotnet/tools` to your terminal configuration:

<Tabs>
  <TabItem value="zsh" label="Zsh" default>

```powershell
# terminal-command
echo 'export PATH=$HOME/.dotnet/tools:$PATH' >> ~/.zshrc
```

  </TabItem>
</Tabs>
:::

:::info
While theoretically, you could use NUKE by only adding its main NuGet package, we highly recommend to use the dedicated global tool to set up new builds. This ensures that your repository will run consistently in different environments and that your build implementation is always properly formatted.
:::

