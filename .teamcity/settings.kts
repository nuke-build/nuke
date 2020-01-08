// THIS FILE IS AUTO-GENERATED
// ITS CONTENT IS OVERWRITTEN WITH EXCEPTION OF MARKED USER BLOCKS

import jetbrains.buildServer.configs.kotlin.v2018_1.*
import jetbrains.buildServer.configs.kotlin.v2018_1.buildFeatures.*
import jetbrains.buildServer.configs.kotlin.v2018_1.buildSteps.*
import jetbrains.buildServer.configs.kotlin.v2018_1.triggers.*
import jetbrains.buildServer.configs.kotlin.v2018_1.vcs.*

version = "2019.1"

project {
    vcsRoot(VcsRoot)

    buildType(Compile)
    buildType(Pack)
    buildType(Test_P1T2)
    buildType(Test_P2T2)
    buildType(Test)
    buildType(Publish)
    buildType(Announce)

    buildTypesOrder = arrayListOf(Compile, Pack, Test_P1T2, Test_P2T2, Test, Publish, Announce)

    params {
        select (
            "env.Verbosity",
            label = "Verbosity",
            description = "Logging verbosity during build execution. Default is 'Normal'.",
            value = "Normal",
            options = listOf("Minimal" to "Minimal", "Normal" to "Normal", "Quiet" to "Quiet", "Verbose" to "Verbose"),
            display = ParameterDisplay.NORMAL)
        select (
            "env.Configuration",
            label = "Configuration",
            description = "Configuration to build - Default is 'Debug' (local) or 'Release' (server)",
            value = "Release",
            options = listOf("Debug" to "Debug", "Release" to "Release"),
            display = ParameterDisplay.NORMAL)
        text (
            "env.IgnoreFailedSources",
            label = "IgnoreFailedSources",
            value = "False",
            allowEmpty = true,
            display = ParameterDisplay.NORMAL)
        text (
            "env.Source",
            label = "Source",
            description = "NuGet Source for Packages",
            value = "https://api.nuget.org/v3/index.json",
            allowEmpty = true,
            display = ParameterDisplay.NORMAL)
        text (
            "env.GitHubToken",
            label = "GitHubToken",
            description = "GitHub Token",
            value = "",
            allowEmpty = true,
            display = ParameterDisplay.NORMAL)
        param(
            "teamcity.runner.commandline.stdstreams.encoding",
            "UTF-8"
        )
    }
}
object VcsRoot : GitVcsRoot({
    name = "https://github.com/nuke-build/nuke.git#refs/heads/develop"
    url = "https://github.com/nuke-build/nuke.git"
    branch = "refs/heads/develop"
    pollInterval = 60
    branchSpec = """
        +:refs/heads/*
    """.trimIndent()
})
object Compile : BuildType({
    name = "⚙️ Compile"
    vcs {
        root(VcsRoot)
    }
    steps {
        powerShell {
            scriptMode = file { path = "build.ps1" }
            param("jetbrains_powershell_scriptArguments", "Restore Compile --skip")
            noProfile = true
        }
    }
})
object Pack : BuildType({
    name = "📦 Pack"
    vcs {
        root(VcsRoot)
    }
    artifactRules = """
        output/*.nupkg
    """.trimIndent()
    steps {
        powerShell {
            scriptMode = file { path = "build.ps1" }
            param("jetbrains_powershell_scriptArguments", "Pack --skip")
            noProfile = true
        }
    }
    triggers {
        vcs {
            branchFilter = ""
            triggerRules = "+:**"
        }
        schedule {
            schedulingPolicy = daily {
                hour = 3
                timezone = "Europe/Berlin"
            }
            branchFilter = ""
            triggerRules = "+:**"
            triggerBuild = always()
            withPendingChangesOnly = false
            enableQueueOptimization = true
            param("cronExpression_min", "3")
        }
    }
    dependencies {
        snapshot(Compile) {
            onDependencyFailure = FailureAction.FAIL_TO_START
            onDependencyCancel = FailureAction.CANCEL
        }
    }
})
object Test_P1T2 : BuildType({
    name = "🚦 Test 🧩 1/2"
    vcs {
        root(VcsRoot)
        cleanCheckout = true
    }
    artifactRules = """
        output/*.trx
        output/*.xml
    """.trimIndent()
    steps {
        powerShell {
            scriptMode = file { path = "build.ps1" }
            param("jetbrains_powershell_scriptArguments", "Test --skip --test-partition 1")
            noProfile = true
        }
    }
    dependencies {
        snapshot(Compile) {
            onDependencyFailure = FailureAction.FAIL_TO_START
            onDependencyCancel = FailureAction.CANCEL
        }
    }
})
object Test_P2T2 : BuildType({
    name = "🚦 Test 🧩 2/2"
    vcs {
        root(VcsRoot)
        cleanCheckout = true
    }
    artifactRules = """
        output/*.trx
        output/*.xml
    """.trimIndent()
    steps {
        powerShell {
            scriptMode = file { path = "build.ps1" }
            param("jetbrains_powershell_scriptArguments", "Test --skip --test-partition 2")
            noProfile = true
        }
    }
    dependencies {
        snapshot(Compile) {
            onDependencyFailure = FailureAction.FAIL_TO_START
            onDependencyCancel = FailureAction.CANCEL
        }
    }
})
object Test : BuildType({
    name = "🚦 Test"
    type = Type.COMPOSITE
    vcs {
        root(VcsRoot)
        showDependenciesChanges = true
    }
    artifactRules = """
        output/*.trx
        output/*.xml
    """.trimIndent()
    triggers {
        vcs {
            branchFilter = ""
            triggerRules = "+:**"
        }
        schedule {
            schedulingPolicy = daily {
                hour = 3
                timezone = "Europe/Berlin"
            }
            branchFilter = ""
            triggerRules = "+:**"
            triggerBuild = always()
            withPendingChangesOnly = false
            enableQueueOptimization = true
            param("cronExpression_min", "3")
        }
    }
    dependencies {
        snapshot(Test_P1T2) {
            onDependencyFailure = FailureAction.FAIL_TO_START
            onDependencyCancel = FailureAction.CANCEL
        }
        snapshot(Test_P2T2) {
            onDependencyFailure = FailureAction.FAIL_TO_START
            onDependencyCancel = FailureAction.CANCEL
        }
    }
})
object Publish : BuildType({
    name = "🚚 Publish"
    vcs {
        root(VcsRoot)
    }
    steps {
        powerShell {
            scriptMode = file { path = "build.ps1" }
            param("jetbrains_powershell_scriptArguments", "Publish --skip")
            noProfile = true
        }
    }
    params {
        text (
            "env.ApiKey",
            label = "ApiKey",
            description = "NuGet Api Key",
            value = "",
            allowEmpty = false,
            display = ParameterDisplay.PROMPT)
        text (
            "env.SlackWebhook",
            label = "SlackWebhook",
            description = "Slack Webhook",
            value = "",
            allowEmpty = false,
            display = ParameterDisplay.PROMPT)
        text (
            "env.GitterAuthToken",
            label = "GitterAuthToken",
            description = "Gitter Auth Token",
            value = "",
            allowEmpty = false,
            display = ParameterDisplay.PROMPT)
    }
    dependencies {
        snapshot(Test) {
            onDependencyFailure = FailureAction.FAIL_TO_START
            onDependencyCancel = FailureAction.CANCEL
        }
        snapshot(Pack) {
            onDependencyFailure = FailureAction.FAIL_TO_START
            onDependencyCancel = FailureAction.CANCEL
        }
        artifacts(Pack) {
            artifactRules = """
            output/*.nupkg
            """.trimIndent()
        }
    }
})
object Announce : BuildType({
    name = "🗣 Announce"
    vcs {
        root(VcsRoot)
    }
    steps {
        powerShell {
            scriptMode = file { path = "build.ps1" }
            param("jetbrains_powershell_scriptArguments", "Announce --skip")
            noProfile = true
        }
    }
    triggers {
        finishBuildTrigger {
            buildType = "Publish"
        }
    }
})
