{
  "Help": "GitLink makes symbol servers obsolete which saves you both time with uploading source files with symbols and the user no longer has to specify custom symbol servers (such as symbolsource.org). The advantage of GitLink is that it is fully customized for Git. It also works with GitHub or BitBucket urls so it does not require a local git repository to work. This makes it perfectly usable in continuous integration servers such as Continua CI. Updating all the pdb files is very fast. A solution with over 85 projects will be handled in less than 30 seconds. When using GitLink, the user no longer has to specify symbol servers. The only requirement is to ensure the check the Enable source server support option in Visual Studio.",
  "OfficialUrl": "https://github.com/GitTools/GitLink/",
  "Alias": {
    "SkipAttributes": true,
    "TaskName": "GitLink",
    "MethodPostfix": "3",
    "SettingsClass": "GitLink3Settings",
    "OverloadArguments": []
  },
  "SettingsClass": {
    "PackageId": "gitlink",
    "PackageExecutable": "GitLink.exe",
    "Name": "GitLink3Settings",
    "Properties": [
      {
        "Name": "PdbFile",
        "Type": "string",
        "Format": "{value}",
        "Help": "The PDB to add source indexing to."
      },
      {
        "Name": "Method",
        "Type": "GitLinkSourceCodeRetrieval?",
        "Format": "--method {value}",
        "Help": "The method for SRCSRV to retrieve source code. One of &lt;Http|Powershell&gt;. Default is Http."
      },
      {
        "Name": "RepositoryUrl",
        "Type": "string",
        "Format": "--url {value}",
        "Help": "Url to remote git repository."
      },
      {
        "Name": "CommitSha",
        "Type": "string",
        "Format": "--commit {value}",
        "Help": "The git ref to assume all the source code belongs to."
      },
      {
        "Name": "BaseDirectory",
        "Type": "string",
        "Format": "--baseDir {value}",
        "Help": "The path to the root of the git repo."
      },
      {
        "Name": "Verification",
        "Type": "bool",
        "Format": "--skipVerify",
        "Negate": true,
        "Help": "Verify all source files are available in source control."
      }
    ]
  },
  "DataClasses": [],
  "Enumerations": [
    {
      "Name": "GitLinkSourceCodeRetrieval",
      "Values": [
        "Http",
        "Powershell"
      ]
    }
  ]
}