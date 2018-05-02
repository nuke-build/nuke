# Variables
Variables are quite useful if you need different formats of the version number. Running `GitVersion.exe` in your repo will show you what is available.
For the `release/3.0.0` branch of GitVersion it shows:

```json
{
  "Major":3,
  "Minor":0,
  "Patch":0,
  "PreReleaseTag":"beta.1",
  "PreReleaseTagWithDash":"-beta.1",
  "PreReleaseLabel":"beta",
  "PreReleaseNumber":1,
  "BuildMetaData":1,
  "BuildMetaDataPadded": "0001",
  "FullBuildMetaData":"1.Branch.release/3.0.0.Sha.28c853159a46b5a87e6cc9c4f6e940c59d6bc68a",
  "MajorMinorPatch":"3.0.0",
  "SemVer":"3.0.0-beta.1",
  "LegacySemVer":"3.0.0-beta1",
  "LegacySemVerPadded":"3.0.0-beta0001",
  "AssemblySemVer":"3.0.0.0",
  "AssemblySemFileVer":"3.0.0.0",
  "FullSemVer":"3.0.0-beta.1+1",
  "InformationalVersion":"3.0.0-beta.1+1.Branch.release/3.0.0.Sha.28c853159a46b5a87e6cc9c4f6e940c59d6bc68a",
  "BranchName":"release/3.0.0",
  "Sha":"28c853159a46b5a87e6cc9c4f6e940c59d6bc68a",
  "NuGetVersionV2":"3.0.0-beta0001",
  "NuGetVersion":"3.0.0-beta0001",
  "NuGetPreReleaseTagV2":"beta0001",
  "NuGetPreReleaseTag":"beta0001",
  "CommitsSinceVersionSource":1,
  "CommitsSinceVersionSourcePadded":"0001",
  "CommitDate":"2014-03-06"
}
```


#### Why is AssemblyVersion only set to Major.Minor?

This is a common approach that gives you the ability to roll out hot fixes to your assembly without breaking existing applications that may be referencing it. You are still able to get the full version number if you need to by looking at its file version number.

