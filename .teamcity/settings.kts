import jetbrains.buildServer.configs.kotlin.v2018_1.*
import jetbrains.buildServer.configs.kotlin.v2018_1.buildFeatures.commitStatusPublisher
import jetbrains.buildServer.configs.kotlin.v2018_1.buildSteps.powerShell
import jetbrains.buildServer.configs.kotlin.v2018_1.triggers.vcs
import jetbrains.buildServer.configs.kotlin.v2018_1.vcs.GitVcsRoot

version = "2018.2"

project {
    description = "https://github.com/nuke-build"

    // BEGIN PROJECT
    vcsRoot(NukeBuildCommonVcsRoot)
    buildType(NukeBuildCommonBuildType)
    vcsRoot(NukeBuildPresentationVcsRoot)
    buildType(NukeBuildPresentationBuildType)
    vcsRoot(NukeBuildResharperVcsRoot)
    buildType(NukeBuildResharperBuildType)
    vcsRoot(NukeBuildTemplateVcsRoot)
    buildType(NukeBuildTemplateBuildType)
    vcsRoot(NukeBuildVisualstudioVcsRoot)
    buildType(NukeBuildVisualstudioBuildType)
    vcsRoot(NukeBuildVscodeVcsRoot)
    buildType(NukeBuildVscodeBuildType)
    vcsRoot(NukeBuildWebVcsRoot)
    buildType(NukeBuildWebBuildType)
    // END PROJECT

    features {
        feature {
            id = "PROJECT_EXT_343"
            type = "ReportTab"
            param("startPage", "coverage.zip!index.htm")
            param("title", "Code Coverage")
            param("type", "BuildReportTab")
        }
    }
}

open class CustomBuildType(configurationName: String, vcsRoot: GitVcsRoot) : BuildType() {
    init {
        name = configurationName
        description = vcsRoot.url!!

        artifactRules = "./output"

        vcs {
            root(vcsRoot)
        }

        steps {
            powerShell {
                scriptMode = file {
                    path = "build.ps1"
                }
                noProfile = false
            }
        }

        triggers {
            vcs {
                triggerRules = "+:**"
                branchFilter = ""
            }
        }

        //features {
        //    commitStatusPublisher {
        //        publisher = github {
        //            githubUrl = "https://api.github.com"
        //            authType = personalToken {
        //                token = "zxxa1c58b9d53d9223168b7b82f0705cb079d00f74adb1bfa306e19338b11d18c5570fb8c0d87e1be54775d03cbe80d301b"
        //            }
        //        }
        //    }
        //}
    }
}

open class CustomGitVcsRoot(url: String, defaultBranch: String) : GitVcsRoot() {
    init {
        name = "$url#refs/heads/$defaultBranch"
        this.url = url
        branch = "refs/heads/$defaultBranch"
        pollInterval = 60
        branchSpec = "+:refs/heads/*"
    }
}

// BEGIN OBJECTS
object NukeBuildCommonVcsRoot : CustomGitVcsRoot("https://github.com/nuke-build/common", "develop")
object NukeBuildCommonBuildType : CustomBuildType("nuke-build/common", NukeBuildCommonVcsRoot)
object NukeBuildPresentationVcsRoot : CustomGitVcsRoot("https://github.com/nuke-build/presentation", "master")
object NukeBuildPresentationBuildType : CustomBuildType("nuke-build/presentation", NukeBuildPresentationVcsRoot)
object NukeBuildResharperVcsRoot : CustomGitVcsRoot("https://github.com/nuke-build/resharper", "master")
object NukeBuildResharperBuildType : CustomBuildType("nuke-build/resharper", NukeBuildResharperVcsRoot)
object NukeBuildTemplateVcsRoot : CustomGitVcsRoot("https://github.com/nuke-build/template", "master")
object NukeBuildTemplateBuildType : CustomBuildType("nuke-build/template", NukeBuildTemplateVcsRoot)
object NukeBuildVisualstudioVcsRoot : CustomGitVcsRoot("https://github.com/nuke-build/visualstudio", "master")
object NukeBuildVisualstudioBuildType : CustomBuildType("nuke-build/visualstudio", NukeBuildVisualstudioVcsRoot)
object NukeBuildVscodeVcsRoot : CustomGitVcsRoot("https://github.com/nuke-build/vscode", "master")
object NukeBuildVscodeBuildType : CustomBuildType("nuke-build/vscode", NukeBuildVscodeVcsRoot)
object NukeBuildWebVcsRoot : CustomGitVcsRoot("https://github.com/nuke-build/web", "master")
object NukeBuildWebBuildType : CustomBuildType("nuke-build/web", NukeBuildWebVcsRoot)
// END OBJECTS
