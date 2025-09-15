---
title: Shell Completion
---

import AsciinemaPlayer from '@site/src/components/AsciinemaPlayer';

Typing long target names or parameters can be tedious and error-prone. The global tool helps you to invoke commands more quickly and without any typos, similar to [tab completion for the .NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete).

:::info
The shell completion feature relies on the presence of an up-to-date `.nuke/build.schema.json` file. This file is updated with every execution of your build project.

Whenever you add or change one of your targets or parameters, it is recommended to trigger your build once, for instance by calling `nuke --help`.
:::

## Configuration

Add the following snippets to the configuration file of your shell:

<Tabs>
  <TabItem value="powershell" label="PowerShell" default>

```powershell title="Microsoft.PowerShell_profile.ps1"
Register-ArgumentCompleter -Native -CommandName nuke -ScriptBlock {
    param($commandName, $wordToComplete, $cursorPosition)
    nuke :complete "$wordToComplete" | ForEach-Object {
        [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
    }
}
```

  </TabItem>
  <TabItem value="zsh" label="Zsh">

```bash title=".zshrc"
_nuke_zsh_complete()
{
    local completions=("$(nuke :complete "$words")")
    reply=( "${(ps:\n:)completions}" )
}
compctl -K _nuke_zsh_complete nuke
```

  </TabItem>
  <TabItem value="bash" label="Bash">

```bash title=".bashrc"
_nuke_bash_complete()
{
    local word=${COMP_WORDS[COMP_CWORD]}
    local completions="$(nuke :complete "${COMP_LINE}")"
    COMPREPLY=( $(compgen -W "$completions" -- "$word") )
}
complete -f -F _nuke_bash_complete nuke
```

  </TabItem>
  <TabItem value="fish" label="fish">

```bash title="config.fish"
complete -fc nuke --arguments '(nuke :complete (commandline -cp))'
```

  </TabItem>
</Tabs>

## Usage

You can complete targets, parameters, and enumeration values by hitting the <kbd>TAB</kbd> key:

<AsciinemaPlayer
    src="/casts/shell-completion.cast"
    maxWidth="750px"
    idleTimeLimit={1}
    autoplay={true}
    poster="npt:12.077312"
    preload={true}
    terminalFontFamily="'JetBrains Mono', Consolas, Menlo, 'Bitstream Vera Sans Mono', monospace"
    loop={true}/>
