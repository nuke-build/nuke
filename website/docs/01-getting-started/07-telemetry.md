---
title: Telemetry
---

As an effort to improve NUKE and to provide you with a better, more tailored experience, we include a telemetry feature that collects anonymous usage data and enables us to make more informed decisions for the future.

We want you to be fully aware about telemetry, which is why the global tool will show a disclosure notice on first start. In addition, every build project requires to define a `NukeTelemetryVersion` property:

```xml title="_build.csproj"
<PropertyGroup>
  <NukeTelemetryVersion>1</NukeTelemetryVersion>
</PropertyGroup>
```

We will increase the telemetry version whenever we add or change significant data points. With every version change and  after updating the `Nuke.Common` package, you will be prompted again for confirmation.

## Disclosure

NUKE will display a prompt similar to the following when executing a build project without the `NukeTelemetryVersion` property being set or when executing the global tool for the first time.

```text
Telemetry
---------
NUKE collects anonymous usage data in order to help us improve your experience.

Read more about scope, data points, and opt-out: https://nuke.build/telemetry
```

Once you confirm the notice, NUKE will either:

- Create an awareness cookie under `~/.nuke/telemetry-awareness/v1` for the respective global tool, or
- Add the `NukeTelemetryVersion` property to the project file.

## Scope

As a global tool and library, NUKE has [multiple events](https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Execution/Telemetry.Events.cs) where telemetry is collected:

- `BuildStarted` – when a build was started
- `TargetSucceeded` – when a target succeeded (only `Restore`, `Compile`, `Test`)
- `BuildSetup` – when setting up a build via `nuke [:setup]`
- `CakeConvert` – when converting Cake files via `nuke :cake-convert`

:::info
Data for `BuildStarted` and `TargetSucceeded` is only collected when `IsServerBuild` returns `true` (i.e., CI build), or the build is invoked via global tool. I.e., a contributor executing `build.ps1` or `build.sh` will not have telemetry enabled unknowingly. Likewise, when a build project targets a higher telemetry version than the installed global tool, the lower version will be used.
:::

## Data Points

The [telemetry data points](https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Execution/Telemetry.Properties.cs) do not collect personal data, such as usernames or email addresses. The data is sent securely to Microsoft servers using [Azure Monitor](https://azure.microsoft.com/services/monitor/) technology, held under restricted access, and published under strict security controls from secure [Azure Storage](https://azure.microsoft.com/services/storage/) systems.

Protecting your privacy is important to us. If you suspect the telemetry is collecting sensitive data or the data is being insecurely or inappropriately handled, file an issue in the [nuke-build/nuke](https://github.com/nuke-build/nuke) repository or [email us](mailto:info@nuke.build?subject=Telemetry) for investigation.

The telemetry feature collects the following data:

| Version | Data                                                                                      |
|:--------|:------------------------------------------------------------------------------------------|
| All	    | Timestamp of invocation                                                                   |
| All	    | Operating system                                                                          |
| All	    | Version of .NET SDK                                                                       |
| All	    | Repository provider (GitHub, GitLab, Bitbucket, etc.)                                     |
| All	    | Repository Branch (`main`, `develop`, `feature`, `hotfix`, custom)                        |
| All	    | Hashed Repository URL (SHA256; first 6 characters)                                        |
| All	    | Hashed Commit Sha (SHA256; first 6 characters)                                            |
| All	    | Compile time of build project in seconds                                                  |
| All	    | Target framework                                                                          |
| All	    | Version of `Nuke.Common` and `Nuke.GlobalTool`                                            |
| All	    | Host implementation (only non-custom)                                                     |
| All	    | Build type (project/global tool)                                                          |
| All	    | Number of executable targets                                                              |
| All	    | Number of custom extensions                                                               |
| All	    | Number of custom components                                                               |
| All	    | Used configuration generators and build components (only non-custom)                      |
| All	    | Target execution time in seconds (only for targets named _Restore_, _Compile_, or _Test_) |

:::note
Whenever a type does not originate from the `Nuke` namespace, it is replaced with `<External>`.
:::

## How to opt-out

The telemetry feature is enabled by default. To opt-out, set the `NUKE_TELEMETRY_OPTOUT` environment variable to `1` or `true`.
