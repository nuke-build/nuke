---
title: Visual Studio Code
---

import InstallButton from "../../src/components/InstallButton";
import ControlKey from '@site/src/components/ControlKey';

<InstallButton
    url="vscode:extension/nuke.support"
    install={true}
    event="DR2GVCBB" />

In [Visual Studio Code](https://code.visualstudio.com/) you can install the [NUKE Support extension](https://marketplace.visualstudio.com/items?itemName=nuke.support) to be more productive in writing, running, and debugging your builds.

Above each target, you can click the `Run Target` or `Debug Target` CodeLens items. Additionally, you can bring up the command palette via <ControlKey/> + <kbd>Shift</kbd> + <kbd>P</kbd> and call one of the actions to run/debug with/without dependencies:

![Visual Studio Code](vscode-win-light.webp#gh-light-mode-only)
![Visual Studio Code](vscode-win-dark.webp#gh-dark-mode-only)
