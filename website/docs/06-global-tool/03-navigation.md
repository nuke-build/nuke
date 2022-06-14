---
title: Navigation
---

Over time you might accumulate more and more projects that are built using NUKE. Some of these might even form a hierarchical structure, where one root directory contains several other root directories, and so on.

## Configuration

Add the following functions to your shell configuration (similar as for [shell completion](00-shell-completion.md)):

```
function nuke/ { nuke :PushWithChosenRootDirectory; cd $(nuke :GetNextDirectory) }
function nuke. { nuke :PushWithCurrentRootDirectory; cd $(nuke :GetNextDirectory) }
function nuke.. { nuke :PushWithParentRootDirectory; cd $(nuke :GetNextDirectory) }
function nuke- { nuke :PopDirectory; cd $(nuke :GetNextDirectory) }
```

## Usage

The global tool comes with a handful of functions for improved navigation:

| Command  | Function                                       |
|:---------|:-----------------------------------------------|
| `nuke.`  | Navigates to the current root directory        |
| `nuke..` | Navigates to the parent root directory         |
| `nuke/`  | Lists subdirectories that are root directories |
| `nuke-`  | Navigates to the last root directory           |

:::note
The `nuke-` command is only supported on shells that set the `TERM_SESSION_ID` or `WT_SESSION` environment variable. As of now, this includes [iTerm](https://iterm2.com/) and the [Windows Terminal](https://github.com/microsoft/terminal).
:::

