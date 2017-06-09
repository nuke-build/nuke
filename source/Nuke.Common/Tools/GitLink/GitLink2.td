{
  "Help": "GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.",
  "OfficialUrl": "https://github.com/GitTools/GitLink/",
  "Alias": {
    "IconClass": "link",
    "TaskName": "GitLink",
    "MethodPostfix": "2",
    "SettingsClass": "GitLink2Settings",
    "OverloadArguments": []
  },
  "SettingsClass": {
    "PackageId": "gitlink",
    "PackageExecutable": "GitLink.exe",
    "Name": "GitLink2Settings",
    "Properties": [
      {
        "Name": "SolutionDirectory",
        "Type": "string",
        "Format": "{value}",
        "Help": "The directory containing the solution with the pdb files."
      },
      {
        "Name": "RepositoryUrl",
        "Type": "string",
        "Format": "-u {value}",
        "Help": "Url to remote git repository."
      },
      {
        "Name": "File",
        "Type": "string",
        "Format": "-f {value}",
        "Help": "Solution file name."
      },
      {
        "Name": "Configuration",
        "Type": "string",
        "Format": "-c {value}",
        "Help": "Name of the configuration, default value is 'Release'."
      },
      {
        "Name": "Platform",
        "Type": "string",
        "Format": "-p {value}",
        "Help": "Name of the platform, default value is 'AnyCPU'."
      },
      {
        "Name": "BranchName",
        "Type": "string",
        "Format": "-b {value}",
        "Help": "Name of the branch to use on the remote repository."
      },
      {
        "Name": "LogFile",
        "Type": "string",
        "Format": "-l {value}",
        "Help": "The log file to write to."
      },
      {
        "Name": "CommitSha",
        "Type": "string",
        "Format": "-s {value}",
        "Help": "The SHA-1 hash of the commit."
      },
      {
        "Name": "PdbDirectory",
        "Type": "string",
        "Format": "-d {value}",
        "Help": "The directory where pdb files exists, default value is the normal project output directory."
      },
      {
        "Name": "UsePowershell",
        "Type": "bool",
        "Format": "-powershell",
        "Help": "Use an indexing strategy that won't rely on SRCSRV http support, but use a powershell command for URL download instead."
      },
      {
        "Name": "ErrorsAsWarnings",
        "Type": "bool",
        "Format": "-errorsaswarnings",
        "Help": "Don't fail on errors, but treat them as warnings instead."
      },
      {
        "Name": "SkipVerification",
        "Type": "bool",
        "Format": "-skipverify",
        "Help": "Skip pdb verification in case it causes issues (it's a formality anyway)"
      },
      {
        "Name": "Debug",
        "Type": "bool",
        "Format": "-debug",
        "Help": "Enables debug mode with special dumps of msbuild."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": []
}