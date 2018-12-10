namespace Nuke.Common.Tooling.Paket

open Paket

[<AutoOpen>]
module internal Utility = 
    let isNotNull v = isNull v |> not

module PaketPackageResolver =         
    let private getPackageFolder(packageName: Domain.PackageName, groupName: Domain.GroupName) (dependenciesFile: string): string = 
        if isNotNull dependenciesFile then
            let dependencies = Dependencies(dependenciesFile) 
            let path = 
                dependencies
                    .GetLockFile()
                    .GetGroup(groupName)
                    .GetPackage(packageName)
                    .Folder dependencies.RootPath groupName
            path
        else
            null
        
    let TryGetLocalInstalledPackageDirectoryInMainGroup (packageName: string) (dependenciesFile: string): string =
        let package = Domain.PackageName(packageName), Domain.GroupName("Main")
        getPackageFolder package dependenciesFile
    
    let TryGetLocalInstalledPackageDirectory (packageName: string) (groupName: string) (dependenciesFile: string): string = 
        let package = Domain.PackageName(packageName), Domain.GroupName(groupName)
        getPackageFolder package dependenciesFile